using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using spots.Models.Authorisation.Actions.Interfaces;

namespace spots.Models.Authorisation.Actions
{
    public static class GroupActions
    {
        public static string AddMember => "AddMember";
        public static string RemoveMember => "RemoveMember";
        public static string ViewMember => "ViewMember";
        public static string ViewSpot => "ViewSpot";
    }
}