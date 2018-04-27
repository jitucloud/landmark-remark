using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Landmark.Remark.Website.Models
{
    /// <summary>
    /// UserNote class
    /// </summary>
    public class UserNote
    {
        public int Id { get; set; }
        public float Lattitude { get; set; }
        public float Longitude { get; set; }
        public string UserName { get; set; }
        public string Note { get; set; }

    }
}