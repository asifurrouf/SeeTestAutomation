using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Reflection;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    [TestClass]
    public class CommonReadTests
    {
        public AutomationAgent commonReadAutomationAgent;

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1005)]
        [Priority(1)]
        [Owner("Kiran Kumar Anantapalli(kiran.anantapalli)")]
        public void PinchOutInVellumMode()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1005:Pinch out in Vellum mode on a common read"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                Assert.IsFalse(NavigationCommonMethods.PinchOutOnScreen(commonReadAutomationAgent));
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1006)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib")]
        public void EReaderZoomInAndZoomOut()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1006:Zoom In and Zoom Out on a common read"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyAnnotationsPanelExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1293)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void VerifyTypingAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1293:When typing in the annotation screen, the typed words should display"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1267)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void VerifyZoomInSelectingDrawingTools()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1267:Vellum mode- Book is zoomed in when user tap in drawing/ erasing/clearing popups or toolbar"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1185)]
        [Priority(1)]
        [Owner("Md. Saquib(msaqib)")]
        public void VerifyConfirmationDeletingAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1185:Confirmation popup for deleting annotations"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                CommonReadCommonMethods.EditAnnotation(commonReadAutomationAgent, AnnotationType.Gist);

                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Annotation Tests")]
        [WorkItem(8317)]
        [Priority(1)]
        [Owner("Isha Jain(isha.jain)")]
        public void SharedAnnotationVisibleToReceiver()
        {
            try
            {
                using (commonReadAutomationAgent = new AutomationAgent("TC8317: Verify that shared annotation is present in the work browser with whom the annotation is shared"))
                {

                    //NavigationCommonMethods.Login(commonReadAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                    //System.Threading.Thread.Sleep(1000);
                    //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    //CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnTextToAnnotate(commonReadAutomationAgent);
                    //System.Threading.Thread.Sleep(2000);
                    //CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    //NotebookCommonMethods.EnterTextInNotebook(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnHighlightedAnnotate(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnShareAnnotateButton(commonReadAutomationAgent);
                    //NotebookCommonMethods.SelectTeacherNotebookShare(commonReadAutomationAgent);
                    //NotebookCommonMethods.ClickSendNotebookShare(commonReadAutomationAgent);
                    //NotebookCommonMethods.ConfirmNotebookShare(commonReadAutomationAgent);
                    //NotebookCommonMethods.ConfirmNotebookShare(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    //NavigationCommonMethods.Logout(commonReadAutomationAgent);


                    //NavigationCommonMethods.Login(annotationAutomationAgent, "efoster16", "sch00lnet");
                    //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    //CommonReadCommonMethods.ClickOnSharedWorkIcon(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnShareAnnotateAsReceiver(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickToDownloadNewAnnotationAsReceiver(commonReadAutomationAgent);
                    //System.Threading.Thread.Sleep(5000);
                    //CommonReadCommonMethods.ClickOnAnnotationAsReceiver(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnSharedByAnnotation(commonReadAutomationAgent);
                    //CommonReadCommonMethods.VerifySharedAnnotationTextFound(commonReadAutomationAgent);
                    //CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    //NavigationCommonMethods.Logout(commonReadAutomationAgent);

                    //NavigationCommonMethods.Login(commonReadAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                    //System.Threading.Thread.Sleep(1000);
                    //NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    //CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnHighlightedAnnotate(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickEditButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
      
                }

            }
            catch (AssertFailedException ex)
            {
                commonReadAutomationAgent.CaptureScreenshot(ex.Message);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
                commonReadAutomationAgent.GenerateReportAndReleaseClient();
                throw ex;
            }
            catch (Exception ex)
            {
                commonReadAutomationAgent.CaptureScreenshot(ex.Message);
                commonReadAutomationAgent.GetDeviceLog();
                NavigationCommonMethods.LogoutOnExceptionAndReleaseClient(commonReadAutomationAgent);
                throw ex;
            }
        }

    }
}
