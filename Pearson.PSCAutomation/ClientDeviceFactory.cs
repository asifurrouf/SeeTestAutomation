using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.IO;
using experitestClient;


namespace Pearson.PSCAutomation.Framework
{
    public class ClientDeviceFactory
    {
        private static List<ClientDevice> clientDevices=null;
        private static ClientDevice clientDeviceInstance;
        private static object objLock = new object();
        private static ClientDevice GetAvailableClientDevice()
        {
            clientDeviceInstance = null;
            lock (objLock)
            {
                while (clientDeviceInstance == null)
                {
                    clientDeviceInstance = clientDevices.Where(clientdevice => clientdevice.IsClientReady == true).FirstOrDefault();
                    System.Threading.Thread.Sleep(1000);
                }
                clientDeviceInstance.IsClientReady = false;
            }
            return clientDeviceInstance;
        }
        public static ClientDevice AvailableClientDevice
        {
            get
            {
                if(clientDevices==null)
                {
                    PopulateClientDevices();                    
                }
                return GetAvailableClientDevice();
            }
        }
        private static void PopulateClientDevices()
        {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var xmlfilepath = Path.Combine(outPutDirectory, "Xml\\Devices.xml");
            string xmlfile_path = new Uri(xmlfilepath).LocalPath;
            IEnumerable<XElement> rootXElement = XElement.Load(xmlfile_path).Elements("OS").Where(os => os.Attribute("OSName").Value == ConfigurationManager.AppSettings["OS"].ToString()).Where(device => device.Attribute("IsDeviceAvailable").Value=="true");
            foreach(XElement deviceXElement in rootXElement)
            {
                clientDevices.Add(new ClientDevice(deviceXElement));
            }
        }
    }
}
