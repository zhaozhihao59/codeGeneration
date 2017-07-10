using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeGeneration
{
    [Serializable]
  public class DataModel
    {
        private string huihua;

        public string ShowText { get; set; }

        public string Huihua
        {
            get { return huihua; }
            set { huihua = value; }
        }
        private string dbType;

        public string DbType
        {
            get { return dbType; }
            set { dbType = value; }
        }

        private string host;

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        private string port;

        public string Port
        {
            get { return port; }
            set { port = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string dbName;

        public string DbName
        {
            get { return dbName; }
            set { dbName = value; }
        }

       
    }
}
