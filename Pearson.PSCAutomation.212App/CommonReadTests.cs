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
        [Owner("Mohammed Saquib(mohammed.saquib)")]
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
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyAnnotationEditButtonExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);            
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1007)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void EReaderZoomInAndVerfiy()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1007:Disabled functionality/elements in eReader when zoomed in state"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnTextToAnnotate(commonReadAutomationAgent);
                System.Threading.Thread.Sleep(2000);
                CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 2);
                CommonReadCommonMethods.ClickOnTextToAnnotate(commonReadAutomationAgent);
                System.Threading.Thread.Sleep(2000);
                CommonReadCommonMethods.VerifyAnnotationEditButtonExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1293)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyTypingAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1293:When typing in the annotation screen, the typed words should display"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1294)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifySaveAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1294: User can save text entered into the annotation screen"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1296)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyOpeningSavedAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1296: Opening a saved annotation on common read"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.EditAnnotation(commonReadAutomationAgent, AnnotationType.Gist);
                CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1297)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBrowsingEReaderPagesAsc()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1297: Changing pages on common read (ascending pages) by using pagination (arrows)"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnRightArrow(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1298)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyBrowsingEReaderPagesDesc()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1298: Changing pages on a common read (descending pages) by tapping pagination (arrows)"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnLeftArrow(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1315)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyStickyInEReader()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1315: Sticky note will display representing the annotation"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1318)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyTimeStampInAnnotation()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1318: Saved annotations will have a time stamp"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "Test");
                DateTime currenttime = DateTime.Now;
                string currentDateTime = currenttime.ToString("MMM dd',' yyyy hh':'mm").Replace(" 0", " ");
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyTimeStamp(commonReadAutomationAgent, currentDateTime);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1267)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyZoomInSelectingDrawingTools()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1267:Vellum mode- Book is zoomed in when user tap in drawing/ erasing/clearing popups or toolbar"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.ClickonPenTool(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnPenOptionsPopup(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1185)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyConfirmationDeletingAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1185:Confirmation popup for deleting annotations"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "CLEARLY", "Test");
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);                
                CommonReadCommonMethods.EditAnnotation(commonReadAutomationAgent, AnnotationType.Gist);
                CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickCancelButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickDeleteButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickContinueButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Test");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1331)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyClearAllButtonInVellumMode()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1331:Tapping the X button will prompt a CLEAR ALL button to appear on vellum mode"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickClearButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyClearAllButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickClearAllButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1332)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyClikingClearAllButtonInVellumMode()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1332:Tapping the CLEAR ALL button will erase all drawing drawn with vellum mode"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                CommonReadCommonMethods.DrawDiamondImage(commonReadAutomationAgent, 1050, 600);
                CommonReadCommonMethods.VerifyDiamondImageExistsInCR(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickClearButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyClearAllButton(commonReadAutomationAgent);                
                CommonReadCommonMethods.ClickClearAllButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyDiamondImageNotExistsInCR(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1343)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyStickyNoteInAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1343:Sticky note will display representing the annotation"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                //Implement Annotation Type & Selecting specific text from common read
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "ATTENTIVELY", "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1363)]
        [Priority(1)]
        [Owner("Mohammed Saquib(mohammed.saquib)")]
        public void VerifyContextualMenuInAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1363:Contextual menu will appear when the user presses the annotation"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.LongClickOnText(commonReadAutomationAgent, "ACTIVELY");
                CommonReadCommonMethods.VerifyAnnotateButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1367)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyMessageTurningOffAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1367: Message 'Annotations & highlights are OFF' displays when turning off annotations"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationsOffMessage(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1368)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyTurningOffAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1368: annotations will disappear when user turns off annotation mode"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "ATTENTIVELY", "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyGistAnnotationStickyNotExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(1370)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyTuningOnAnnotationsMode()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1370: Verifying Turning on Annotations mode"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "ATTENTIVELY", "Test");
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.ClickAnnotationsLayerToggleButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationsOnMessage(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyGistAnnotationStickyExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Common Read Tests")]
        [WorkItem(238)]
        [Priority(1)]
        [Owner("Namrita Agarwal(namrita.agarwal)")]
        public void VerifyTurningOnVellumMOde()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC238: Turning on vellum mode"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.ToggleVellumMode(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyClearButtonExists(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }


        [TestMethod()]
        [TestCategory("Notebook Tests")]
        [WorkItem(2766)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void VerifyClosingNotebook()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC2766: Verify closing a notebook from commonread"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                NotebookCommonMethods.ClickOnNotebookIcon(commonReadAutomationAgent);
                NotebookCommonMethods.VerifyNotebookOpen(commonReadAutomationAgent);
                commonReadAutomationAgent.ClickOnScreen(500, 500, 1);
                NotebookCommonMethods.VerifyNotebookNotOpen(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read")]
        [WorkItem(309)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void VerifyEditingAnnotations()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC309: Verify editing Annotations in a commonread"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "ATTENTIVELY", "Annotating for verification");
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                CommonReadCommonMethods.ClickOnAnnotatedText(commonReadAutomationAgent, "ATTENTIVELY");
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.ClickEditButton(commonReadAutomationAgent);
                CommonReadCommonMethods.AppendToAnnotationText(commonReadAutomationAgent, " Added text");
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Annotating for verification Added text");
                CommonReadCommonMethods.AppendToAnnotationText(commonReadAutomationAgent, " !@#$%^&*()-_=+");
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Annotating for verification Added text !@#$%^&*()-_=+");
                CommonReadCommonMethods.AppendToAnnotationText(commonReadAutomationAgent, "{BKSP}");
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "Annotating for verification Added text !@#$%^&*()-_=");
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.ClickOnAnnotatedText(commonReadAutomationAgent, "ATTENTIVELY");
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.VerifyAnnotationTextSaved(commonReadAutomationAgent, "Annotating for verification Added text !@#$%^&*()-_=");                
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read")]
        [WorkItem(1364)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void CopyPasteAnnotatedText()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1364: Verify Copy paste in Annotations"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.LongClickOnText(commonReadAutomationAgent, "ACTIVELY");
                CommonReadCommonMethods.ClickCopyButton(commonReadAutomationAgent);
                CommonReadCommonMethods.LongClickOnText(commonReadAutomationAgent, "ACTIVELY");
                CommonReadCommonMethods.ClickAnnotateButton(commonReadAutomationAgent);
                commonReadAutomationAgent.Sleep();
                CommonReadCommonMethods.PasteText(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyAnnotationTextFound(commonReadAutomationAgent, "ACTIVELY");
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        [TestMethod()]
        [TestCategory("Common Read")]
        [WorkItem(1366)]
        [Priority(1)]
        [Owner("Shivank Laul(shivank.l)")]
        public void VerifyMessageCreatingHighlightOverAnnotation()
        {
            using (commonReadAutomationAgent = new AutomationAgent("TC1366: Message displays when trying to create a highlight over an annotation in common read"))
            {
                NavigationCommonMethods.Login(commonReadAutomationAgent, "apatton1", "sch00lnet");
                NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                CommonReadCommonMethods.OpenCommonRead(commonReadAutomationAgent);
                CommonReadCommonMethods.CreateAnnotation(commonReadAutomationAgent, AnnotationType.Gist, "CLEARLY", "Annotation Text");
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                commonReadAutomationAgent.Sleep();
                commonReadAutomationAgent.ClickCoordinate(500, 500);
                CommonReadCommonMethods.LongClickOnText(commonReadAutomationAgent, "CLEARLY");
                CommonReadCommonMethods.ClickHighlightButton(commonReadAutomationAgent);
                CommonReadCommonMethods.VerifyExistingAnnotationMessage(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOkButton(commonReadAutomationAgent);
                CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                NavigationCommonMethods.Logout(commonReadAutomationAgent);
            }
        }

        /// <summary>
        /// Incomplete
        /// </summary>
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

                    NavigationCommonMethods.Login(commonReadAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                    System.Threading.Thread.Sleep(1000);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnTextToAnnotate(commonReadAutomationAgent);
                    System.Threading.Thread.Sleep(2000);
                    CommonReadCommonMethods.ClickOnAnnotationLink(commonReadAutomationAgent);
                    NotebookCommonMethods.EnterTextInNotebook(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnHighlightedAnnotate(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnShareAnnotateButton(commonReadAutomationAgent);
                    NotebookCommonMethods.SelectTeacherNotebookShare(commonReadAutomationAgent);
                    NotebookCommonMethods.ClickSendNotebookShare(commonReadAutomationAgent);
                    NotebookCommonMethods.ConfirmNotebookShare(commonReadAutomationAgent);
                    NotebookCommonMethods.ConfirmNotebookShare(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);


                    NavigationCommonMethods.Login(commonReadAutomationAgent, "efoster16", "sch00lnet");
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    CommonReadCommonMethods.ClickOnSharedWorkIcon(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnShareAnnotateAsReceiver(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickToDownloadNewAnnotationAsReceiver(commonReadAutomationAgent);
                    System.Threading.Thread.Sleep(5000);
                    CommonReadCommonMethods.ClickOnAnnotationAsReceiver(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnSharedByAnnotation(commonReadAutomationAgent);
                    CommonReadCommonMethods.VerifySharedAnnotationTextFound(commonReadAutomationAgent);
                    CommonReadCommonMethods.ClickOnDoneButton(commonReadAutomationAgent);
                    NavigationCommonMethods.Logout(commonReadAutomationAgent);

                    NavigationCommonMethods.Login(commonReadAutomationAgent, "1102524", "sch00lnet"); //student name: Zainab Haver
                    System.Threading.Thread.Sleep(1000);
                    NavigationCommonMethods.NavigateELATaskfromSytemTrayMenu(commonReadAutomationAgent, 6, 1, 1, 4);
                    CommonReadCommonMethods.ClickOnCommonRead(commonReadAutomationAgent);
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
