using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace EventApp.InterfaceAdapters
{
    public static class SessionFactoryCreator
    {
        public static ISessionFactory Create()
        {
            return Fluently
                .Configure()
                .Database(
                    SQLiteConfiguration.Standard
                        .InMemory()
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly())
                )
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config)
              .Create(false, true);
        }
    }
}
