//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
 *
*/
public class AutomationUI {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "C:\\Automation\\SeeTestAutomationUI_11-18";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "AutomationUI");
    }

    @Test
    public void testAutomationUI(){
        client.setDevice("ios_app:Lab13_Wifi");
        client.launch("com.pearson.commoncore.develop", true, false);
        client.elementSendText("NATIVE", "xpath=//*[@placeholder='User Name']", 0, "efoster16");
        client.elementSendText("NATIVE", "xpath=//*[@placeholder='Password']", 0, "sch00lnet");
        client.click("default", "Login", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 1);
        client.click("NATIVE", "xpath=(//*/*/*/*/*/*[@text='Unit Library'])[1]", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@accessibilityLabel='ELA Units' and @class='UIButton']", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='ELA Units' and @class='UIButton']", 0, 1);
        client.click("NATIVE", "xpath=//*[@text='7']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Of Speech and Silence']", 0);
        client.click("NATIVE", "xpath=//*[@text='8']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Order in the Court']", 0);
        client.click("NATIVE", "xpath=//*[@text='9']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='The Nightmare in Literature']", 0);
        client.click("NATIVE", "xpath=//*[@text='10']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Creative Nonfiction']", 0);
        client.click("NATIVE", "xpath=//*[@text='6']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Fantasy and Reality']", 0);
        client.click("NATIVE", "xpath=//*[@class='UIButton' and ./parent::*[@class='UIView'] and ./preceding-sibling::*[@text='Fantasy and Reality'] and ./preceding-sibling::*[@class='UIImageView']]", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
        client.swipe("Left", 0, 500);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='2']", 0, 10000)){
            // If statement
        }
        client.verifyElementFound("NATIVE", "xpath=//*[@text='2']", 0);
        client.swipe("Left", 0, 500);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='1']", 0, 10000)){
            // If statement
        }
        client.verifyElementFound("NATIVE", "xpath=//*[@text='1']", 0);
        client.swipe("Right", 0, 500);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='2']", 0, 10000)){
            // If statement
        }
        client.verifyElementFound("NATIVE", "xpath=//*[@text='2']", 0);
        client.swipe("Right", 0, 500);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='3']", 0, 10000)){
            // If statement
        }
        client.verifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='UnitPre button start ela' and ./following-sibling::*[@text='3']]", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=(//*/*/*/*[@class='UIButton' and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='UILabel']])[1]", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=(//*/*/*/*[@class='UIButton' and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='UILabel']])[1]", 0, 1);
        if(client.waitForElement("WEB", "xpath=//*[@nodeName='BUTTON' and ./preceding-sibling::*[./*[@text='What do you know about narrative writing?']]]", 0, 10000)){
            // If statement
        }
        client.click("WEB", "xpath=//*[@id='LessonScreen.NextButton']", 0, 1);
        client.verifyElementFound("WEB", "xpath=//*[@text='You will have 20 minutes to write your narrative.']", 0);
        client.click("WEB", "xpath=//*[@id='LessonScreen.NextButton']", 0, 1);
        client.verifyElementFound("WEB", "xpath=//*[@text='Fantasy Book Club Books' and @width>0]", 0);
        client.click("WEB", "xpath=//*[@id='LessonScreen.PreviousButton']", 0, 1);
        client.verifyElementFound("WEB", "xpath=//*[@text='You will have 20 minutes to write your narrative.']", 0);
        client.click("WEB", "xpath=//*[@id='LessonScreen.PreviousButton']", 0, 1);
        client.verifyElementFound("WEB", "xpath=//*[@text='Share with the class.']", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Teacher Mode Button']", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@text='Unit Overview']", 0, 10000)){
            // If statement
        }
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Unit Overview']", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Teacher Mode Button']", 0, 1);
        client.click("WEB", "xpath=//*[@nodeName='BUTTON' and ./preceding-sibling::*[./*[@text='What do you know about narrative writing?']]]", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook browser nonshared unr']]", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='notebook toolbar text icon']", 0, 1);
        client.click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='CCNotebookDrawView']]", 0, 1);
        client.click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./*[@text='']]", 0, 1);
        if(client.waitForElement("default", "T", 0, 10000)){
            // If statement
        }
        client.click("default", "T", 0, 1);
        client.click("default", "E", 0, 1);
        client.click("default", "S", 0, 1);
        client.click("default", "T", 0, 1);
        client.click("default", "CloseKeyboard", 0, 1);
        if(client.waitForElement("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 10000)){
            // If statement
        }
        client.click("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./*[@text='Test']]", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='notebook toolbar text icon']", 0, 1);
        client.click("NATIVE", "xpath=//*[@class='UIView' and @height>0 and ./parent::*[@class='UIView'] and ./following-sibling::*[@class='CCNotebookDrawView']]", 0, 1);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='notebook bounding remove']", 0, 1);
        client.click("NATIVE", "xpath=//*[@class='UIImageView' and ./parent::*[@accessibilityLabel='notebook toolbar pen icon']]", 0, 1);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Unit 3: Fantasy and Reality' and ./preceding-sibling::*[@text='UNIT']]", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='Fantasy and Reality']", 0);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='3']", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Back Button']", 0, 1);
        client.verifyElementFound("NATIVE", "xpath=//*[@text='ELA Units' and @class='UILabel' and ./parent::*[@class='UIView']]", 0);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Tray Button']", 0, 1);
        client.click("NATIVE", "xpath=(//*/*/*/*/*/*[@text='Unit Library'])[1]", 0, 1);
        client.click("NATIVE", "xpath=//*[@accessibilityLabel='Log Out' and @class='UIButton']", 0, 1);
    }

    @After
    public void tearDown(){
        client.generateReport(true);
    }
}
