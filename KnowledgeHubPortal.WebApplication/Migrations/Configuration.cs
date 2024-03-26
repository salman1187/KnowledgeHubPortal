namespace KnowledgeHubPortal.WebApplication.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KnowledgeHubPortal.WebApplication.Models.Data.KnowledgeHubDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "KnowledgeHubPortal.WebApplication.Models.Data.KnowledgeHubDbContext";
        }

        protected override void Seed(KnowledgeHubPortal.WebApplication.Models.Data.KnowledgeHubDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
