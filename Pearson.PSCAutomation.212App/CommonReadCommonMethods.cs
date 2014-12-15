using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            commonReadAutomationAgent.Click("CommonReadPageView", "GistAnnotationsLabel");
        }

        public static void VerifyAnnotationsPanelExists(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementNotFound("CommonReadAnnotationsPanelView", "EditButton");
        }

        public static void CreateAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType, string annotationText)
        {
            commonReadAutomationAgent.LongClick("CommonReadContentView", "CommonReadContent");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.Click("CommonReadContextMenuView", "AnnotateLabel");
            commonReadAutomationAgent.Sleep();
            commonReadAutomationAgent.SendText(annotationText);
        }

        public static void EditAnnotation(AutomationAgent commonReadAutomationAgent, AnnotationType annotationType)
        {
            ClickOnGistAnnotationsSideLabel(commonReadAutomationAgent);
            ClickEditButton(commonReadAutomationAgent);
            ClickDeleteButton(commonReadAutomationAgent);
        }

        public static void ClickDeleteButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "DeleteButton");
        }

        public static void ClickEditButton(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.Click("CommonReadAnnotationsPanelView", "EditButton");
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

        public static void VerifyGistAnnotationLabel(AutomationAgent commonReadAutomationAgent)
        {
            commonReadAutomationAgent.VerifyElementFound("CommonReadPageView", "GistAnnotationsLabel");
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
