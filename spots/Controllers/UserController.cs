using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Core.Internal;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MongoDB.Bson;
using spots.BL.Facades.Interfaces;
using spots.DAL.SQLS;
using spots.Models.Account.Interfaces;
using spots.Models.Account.Viewmodels;
using spots.Models.Identity;
using spots.Models.User;
using spots.Models.User.Interfaces;
using spots.Models.User.ViewModels;
using spots.Services.EmailService.Interfaces;
using spots.Services.Routing;

namespace spots.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public ApplicationUserManager UserManager
            => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();

        public ApplicationSignInManager SignInManager => HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

        private readonly IUserFacade _facade;
        private readonly ISpotUser _user;
        private readonly IDelete _accountDelete;
        private readonly IUserResponse _response;
        private readonly IEmailService _emailService;

        public UserController(IUserFacade facade, ISpotUser user, IDelete accountDelete, IUserResponse response, IEmailService emailService)
        {
            _facade = facade;
            _user = user;
            _accountDelete = accountDelete;
            _response = response;
            _emailService = emailService;
        }

        //GET: User
        public ActionResult Index()
        {
            return RedirectToAction("Details",
                new RouteValueDictionary(new { controller = "User", action = "Details", Id = "MyProfile" }));
        }

        //GET: User/Details
        public ActionResult Details(string id)
        {
            if (string.IsNullOrEmpty(id) || id == "MyProfile")
            {
                var userIdentityEmail = User.Identity.Name;
                var userModel = _user.Repository.GetWithEmail(userIdentityEmail);
                return View(userModel);
            }
            else
            {
                var objectId = ObjectId.Parse(id);
                var userModel = _user.Repository.GetWithId(objectId);
                return View(userModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult PersonalDetailsUpdate(UserPersonalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _response.HasFailed("Some information was not entered correcntly");
                return PartialView("_ResponsePartial", _response);
            }

            if (model.Email != User.Identity.Name)
            {
                _response.HasFailed("You are no authorized to perform this action");
                return PartialView("_ResponsePartial", _response);
            }

            _user.Repository.UpdatePersonal(model);
            _response.HasSucceeded("User was updated successfully.");

            return PartialView("_ResponsePartial", _response);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult ContactDetailsUpdate(UserContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                _response.HasFailed("Some information was not entered correcntly");
                return PartialView("_ResponsePartial", _response);
            }

            if (model.Email != User.Identity.Name)
            {
                _response.HasFailed("You are no authorized to perform this action");
                return PartialView("_ResponsePartial", _response);
            }

            _user.Repository.UpdateContact(model);
            _response.HasSucceeded("User was updated successfully.");

            return PartialView("_ResponsePartial", _response);
        }

        //GET: /User/MyBusinesses
        public ActionResult MyBusinesses()
        {
            var email = User.Identity.Name;
            var businesses = _user.Repository.GetUserBusinesses(email);

            if (businesses.IsNullOrEmpty()) return null;

            var viewModel = new UserBusinessNameListViewModel { UserBusinesses = businesses as IEnumerable<UserBusiness> };
            return PartialView("_FeatureBusinessPartial", viewModel);
        }

        //GET: /User/MyGroups
        public ActionResult MyGroups()
        {
            var viewModel = _facade.GetMyGroupViewModel;
            return PartialView("_FeatureGroupPartial", viewModel);
        }

        //GET: /User/MyGroupIds
        //public string MyGroupIds()
        //{
        //    var model = _facade.GetMyGroupViewModel;
        //    return Serializer<UserGroupNameListViewModel>.ToJson(model);
        //}

        //GET: /User/MyBusinessesEnum
        public IEnumerable<IUserBusiness> MyBusinessesEnum()
        {
            return _user.Repository.GetCurrent.MyBusinesses;
        }

        //GET: /DeleteProfileConfirm
        public ActionResult DeleteProfileConfirm()
        {
            var userIdentityEmail = User.Identity.GetUserName();
            _accountDelete.Email = userIdentityEmail;

            return View("DeleteProfile/DeleteProfileConfirm", _accountDelete as DeleteViewModel);
        }

        public string GenerateProfileDeleteCode()
        {
            _accountDelete.GenerateCode(4);
            return _accountDelete.GeneratedCode;
        }

        //POST: /DeleteProfileConfirm
        [HttpPost]
        public ActionResult SendDeleteProfileEmail()
        {
            try
            {
                var userIdentityEmail = User.Identity.GetUserName();
                var userModel = _user.Repository.GetWithEmail(userIdentityEmail);

                _accountDelete.Email = userIdentityEmail;
                _accountDelete.GenerateCode(4);

                //Send email
                _emailService.Send(_emailService.Template.DeleteAccount(
                    _accountDelete.GeneratedCode,
                    userModel.FirstName,
                    userModel.Email));


                _response.HasSucceeded("Please check your email address, we have sent you an email with required code.");
                return PartialView("_ResponsePartial", _response as UserResponse);
            }
            catch (Exception)
            {
                _response.HasFailed("Email could not be sent to your account. Please try again.");
                return PartialView("_ResponsePartial", _response as UserResponse);
            }
        }

        //GET /DeleteProfileFailure
        public ActionResult DeleteProfileFailure()
        {
            return View("DeleteProfile/DeleteProfileFailure");
        }

        //GET /DeleteProfileSuccess
        public ActionResult DeleteProfileSuccess()
        {
            return View("DeleteProfile/DeleteProfileSuccess");
        }

        //GET /InviteUsers
        public ActionResult InviteUsers()
        {
            //TODO: Reduce this later based on groups
            var users = _user.Repository.GetAllExceptCurrent;
            return PartialView("_InvitePeople", users as IEnumerable<SpotUser>);
        }

        //Get /User/GetPersonalInfo
        public PartialViewResult GetPersonalInfo(string id)
        {
            if (string.IsNullOrEmpty(id) || id == "MyProfile")
            {
                var userIdentityEmail = User.Identity.Name;
                var userModel = _user.Repository.GetWithEmail(userIdentityEmail);
                return PartialView("Details/Personal/_PersonalDetailsPartial", new UserPersonalViewModel(userModel));
            }
            else
            {
                var objectId = ObjectId.Parse(id);
                var userModel = _user.Repository.GetWithId(objectId);
                return PartialView("Details/Personal/_PersonalDetailsPartial", new UserPersonalViewModel(userModel));
            }
        }

        //Get /User/GetContactInfo
        public PartialViewResult GetContactInfo(string id)
        {
            if (string.IsNullOrEmpty(id) || id == "MyProfile")
            {
                var userIdentityEmail = User.Identity.Name;
                var userModel = _user.Repository.GetWithEmail(userIdentityEmail);
                //TODO: Remove this
                userModel.FirstName = "George";
                return PartialView("Details/Contact/_ContactDetailsPartial", new UserContactViewModel(userModel));
            }
            else
            {
                var objectId = ObjectId.Parse(id);
                var userModel = _user.Repository.GetWithId(objectId);
                return PartialView("Details/Contact/_ContactDetailsPartial", new UserContactViewModel(userModel));
            }
        }

        ////Get /User/GetTimeline
        public ActionResult GetTimeline(string skip, string id)
        {
            if (id == "MyProfile" || id.IsNullOrEmpty())
            {
                id = _user.Repository.GetCurrent.MongoId;
            }

            return RedirectToAction("UserTimeline", "Timeline", new { skip, id });
        }

        //Get /User/GetCalendar
        public string GetCalendar()
        {
            return "Calendar!";
        }

        //Get /User/GetBusinesses
        public PartialViewResult GetBusinesses(string id)
        {
            if (string.IsNullOrEmpty(id) || id == "MyProfile")
            {
                var userIdentityEmail = User.Identity.Name;
                var userModel = _user.Repository.GetWithEmail(userIdentityEmail);
                return PartialView("Details/Business/_BusinessDetailsPartial", userModel.MyBusinesses);
            }
            else
            {
                var objectId = ObjectId.Parse(id);
                var userModel = _user.Repository.GetWithId(objectId);
                return PartialView("Details/Business/_BusinessDetailsPartial", userModel.MyBusinesses);
            }
        }

        //Get /User/GetGroups
        public string GetGroups()
        {
            return "Groups!";
        }

        //Post /User/IsRegistered
        public bool IsRegistered(string id)
        {
            try
            {
                var email = EscapeHelper.UnescapeDots(id);
                var user = _user.Repository.GetWithEmail(email) as SpotUser;

                return user != null;
            }
            catch
            {
                return false;
            }
        }

        //Get /User/GetFriendsGroupId
        public string GetFriendGroupId(string userId)
        {
            if (userId == "MyProfile")
            {
                return "";
            }

            var userEmail = _facade.GetUserEmailWithId(userId);
            if (userEmail == User.Identity.Name)
            {
                return "";
            }

            //return _facade.GetUserFriendGroupId(userId);

            return "58e4c79fb7e8eb4cd082a72d";
        }

        // GET: /User/AddFriend
        public PartialViewResult GetAddFriendButton()
        {
            return PartialView("Details/Personal/_AddFriendPartial");
        }

        // GET: /User/RemoveFriend
        public PartialViewResult GetRemoveFriendButton()
        {
            return PartialView("Details/Personal/_RemoveFriendPartial");
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteProfileConfirm(DeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("DeleteProfileFailure", "User");
            }

            if (model.Email != User.Identity.GetUserName() || model.GeneratedCode != model.Code)
            {
                return RedirectToAction("DeleteProfileFailure", "User");
            }

            var result =
                await
                    SignInManager.PasswordSignInAsync(model.Email, model.Password,
                        false, shouldLockout: false);

            return await DeleteProfileRedirect(result);
        }

        private async Task<ActionResult> DeleteProfileRedirect(SignInStatus result)
        {
            switch (result)
            {
                case SignInStatus.Success:
                {
                    return await DeleteUser()
                        ? RedirectToAction("DeleteProfileSuccess", "User")
                        : RedirectToAction("DeleteProfileFailure", "User");
                }
                case SignInStatus.LockedOut:
                    return RedirectToAction("DeleteProfileFailure", "User");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("DeleteProfileFailure", "User");
                case SignInStatus.Failure:
                    return RedirectToAction("DeleteProfileFailure", "User");
                default:
                    return RedirectToAction("DeleteProfileFailure", "User");

            }
        }

        private async Task<bool> DeleteUser()
        {
            var userEmail = User.Identity.GetUserName();
            var context = new ApplicationDbContext();
            var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            var logins = user.Logins;
            var rolesForUser = await UserManager.GetRolesAsync(User.Identity.GetUserId());

            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    RemoveLogins(logins);
                    RemoveRoles(rolesForUser, user);
                    await UserManager.DeleteAsync(user);

                    if (RemoveMongoUser(userEmail))
                    {
                        transaction.UnderlyingTransaction.Commit();
                        return true;
                    }

                    transaction.UnderlyingTransaction.Rollback();
                    return false;
                }
                catch
                {
                    transaction.UnderlyingTransaction.Rollback();
                    return false;
                }
            }
        }

        private void RemoveLogins(IEnumerable<IdentityUserLogin> logins)
        {
            foreach (var login in logins.ToList())
            {
                UserManager.RemoveLogin(login.UserId,
                    new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }
        }

        private void RemoveRoles(IEnumerable<string> roles, ApplicationUser user)
        {
            var rolesList = roles as IList<string> ?? roles.ToList();
            if (!rolesList.Any()) return;

            foreach (var role in rolesList)
            {
                UserManager.RemoveFromRole(user.Id, role);
            }
        }

        private bool RemoveMongoUser(string email)
        {
            var mongoResult = _user.Repository.FindAndDelete(u => u.Email == email);

            return mongoResult > 0;
        }
    }
}