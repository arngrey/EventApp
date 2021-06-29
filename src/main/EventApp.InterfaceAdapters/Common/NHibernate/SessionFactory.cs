using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
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
                    .AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
