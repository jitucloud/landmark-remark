using Landmark.Remark.Website.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Landmark.Remark.Website.Interface
{
    /// <summary>
    /// Interface Note Manager for notes
    /// </summary>
    public interface INoteManager
    {
        Task<List<UserNote>> GetAllRemarkNotes(string filter = null);
        Task<bool> PostRemarkOnCurrentLocation(UserNote note);

        
    }
}