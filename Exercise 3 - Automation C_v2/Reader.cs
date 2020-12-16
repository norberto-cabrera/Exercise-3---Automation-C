using System.Configuration;
using System.Reflection;


namespace Exercise_3___Automation_C_v2
{
    class Reader
    {
        public string url;
        public string user;
        public string password;
        public string search1;
        public string search2;

        public void read() 
        {
            Assembly me = Assembly.GetExecutingAssembly();
            Configuration config = ConfigurationManager.OpenExeConfiguration(me.ManifestModule.Assembly.Location);
            url = config.AppSettings.Settings["URL"].Value;
            user = config.AppSettings.Settings["user"].Value;
            password = config.AppSettings.Settings["password"].Value;
            search1 = config.AppSettings.Settings["search1"].Value;
            search2 = config.AppSettings.Settings["search2"].Value;
        }
    }
}
