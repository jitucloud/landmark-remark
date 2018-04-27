using Dapper.FluentMap.Mapping;
using Landmark.Remark.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.Remark.Website.DapperMap
{
    /// <summary>
    /// UserMap note configuration
    /// </summary>
    public class UserNoteMap : EntityMap<UserNote>
    {
        public UserNoteMap()
        {
            Map(c => c.Id).ToColumn("id");
            Map(c => c.Lattitude).ToColumn("lattitude");
            Map(c => c.Longitude).ToColumn("longitude");
            Map(c => c.Note).ToColumn("note");
            Map(c => c.UserName).ToColumn("username");
        }
    }
}