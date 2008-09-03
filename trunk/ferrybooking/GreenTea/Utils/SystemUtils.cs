using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NHibernate.Cfg;
using System.Data.SqlClient;

namespace GreenTea.Utils
{
    public class SystemUtils
    {
        public static string GetBinPath()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string relativeSearchPath = AppDomain.CurrentDomain.RelativeSearchPath;
            string binPath = relativeSearchPath == null ? baseDir : Path.Combine(baseDir, relativeSearchPath);
            return binPath;
        }

        public static SqlConnectionStringBuilder GetConnectionString()
        {
            string cnn = new Configuration().Configure().Properties["connection.connection_string"].ToString();
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(cnn);
            return scsb;
        }
    }
}
