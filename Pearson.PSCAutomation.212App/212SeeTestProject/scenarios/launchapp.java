//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
 *
*/
public class launchapp {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "C:\\Users\\Automation\\Documents\\SeeTestAutomation\\Pearson.PSCAutomation.212App\\212SeeTestProject";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "launchapp");
    }

    @Test
    public void testlaunchapp(){
        client.setDevice("ios_app:HCL-Kiran");
        client.launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
        client.elementSendText("NATIVE", "class=UIButton", 0, "awhite");
        client.click("default", "GistAnnotationLabel", 0, 1);
        client.longClick("default", "CourteousImage", 0, 1, 0, 0);
        client.click("default", "HighlightCourteous", 0, 1);
        client.click("default", "ShareButton", 0, 1);
        client.click("default", "SharedAnnotate", 0, 1);
        client.verifyElementFound("default", "SharedAnnotateText", 0);
        client.click("default", "NewWordItem", 0, 1);
        client.click("default", "VellumModeClear", 0, 1);
        client.verifyElementFound("default", "VellumModeClearAll", 0);
        client.dragCoordinates(1050, 600, 1150, 600, 2000);
        client.dragCoordinates(1050, 600, 1100, 700, 2000);
        client.dragCoordinates(1100, 700, 1150, 600, 2000);
        client.dragCoordinates(1050, 600, 1100, 500, 2000);
        client.dragCoordinates(1100, 500, 1150, 600, 2000);
        client.dragCoordinates(1100, 700, 1100, 500, 2000);
        client.verifyElementFound("default", "DiamondImageDrawnInCR", 0);
        client.sendText("{BKSP}");
    }

    @After
    public void tearDown(){
        client.generateReport(true);
    }
}
