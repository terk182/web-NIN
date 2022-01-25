using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace web_NIN.Services
{
    public class Db_connect
    {
        
        string connection = "Data Source=pro_db.fcc.co.th;Initial Catalog=Nestle;User ID=app_nestle;Password=nestle@#2021;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
     
        public  string Db_connect_string()
        {
            
            return this.connection;
        }

    }
}
