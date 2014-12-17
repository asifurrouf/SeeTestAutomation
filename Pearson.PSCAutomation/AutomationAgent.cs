using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Configuration;
using experitestClient;

namespace Pearson.PSCAutomation.Framework
{
    public class AutomationAgent : IDisposable
    {
        ClientDevice clientDevice;
        Client client;
        Device device;
        string testDetails;
        string reporterFolder;
        string projectBaseDirectory;
        string appName;
        string launchingAppName;
        string osName;
        private Control control = null;
        XElement rootXElement;

        public AutomationAgent(string testDetails)
        {
            if (ConfigurationManager.AppSettings["IsParallelTestExecution"].ToString() == "true")
            {
                this.clientDevice = ClientDeviceFactory.AvailableClientDevice;
            }
            else
            {
                this.clientDevice = SingletonClientDevice.clientDevice;
                clientDevice.IsClientReady = false;
            }
            this.client = this.clientDevice.Client;
            this.device = this.clientDevice.Device;
            this.testDetails = testDetails;
            this.appName = ConfigurationManager.AppSettings["AppName"].ToString();
            this.launchingAppName = ConfigurationManager.AppSettings["LaunchingAppName"].ToString();
            this.osName = ConfigurationManager.AppSettings["OS"].ToString();
            //Load the rootXElement from controls.xml
            string startupPath = System.IO.Directory.GetCurrentDirectory();
            string outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            string xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Controls.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            this.projectBaseDirectory = new Uri(outPutDirectory + "\\" + ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString()).LocalPath;
            //this.reporterFolder = new Uri(outPutDirectory.Remove(outPutDirectory.Length - 10) + "\\" + ConfigurationManager.AppSettings["ProjectBaseDirectory"].ToString() + "\\" + ConfigurationManager.AppSettings["ReporterFolder"].ToString()).LocalPath;
            this.reporterFolder = ConfigurationManager.AppSettings["ReporterFolder"].ToString();
            this.rootXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == this.osName).FirstOrDefault<XElement>();
            InitializeClientAndLaunchApp();
        }

        #region Properites
        public ClientDevice ClientDevice
        {
            get
            {
                return this.clientDevice;
            }
        }
        public string ReporterFolder
        {
            get
            {
                return reporterFolder;
            }
        }

        public string ProjectBaseDirectory
        {
            get
            {
                return projectBaseDirectory;
            }
        }

        public string AppName
        {
            get
            {
                return appName;
            }
        }

        public string LaunchingAppName
        {
            get
            {
                return launchingAppName;
            }
        }
        public string OsName
        {
            get
            {
                return osName;
            }
        }
        #endregion

        #region AutomationAgentPrivateMethods

        /// <summary>
        /// Populates the control property of AutomationAgent for current client method execution
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        private void PopulateControl(string viewName, string controlName)
        {
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == viewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == controlName).FirstOrDefault<XElement>();
            this.control = new Control(controlXElement);
        }

        private void PopulateDynamicControl(string viewName, string controlName, string dynamicVariable)
        {
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == viewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == controlName).FirstOrDefault<XElement>();
            this.control = new Control(controlXElement);
            string updatedElement = this.control.Element.Replace("()", dynamicVariable);
            string updatedControlText = this.control.ControlText.Replace("()", dynamicVariable);
            this.control.Element = updatedElement;
            this.control.ControlText = updatedControlText;
        }
        /// <summary>
        /// Initializes the Client and Launches the App
        /// </summary>
        private void InitializeClientAndLaunchApp()
        {
            client.SetProjectBaseDirectory(ProjectBaseDirectory);
            client.SetReporter("xml", this.reporterFolder, testDetails);
            client.SetDevice(device.SeeTestDeviceName);
            client.Launch(launchingAppName, true, false);
        }
        #endregion

        #region ClientMethods
        /// <summary>
        /// Performs Click on the control with the given viewname and controlname.
        /// Default clickcount is 1 and waittime is 10 sec
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml </param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="clickCount">Default click count is 1. Provide a valid integer value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public void Click(string viewName, string controlName, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime))
            {
                // If statement
            }
            client.Click(this.control.Zone, this.control.Element, this.control.Index, clickCount);
        }

        public bool WaitforElement(string viewName, string controlName, string dynamicVariable, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            return client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }
        public void Click(string viewName, string controlName, string dynamicVariable, int clickCount = 1, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime))
            {
                // If statement
            }
            client.Click(this.control.Zone, this.control.Element, this.control.Index, clickCount);
        }

        /// <summary>
        /// Sets the Text to textbox controls
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="textToSet">Text to Set to textbox control</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public void SetText(string viewName, string controlName, string textToSet, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            client.ElementSendText(this.control.Zone, this.control.Element, this.control.Index, textToSet);
        }

        public void SendText(string text)
        {
            client.SendText(text);
        }

        public void ClickOnScreen(int x=0, int y=0, int clickCount=1)
        {
            client.ClickCoordinate(x, y, clickCount);
        }
        
        /// <summary>
        /// Waits for the Control to exist on the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Max Time to wait for the control existence</param>
        public bool WaitForElement(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }

        /// <summary>
        /// Verifies for the Element not to be found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementNotFound(string viewName, string controlName)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateControl(viewName, controlName);
            client.VerifyElementNotFound(this.control.Zone, this.control.Element, this.control.Index);
        }

        /// <summary>
        /// Verifies if an Element is found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementFound(string viewName, string controlName)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateControl(viewName, controlName);
            client.VerifyElementFound(this.control.Zone, this.control.Element, this.control.Index);
        }


        /// <summary>
        /// Verifies if an Element is found
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        public void VerifyElementFound(string viewName, string controlName, string dynamicVariable)
        {
            System.Threading.Thread.Sleep(WaitTime.DefaultWaitTime);
            this.PopulateDynamicControl(viewName, controlName, dynamicVariable);
            client.VerifyElementFound(this.control.Zone, this.control.Element, this.control.Index);
        }

        /// <summary>
        /// Waits of an Element to vanish from the screen
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        public bool WaitForElementToVanish(string viewName, string controlName, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            return client.WaitForElementToVanish(this.control.Zone, this.control.Element, this.control.Index, waitTime);
        }

        /// <summary>
        /// Gets the property of the Element
        /// </summary>
        /// <param name="viewName">Provide a valid viewname from controls.xml</param>
        /// <param name="controlName">Provide a valid controlname under the viewname from controls.xml</param>
        /// <param name="property">Property name to get the value</param>
        /// <param name="waitTime">Default wait time is 10 sec. Provide an integer representing milli seconds to wait</param>
        /// <returns>returns the property string</returns>
        public string GetElementProperty(string viewName, string controlName, string property, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            return client.ElementGetProperty(this.control.Zone, this.control.Element, this.control.Index, property);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="controlName"></param>
        /// <param name="property"></param>
        /// <param name="value"></param>
        /// <param name="waitTime"></param>
        public void GetElementProperty(string viewName, string controlName, string property, string value, int waitTime = WaitTime.DefaultWaitTime)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            client.ElementSetProperty(this.control.Zone, this.control.Element, this.control.Index, property, value);
        }

        public void LongClick(string viewName, string controlName, int clickCount=1, int X=0, int Y=0)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            client.LongClick(this.control.Zone, this.control.Element, this.control.Index, clickCount, X, Y);
        }

        public void SwipeElement(string viewName, string controlName, Direction direction, int offSet, int swipeTime)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            client.ElementSwipe(this.control.Zone, this.control.Element, this.control.Index, direction.ToString(), offSet, swipeTime);
        }

        public void Swipe(Direction direction, int offSet=500)
        {   
            client.Swipe(direction.ToString(), offSet);
        }

        public string[] GetAllValues(string viewName, string controlName, string property)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            return client.GetAllValues(this.control.Zone, this.control.Element, property);
        }

        public void RunNativeApICall(string viewName, string controlName, string script)
        {
            this.PopulateControl(viewName, controlName);
            if (client.WaitForElement(this.control.Zone, this.control.Element, this.control.Index, WaitTime.SmallWaitTime))
            {
                // If statement
            }
            client.RunNativeAPICall(this.control.Zone, this.control.Element, this.control.Index, script);
        }

        public bool IsElementFound(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return client.IsElementFound(this.control.Zone, this.control.Element);
        }
        public void DragElement(string viewName, string controlName, int xOffset, int yOffset)
        {
            this.PopulateControl(viewName, controlName);
            client.Drag(this.control.Zone, this.control.Element, this.control.Index, xOffset, yOffset);
        }

        public void DragAndDrop(string dragElementviewName, string dragElementcontrolName, string dropElementViewName, string dropElementControlName)
        {
            this.PopulateControl(dragElementviewName, dragElementcontrolName);
            XElement controlXElement = this.rootXElement.Elements("View").Where(view => view.Attribute("ViewName").Value == dropElementViewName).Elements("Control").Where(control => control.Attribute("ControlName").Value == dropElementControlName).FirstOrDefault<XElement>();
            Control dropControl = new Control(controlXElement);
            client.DragDrop(this.control.Zone, this.control.Element, this.control.Index, dropControl.ControlName, dropControl.Index);
        }

        public string GetElementText(string viewName, string controlName)
        {
            this.PopulateControl(viewName, controlName);
            return client.ElementGetText(this.control.Zone, this.control.Element, this.control.Index);
        }

        /// <summary>
        /// Performs pinch in/zoom in action on the screen at the given x & Y coordinates of the screen. Not supplying any parameters, performs pinch in at the center of the screen with a radius 100 pixels.
        /// </summary>
        /// <param name="xCoordinate">X Co ordinate where pinch in should be performed, default is 0</param>
        /// <param name="yCoordinate">Y Co ordinate where pinch in should be performed, default is 0</param>
        /// <param name="pinchRadius">Radius of pinch circle. default is 100</param>
        /// <returns>bool value indicating action success or failure</returns>
        public bool PinchIn(int xCoordinate = 0, int yCoordinate = 0, int pinchRadius = 100)
        {
            return client.Pinch(true, xCoordinate, yCoordinate, pinchRadius);
        }

        /// <summary>
        /// Performs pinch out or zoom out action on the screen at the given x and Y coordinates of the screen
        /// Not supplying any parameters, performs pinch out at the center of the screen with a radius 100 pixels.
        /// </summary>
        /// <param name="xCoordinate">X Co ordinate where pinch out should be performed default is 0</param>
        /// <param name="yCoordinate">Y Co ordinate where pinch out should be performed default is 0</param>
        /// <param name="pinchRadius">Radius of pinch out circle default is 100</param>
        /// <returns>bool value indicating action success or failure</returns>
        public bool PinchOut(int xCoordinate = 0, int yCoordinate = 0, int pinchRadius = 100)
        {
            return client.Pinch(false, xCoordinate, yCoordinate, pinchRadius);
        }
        public void InstallApp(string path)
        {
            client.Install(path, true, true);
        }

        public void UninstallApp(string appName)
        {
            client.Uninstall(appName);
        }

        public void AddDevice(string serialNumber, string deviceName)
        {
            client.AddDevice(serialNumber, deviceName);
        }

        public void CaptureScreenshot(string screenshotMessage)
        {
            client.Capture(screenshotMessage);
        }
       
       
        public void ClickCoordinate(int x, int y, int clickCount = 1)
        {
            
            client.ClickCoordinate(x, y, clickCount);
        }

        public void Sleep(int milliSeconds = WaitTime.DefaultWaitTime)
        {
            
            System.Threading.Thread.Sleep(milliSeconds);
        }
        public string GetDeviceLog()
        {
            return client.GetDeviceLog();
        }  

        #endregion

        public void GenerateReportAndReleaseClient()
        {
            this.client.GenerateReport(true);
            this.clientDevice.IsClientReady = true;
        }

        public void Dispose()
        {
            this.GenerateReportAndReleaseClient();
        }
    }
}

