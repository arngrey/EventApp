using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;

namespace EventApp.InterfaceAdapters
{
    public static class SessionFactoryCreator
    {
        public static ISessionFactory Create()
        {
            return Fluently
                .Configure()
                .Database(
                    MySQLConfiguration.Standard
                        .ShowSql()
                        .ConnectionString(ConfigurationManager.ConnectionStrings["MySql"].ConnectionString)
                )
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<UserMap>()
                    .AddFromAssemblyOf<HobbyMap>()
                    .AddFromAssemblyOf<CampaignMap>()
                    .AddFromAssemblyOf<MessageMap>()
                )
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        private static void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            new SchemaExport(config)
              .Execute(true, true, false);
        }
    }
}
