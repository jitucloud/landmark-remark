using Autofac;
using Landmark.Remark.Website.Helper;
using Landmark.Remark.Website.Interface;
using Landmark.Remark.Website.Manager;

namespace Landmark.Remark.Website
{
    /// <summary>
    /// Dependency Injection fconfiguration
    /// </summary>
    public class ServicesRegistry
    {
        public void Register(ContainerBuilder builder)
        {
            var notesDB = new DbManager(ConfigManager.GetItemAsString("NotesDB", "flightbooking")); // This is the DB available to me
            var noteManager = new NoteManager(notesDB);
            builder.RegisterInstance<INoteManager>(noteManager);
        }
    }
}