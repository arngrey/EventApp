using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Configuration;
using System.IO;
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
