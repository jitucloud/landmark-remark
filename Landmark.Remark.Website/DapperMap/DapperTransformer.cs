using Dapper.FluentMap;

namespace Landmark.Remark.Website.DapperMap
{
    /// <summary>
    /// Dapper Transformation Configuration
    /// </summary>
    public class DapperTransformer
    {
        public static void Register()
        {
            FluentMapper.Initialize(config =>
            {
                 config.AddMap(new UserNoteMap());
            });
        }
    }
}