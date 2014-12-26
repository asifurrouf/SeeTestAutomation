using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pearson.PSCAutomation.Framework;
using experitestClient;

namespace Pearson.PSCAutomation._212App
{
    public static class CommonReadCommonMethods
    {
        public static void OpenCommonRead(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("LessonView", "EreaderDiv");
        }

        public static void ToggleVellumMode(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumMode");
        }

        public static bool PinchOutOnScreen(AutomationAgent commonReadAutomationAgent)
        {
            return commonReadAutomationAgent.PinchOut();
        }

        public static void ClickOnDoneButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadTopMenuView", "DoneButton");
        }


        public  static void ClickOnGistAnnotationsSideLabel(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadPageView", "GistAnnotationsSticky");
        }

        public static void VerifyAnnotationEditButtonExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadAnnotationsPanelView", "EditButton");
        }

        public static void CreateAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string annotationText)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "CourteousImage");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.SendText(annotationText);
        }

        public static void CreateAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToAnnotate, string annotationText)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.SendText(annotationText);
        }


        public static void SelectTextAndCreateAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string textToSelect, string annotationText)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToSelect);
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.SendText(annotationText);
        }

        public static void EditAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType)
        {
            ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
            ClickEditButton(commonReadAutomationAgent);
        }

        public static void ClickDeleteButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "DeleteButton");
        }

        public static void ClickEditButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "EditButton");
            commonReadAutomationAgent.Sleep();
        }

        public static void ClickOnAnnotationLink(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadAnnotationsView", "AnnotationLink");
        }

        public static void ClickOnCommonRead(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadAnnotationsView", "CommonReadImage");
        }

        public static void ClickOnTextToAnnotate(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.LongClick("CommonReadAnnotationsView", "CourteousImage");
        }

        public static void ClickOnHighlightedAnnotate(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.LongClick("CommonReadAnnotationsView", "HighlightCourteous");
        }

        public static void ClickOnShareAnnotateButton(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadAnnotationsView", "ShareAnnotation");
        }

        public static void ClickOnSharedWorkIcon(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("TasksTopMenuView", "SharedWorkIcon");
        }

        public static void ClickOnShareAnnotateAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "LatestAnnotationShare");
        }

        public static void ClickToDownloadNewAnnotationAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "DownloadAnnotation");
        }

        public static void ClickOnAnnotationAsReceiver(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("ReceivedWorkView", "DownloadAnnotation");
        }

        public static void ClickOnSharedByAnnotation(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadPageView", "SharedAnnotation");
        }

        public static void VerifySharedAnnotationTextFound(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.VerifyElementFound("CommonReadPageView", "SharedTextAnnotation");
        }

        public static void VerifyGistAnnotationStickyExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadPageView", "GistAnnotationsSticky");
        }

        public static void VerifyGistAnnotationStickyNotExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadPageView", "GistAnnotationsSticky");
        }

        public static void ClickOnLeftArrow(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContentView", "LeftArrow");
        }

        public static void ClickOnRightArrow(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContentView", "RightArrow");
        }

        public static void VerifyTimeStamp(AutomationAgent commonReadAutomationAgent, string dateTime)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsPanelView", "TimeStampLabel", dateTime);
        }

        public static void VerifyAnnotationTextFound(AutomationAgent commonReadAutomationAgent, string enteredText)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsView", "AnnotationsTextEntered", enteredText);
        }


        public static void ClickCancelButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "CancelButton");
        }

        public static void ClickContinueButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "ContinueButton");
        }

        public static void ClickonPenTool(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModePenTool");
        }

        public static void ClickOnPenOptionsPopup(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModePenPopups");
        }

        public static void ClickClearAllButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModeClearAll");
        }

        public static void ClickClearButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "VellumModeClear");
        }

        public static void VerifyClearAllButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumModeClearAll");
        }
        
        public static void DrawDiamondImage(AutomationAgent commonReadAutomationAgent, int startingX1, int startingY1)
        {
            commonReadAutomationAgent.DrawDiamondImage(startingX1, startingY1);
        }
        
        public static void VerifyDiamondImageExistsInCR(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "DiamondImageDrawnInCR");
        }

        public static void VerifyDiamondImageNotExistsInCR(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadSideMenuView", "DiamondImageDrawnInCR");
        }

        public static void LongClickOnText(AutomationAgent commonReadAutomationAgent, string textToAnnotate)
        {
            commonReadAutomationAgent.LongClick("CommonReadAnnotationsView", "TextToAnnotate", textToAnnotate);
            commonReadAutomationAgent.Sleep();
        }

        public  static void VerifyAnnotateButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "AnnotateButton");
        }

        public static void ClickAnnotationsLayerToggleButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
        }

        public static void VerifyAnnotationsOffMessage(AutomationAgent commonReadAutomationAgent)
        {
            //Assert.AreEqual<string>("Highlight & Annotation Layer: OFF", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text",10) + " " + commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOff", "text",10));
            Assert.AreEqual<string>("Highlight & Annotation Layer:", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text", 10));
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            Assert.AreEqual<string>("OFF", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOff", "text", 10));
        }

        public static void VerifyAnnotationsOnMessage(AutomationAgent commonReadAutomationAgent)
        {
            //Assert.AreEqual<string>("Highlight & Annotation Layer: ON", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text",10) + " " + commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOn", "text",10));
            Assert.AreEqual<string>("Highlight & Annotation Layer:", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerMessage", "text", 10));
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            commonReadAutomationAgent.Click("CommonReadSideMenuView", "AnnotationButton");
            Assert.AreEqual<string>("ON", commonReadAutomationAgent.GetElementProperty("CommonReadSideMenuView", "AnnotationsLayerOn", "text", 10));
        }

        public static void VerifyClearButtonExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadSideMenuView", "VellumModeClear");
        }

        public static void ClickOnAnnotatedText(AutomationAgent commonReadAutomationAgent, string annotatedText)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsView", "TextToAnnotate", annotatedText);
            commonReadAutomationAgent.Sleep();
        }

        public static void AppendToAnnotationText(AutomationAgent commonReadAutomationAgent, string addedText)
        {
            commonReadAutomationAgent.SendText(addedText);
        }

        public static void VerifyAnnotationTextSaved(AutomationAgent commonReadAutomationAgent, string savedText)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadAnnotationsView", "AnnotationsTextSaved", savedText);
        }

        public static void ClickCopyButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "CopyButton");
        }

        public static void ClickAnnotateButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateButton");
        }

        internal static void PasteText(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.SendText("{PASTE}");
        }

        public static void ClickOkButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "OkButton");
        }

        public static void VerifyExistingAnnotationMessage(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadContextMenuView", "ExistingAnnotatioinMessage");
        }

        public static void ClickHighlightButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "HighlightButton");
        }
    }

    public enum AnnotationType
    {
        Gist,
        NewThinking,
        NewWord,
        Other
    }
}
