//package <set your test package>;
import com.experitest.client.*;
import org.junit.*;
/**
 *
 *
*/
public class Untitled {
    private String host = "localhost";
    private int port = 8889;
    private String projectBaseDirectory = "C:\\Automation\\SeeTestAutomationUI_11-18";
    protected Client client = null;

    @Before
    public void setUp(){
        client = new Client(host, port, true);
        client.setProjectBaseDirectory(projectBaseDirectory);
        client.setReporter("xml", "reports", "launchapp");
    }

    @Test
    public void testlaunchapp(){
        client.setDevice("ios_app:Lab13-ipadmini");
        client.launch("com.pearson.commoncore.f-UpgradeTesting", true, false);
        client.elementSendText("NATIVE", "class=UIButton", 0, "awhite");
    }

    @After
    public void tearDown(){
        client.generateReport(true);
    }
}
