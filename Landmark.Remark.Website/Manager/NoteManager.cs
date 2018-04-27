using Dapper;
using Landmark.Remark.Website.Interface;
using Landmark.Remark.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landmark.Remark.Website.Manager
{
    /// <summary>
    /// Note Manager Implementation
    /// </summary>
    public class NoteManager : INoteManager
    {
        private IDbManager dbManager;
        public NoteManager(IDbManager dbManager)
        {
            this.dbManager = dbManager;
        }
        public async Task<List<UserNote>> GetAllRemarkNotes(string filter = null)
        {
            var conditionFilter = !string.IsNullOrEmpty(filter) ? "username LIKE '%' + @filter +'%'  OR note LIKE '%' + @filter +'%' " : "1 = 1";
            var sql = $@"SELECT id, lattitude, longitude, username, note
                       FROM [flightbooking].[dbo].[usernote] WITH (NOLOCK) 
                       WHERE {conditionFilter}";

            using (var db = dbManager.GetOpenConnection())
            {
                var notesList = await db.QueryAsync<UserNote>(sql, new { filter = filter });
                if (notesList != null && notesList.Count() > 0)
                    return notesList.ToList();
            }
            return null;
        }


        public async Task<bool> PostRemarkOnCurrentLocation(UserNote note)
        {
            var sql = @"Insert into [flightbooking].[dbo].[usernote] Values (@lattitude,@longitude,@username,@note) 
                        SELECT @@ROWCOUNT ";

            using (var db = dbManager.GetOpenConnection())
            {
                var result = (await db.QueryAsync<int>(sql, new { lattitude = note.Lattitude, longitude = note.Longitude, username = note.UserName, note = note.Note })).FirstOrDefault() > 0;
                return result;
            }
        }
    }
}