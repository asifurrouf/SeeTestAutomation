using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using experitestClient;

namespace Experitest
{
    [TestClass]
    public class AutomationUI
    {
        private string host = "localhost";
        private int port = 8889;
        private string projectBaseDirectory = "C:\\Automation\\SeeTestAutomationUI_11-18";
        protected Client client = null;
        
        [TestInitialize()]
        public void SetupTest()
        {
            client = new Client(host, port, true);
            client.SetProjectBaseDirectory(projectBaseDirectory);
            client.SetReporter("xml", "reports", "AutomationUI");
        }

        [TestMethod]
        public void TestAutomationUI()
        {
            client.SetDevice("ios_app:Lab13_Wifi");
            client.Launch("com.pearson.commoncore.develop", true, false);
            client.ElementSendText("NATIVE", "xpath=//*[@placeholder='User Name']", 0, "efoster16");
            client.ElementSendText("NATIVE", "xpath=//*[@placeholder='Password']", 0, "sch00lnet");
            client.Click("default", "Login", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 10000)){
                  // If statement
            }
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 1);
            client.Click("NATIVE", "xpath=(//*/*/*/*/*/*[@text='Unit Library'])[1]", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@accessibilityLabel='ELA Units' and @class='UIButton']", 0, 10000)){
                  // If statement
            }
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='ELA Units' and @class='UIButton']", 0, 1);
            client.Click("NATIVE", "xpath=//*[@text='7']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Of Speech and Silence']", 0);
            client.Click("NATIVE", "xpath=//*[@text='8']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Order in the Court']", 0);
            client.Click("NATIVE", "xpath=//*[@text='9']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='The Nightmare in Literature']", 0);
            client.Click("NATIVE", "xpath=//*[@text='10']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Creative Nonfiction']", 0);
            client.Click("NATIVE", "xpath=//*[@text='6']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Fantasy and Reality']", 0);
            client.Click("NATIVE", "xpath=//*[@class='UIButton' and ./parent::*[@class='UIView'] and ./preceding-sibling::*[@text='Fantasy and Reality'] and ./preceding-sibling::*[@class='UIImageView']]", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
            client.Swipe("Left", 0, 500);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='2']", 0, 10000)){
                  // If statement
            }
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='2']", 0);
            client.Swipe("Left", 0, 500);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='1']", 0, 10000)){
                  // If statement
            }
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='1']", 0);
            client.Swipe("Right", 0, 500);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='2']", 0, 10000)){
                  // If statement
            }
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='2']", 0);
            client.Swipe("Right", 0, 500);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='3']", 0, 10000)){
                  // If statement
            }
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='UnitPre button start ela' and ./following-sibling::*[@text='3']]", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=(//*/*/*/*[@class='UIButton' and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='UILabel']])[1]", 0, 10000)){
                  // If statement
            }
            client.Click("NATIVE", "xpath=(//*/*/*/*[@class='UIButton' and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='UILabel']])[1]", 0, 1);
            if(client.WaitForElement("WEB", "xpath=//*[@nodeName='BUTTON' and ./preceding-sibling::*[./*[@text='What do you know about narrative writing?']]]", 0, 10000)){
                  // If statement
            }
            client.Click("WEB", "xpath=//*[@id='LessonScreen.NextButton']", 0, 1);
            client.VerifyElementFound("WEB", "xpath=//*[@text='You will have 20 minutes to write your narrative.']", 0);
            client.Click("WEB", "xpath=//*[@id='LessonScreen.NextButton']", 0, 1);
            client.VerifyElementFound("WEB", "xpath=//*[@text='Fantasy Book Club Books' and @width>0]", 0);
            client.Click("WEB", "xpath=//*[@id='LessonScreen.PreviousButton']", 0, 1);
            client.VerifyElementFound("WEB", "xpath=//*[@text='You will have 20 minutes to write your narrative.']", 0);
            client.Click("WEB", "xpath=//*[@id='LessonScreen.PreviousButton']", 0, 1);
            client.VerifyElementFound("WEB", "xpath=//*[@text='Share with the class.']", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Teacher Mode Button']", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@text='Unit Overview']", 0, 10000)){
                  // If statement
            }
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Unit Overview']", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Teacher Mode Button']", 0, 1);
            client.Click("WEB", "xpath=//*[@nodeName='BUTTON' and ./preceding-sibling::*[./*[@text='What do you know about narrative writing?']]]", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook browser nonshared unr']]", 0, 10000)){
                  // If statement
            }
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='notebook toolbar text icon']", 0, 1);
            client.Click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='CCNotebookDrawView']]", 0, 1);
            client.Click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./*[@text='']]", 0, 1);
            if(client.WaitForElement("default", "T", 0, 10000)){
                  // If statement
            }
            client.Click("default", "T", 0, 1);
            client.Click("default", "E", 0, 1);
            client.Click("default", "S", 0, 1);
            client.Click("default", "T", 0, 1);
            client.Click("default", "CloseKeyboard", 0, 1);
            if(client.WaitForElement("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 10000)){
                  // If statement
            }
            client.Click("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./*[@text='Test']]", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='notebook toolbar text icon']", 0, 1);
            client.Click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='CCNotebookDrawView']]", 0, 1);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='notebook bounding remove']", 0, 1);
            client.Click("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 1);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Unit 3: Fantasy and Reality' and ./preceding-sibling::*[@text='UNIT']]", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='Fantasy and Reality']", 0);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
            client.VerifyElementFound("NATIVE", "xpath=//*[@text='ELA Units' and @class='UILabel' and ./parent::*[@class='UIView']]", 0);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 1);
            client.Click("NATIVE", "xpath=(//*/*/*/*/*/*[@text='Unit Library'])[1]", 0, 1);
            client.Click("NATIVE", "xpath=//*[@accessibilityLabel='Log Out' and @class='UIButton']", 0, 1);
        }

        [TestCleanup()]
        public void TearDown()
        {
            client.GenerateReport(true);
        }
    }
}