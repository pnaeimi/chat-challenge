// <auto-generated />
namespace SimpleChatAPI.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    public sealed partial class chat : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(chat));
        
        string IMigrationMetadata.Id
        {
            get { return "201608270021038_chat"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
