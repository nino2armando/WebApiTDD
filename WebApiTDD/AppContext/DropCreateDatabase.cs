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
using WebApiTDD.Models;

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

                // create all tables
                ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
           
                Seed(context);
                context.SaveChanges();

            }
            else
            {
                // create all tables
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
            context.SaveChanges();
        }
    }
}