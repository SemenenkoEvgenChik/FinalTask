// <auto-generated />
namespace Hospital.DAL.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class AddSoftDelete : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(AddSoftDelete));
        
        string IMigrationMetadata.Id
        {
            get { return "201906190928021_AddSoftDelete"; }
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