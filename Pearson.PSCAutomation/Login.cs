using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pearson.PSCAutomation.Framework
{
    public class Login
    {
        private string userName;
        private string password;
        private UserType userType;
        private int[] sectionedGrades;
        
        public Login(string userName, string password, UserType userType, int[] sectionedGrades)
        {
            this.userName = userName;
            this.password = password;
            this.userType = userType;
            this.sectionedGrades = sectionedGrades;
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
        Student
    }
}
