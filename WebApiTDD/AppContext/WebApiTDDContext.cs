using System.Data.Entity;
using WebApiTDD.AppContext;
using WebApiTDD.AppContext.Mapping;
using WebApiTDD.Domain.Models;
using WebApiTDD.Repository.Repository;

namespace WebApiTDD.AppContext
{
    public partial class WebApiTddContext : DbContext, IDbContext
    {
        static WebApiTddContext()
        {
            // we can also call this in Application_Start

            //Database.SetInitializer<WebApiTddContext>(new DropCreateDatabase());
        }

        public WebApiTddContext()
            : base("Name=Context")
        {
        }

        public DbSet<Collarborator> Collarborators { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CollarboratorMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new ManagerMap());
        }
    }
}
