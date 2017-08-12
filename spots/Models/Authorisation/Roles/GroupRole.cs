using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json.Bson;
using spots.Models.Authorisation.Actions;
using spots.Models.Authorisation.Actions.Interfaces;
using spots.Models.Authorisation.Roles.Interfaces;

namespace spots.Models.Authorisation.Roles
{
    public class GroupRole : IGroupRole
    {
        public string Title { get; set; }
        public IDictionary<string, bool> ActionDictionary { get; set; }

        public void SetAdminActions()
        {
            ActionDictionary = new Dictionary<string, bool>
            {
                {GroupActions.AddMember, true},
                {GroupActions.RemoveMember, true},
                {GroupActions.ViewMember, true},
                {GroupActions.ViewSpot, true }
            };
        }

        public void SetModeratorActions()
        {
            ActionDictionary = new Dictionary<string, bool>
            {
                {GroupActions.AddMember, true},
                {GroupActions.RemoveMember, false},
                {GroupActions.ViewMember, true},
                {GroupActions.ViewSpot, true }
            };
        }

        public void SetMemberrActions()
        {
            ActionDictionary = new Dictionary<string, bool>
            {
                {GroupActions.AddMember, false},
                {GroupActions.RemoveMember, false},
                {GroupActions.ViewMember, true},
                {GroupActions.ViewSpot, true }
            };
        }

        public static IEnumerable<IGroupRole> CreateDefault
        {
            get
            {
                var admin = new GroupRole();
                admin.Title = "Admin";
                admin.SetAdminActions();

                var moderator = new GroupRole();
                moderator.Title = "Moderator";
                moderator.SetModeratorActions();

                var member = new GroupRole();
                member.Title = "Member";
                member.SetMemberrActions();

                return new List<GroupRole> { admin, moderator, member };
            }
        }
    }
}