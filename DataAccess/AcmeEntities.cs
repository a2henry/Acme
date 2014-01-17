using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.DataAccess
{
    public partial class AcmeEntities
    {
         static string GetEntityString()
        {

            string sqlConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            //   entityBuilder.Provider = "System.Data.EntityClient";
            entityBuilder.ProviderConnectionString = sqlConnectionString;
            entityBuilder.Metadata = @"res://*/Acme.csdl|res://*/Acme.ssdl|res://*/Acme.msl";
            return entityBuilder.ToString();

        }
    }
}
