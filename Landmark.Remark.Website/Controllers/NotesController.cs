using Landmark.Remark.Website.Interface;
using Landmark.Remark.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Landmark.Remark.Website.Controllers
{
    /// <summary>
    /// Notes Controller 
    /// </summary>
    [RoutePrefix("api/notes")]
    public class NotesController : ApiController
    {
        private readonly INoteManager noteManager;

        /// <summary>
        /// Notes Cotr 
        /// </summary>
        public NotesController(INoteManager noteManager)
        {
            this.noteManager = noteManager;
        }

        /// <summary>
        /// Get all remark notes
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        [ResponseType(typeof(List<UserNote>))]

        public async Task<IHttpActionResult> GetAllRemarkNotes(string filter = null)
        {

            var result = await noteManager.GetAllRemarkNotes(filter);
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        /// <summary>
        /// Post remark
        /// </summary>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(bool))]

        public async Task<IHttpActionResult> PostRemarkOnCurrentLocation(UserNote note)
        {
            if (note == null || string.IsNullOrEmpty(note.UserName) || string.IsNullOrEmpty(note.Note))
                return BadRequest("username or remark is not passed");

            var result = await noteManager.PostRemarkOnCurrentLocation(note);
            if (result)
                return Ok(result);
            else
                return InternalServerError();
        }

    }
}
