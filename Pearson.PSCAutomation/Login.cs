using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Configuration;

namespace Pearson.PSCAutomation.Framework
{
    public class Login
    {
        private string userName;
        private string password;
        private UserType userType;
        private string loginName;
        private int[] sectionedGrades;
        
        public Login(string loginName, string userName, string password, UserType userType, int[] sectionedGrades)
        {
            this.loginName = loginName; 
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.sectionedGrades = sectionedGrades;
        }
        
        public Login(XElement loginElement)
        {
            loginName = loginElement.Attribute("LoginName").Value;
            userName = loginElement.Element("UserName").Value;
            password = loginElement.Element("Password").Value;
            userType = (UserType) Enum.Parse(typeof(UserType), loginElement.Element("UserType").Value);
            string[] gradesStringArray = loginElement.Element("Port").Value.Split(',');
            this.sectionedGrades = new int[gradesStringArray.Length];
            for(int i=0; i<gradesStringArray.Length; i++)
            {
                sectionedGrades[i] = int.Parse( gradesStringArray[i]);
            }
        }

        public static Login GetLogin(string loginName)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Logins.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            XElement loginXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == ConfigurationManager.AppSettings["OS"].ToString()).FirstOrDefault<XElement>().Elements("Login").Where(login => login.Attribute("LoginName").Value == loginName).FirstOrDefault<XElement>();
            return new Login(loginXElement);
        }
        public static Login GetLogin(UserType userType, int sectionedGrade)
        {
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Logins.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            XElement loginXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == ConfigurationManager.AppSettings["OS"].ToString()).FirstOrDefault<XElement>().Elements("Login").Where(login => login.Element("UserType").Value== userType.ToString() && login.Element("SectionedGrades").Value.Contains(sectionedGrade.ToString())).FirstOrDefault<XElement>();
            return new Login(loginXElement);
        }
        public string UserName
        {
            get
            {
                return this.userName;
            }
        }
        public string Password
        {
            get
            {
                return this.password;
            }
        }
        public UserType UserType
        {
            get
            {
                return this.userType;
            }
        }
        public int[] SectionedGrades
        {
            get 
            {
                return this.sectionedGrades;
            }
        }
    }

    public enum UserType
    {
        Teacher,
        Student,
        Admin
    }
}
