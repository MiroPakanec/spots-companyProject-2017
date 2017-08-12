using System.Web.Mvc;
using spots.BL.Facades.Interfaces;
using spots.Models.Group.Interfaces;
using spots.Models.Group.ViewModels;

namespace spots.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupFacade _facade;

        public GroupController(IGroupFacade facade)
        {
            _facade = facade;
        }

        // GET: /Group/GroupMembers
        public PartialViewResult GroupMembers(string groupId)
        {
            var collection = _facade.GetMembers(groupId);
            return PartialView("Details/Information/_MembersPartial", collection);
        }

        // GET: /Group/AddGroupMembers
        public PartialViewResult AddGroupMembers(CreateGroupViewModel viewmodel)
        {
            return PartialView("Details/Information/_AddMemberPartial", viewmodel);
        }
        // GET: /Group
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        //GET: /Group/Create
        public ActionResult Create()
        {
            var email = User.Identity.Name;
            var viewModel = _facade.GetCreateViewModel(email);
            return View(viewModel);
        }

        //POST: /Group/Create
        [HttpPost]
        public ActionResult Create(CreateGroupViewModel viewModel)
        {
            IGroupResponse response;

            if (!ModelState.IsValid)
            {
                response = _facade.InvalidModelStateResponse;
                return PartialView("Create/_CreateResponsePartial", response);
            }

            response = _facade.CreateGroupResponse(viewModel);
            return PartialView("Create/_CreateResponsePartial", response);
        }

        // GET: /Group/Details
        public ActionResult Details(string id)
        {
            var viewModel = _facade.GetDetailsViewModel(id);
            return View(viewModel);
        }

        // GET: /Group/GetInfo
        public PartialViewResult GetInfo(string id)
        {
            var viewModel = _facade.GetInfoDetailsViewModel(id);
            return PartialView("Details/Information/_InformationPartial", viewModel);
        }

        // GET: /Group/GetPosts
        public PartialViewResult GetPosts(string id)
        {
            return PartialView("Details/Posts/_PostPartial");
        }

        // GET: /Group/GetTimeline
        public PartialViewResult GetTimeline(string id)
        {
            return PartialView("Details/Timeline/_TimelinePartial");
        }

        // GET: /Group/IsUserGroupMember
        public bool IsUserGroupMember(string userId, string groupId)
        {
            return _facade.IsMember(userId, groupId);
        }

        // GET: /Group/GetAddRemoveButton
        public ActionResult GetAddRemoveButton(string email, string groupId)
        {
            var isMember = _facade.IsMember(email, groupId);
            return Content(isMember ? "(yes) Create remove button partial view" : "(no) Create add button partial view");
        }

        // POST: /Group/AddGroupMember
        [HttpPost]
        public ActionResult AddGroupMember(string email, string groupId)
        {
            var response = _facade.AddMember(email, groupId);
            return Content(response);
        }

        // POST: /Group/RemoveGroupMember
        [HttpPost]
        public ActionResult RemoveGroupMember(string email, string groupId)
        {
            var response = _facade.RemoveMember(email, groupId);
            return Content(response);
        }
    }
}