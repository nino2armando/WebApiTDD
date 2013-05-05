using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using System.Web;
using WebApiTDD.AppContext;
using System.Transactions;
using WebApiTDD.Domain.Models;

namespace WebApiTDD.AppContext
{
    public class DropCreateDatabase : IDatabaseInitializer<WebApiTddContext>
    {
        private readonly IDatabaseInitializer<WebApiTddContext> _initializer;
        public DropCreateDatabase()
        {
            InitializeDatabase(new WebApiTddContext());
        }

        public void InitializeDatabase(WebApiTddContext context)
        {
            bool dbExist;
            using (new TransactionScope(TransactionScopeOption.Suppress))
            {
                dbExist = context.Database.Exists();
            }
            if (dbExist)
            {
                // drop Database
                context.Database.ExecuteSqlCommand("ALTER DATABASE WebApiTDD SET SINGLE_USER WITH ROLLBACK IMMEDIATE"); 
                context.Database.Delete();

                // create all database
                ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
           
                Seed(context);
                context.SaveChanges();

            }
            else
            {
                // create all database
                ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();

                Seed(context);
                context.SaveChanges();
            }

        }

        protected virtual void Seed(WebApiTddContext context)
        {
            var it = new Department {Name = "IT"};
            var finance = new Department {Name = "Finance"};
            context.Departments.Add(it);
            context.Departments.Add(finance);

            var manager = new Manager
                {
                    Name = "Nino",
                    Department = it
                };
            var secondeManager = new Manager
            {
                Name = "Krista",
                Department = finance
            };

            context.Managers.Add(manager);
            context.Managers.Add(secondeManager);

            var collab = new Collarborator
                {
                    Name = "Tracy",
                    Department = finance,
                    Manager = manager

                };
            context.Collarborators.Add(collab);
            context.SaveChanges();
        }
    }
}