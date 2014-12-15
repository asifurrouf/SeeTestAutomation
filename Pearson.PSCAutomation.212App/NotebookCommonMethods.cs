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
    public static class NotebookCommonMethods
    {
        public static void ClickOnNotebookIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "NotebookIcon");
        }

        public static void AddNewNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "AddNewPage");
        }

        public static void ClickLeftArrowIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "LeftArrow");
        }

        public static void ClickRightArrowIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "RightArrow");
        }

        public static void DeleteNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DeleteIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ContinueLabel");
        }

        public static void VerifyLeftArrowNotExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "LeftArrow");
        }

        public static void VerifyRightArrowNotExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "RightArrow");
        }

        public static string GetDeleteIconEnabledStatus(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DeleteIcon", "enabled");
        }

        public static void VerifyTaskNotebookFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookTopMenuView", "TaskNotebookName");
        }

        public static void NotebookWorkBrowserView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserIcon");
        }

        public static void ClickPersonalNotesLink(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "PersonalNotes");
        }

        public static void ClickReceivedNotebookLink(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "ReceivedNotebook");
        }

        public static void ClickWorkBrowserButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "WorkBrowserButton");
        }

        public static void VerifyPersonalNoteLinkPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "PersonalNotes");
        }

        public static void OpenExistingPersonalNotes(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNotesTitle");
        }

        public static void VerifyPersonalNotesTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesTopView", "PersonalNotesTitle");
        }

        public static void CurrentTaskFourTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "TaskFourTitle");
        }

        public static void CurrentTaskOneTitle(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "TaskOneTitle");
        }

        public static void VerifyReceivedNotebookLinkPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "ReceivedNotebook");
        }

        public static void VerifyWorkBrowserButtonPresent(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "WorkBrowserButton");
        }

        public static void VerifyWorkBrowserOverlayFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("WorkBrowserView", "WorkBrowserTitle");
        }

        public static void ClickCreateNoteInPersonalNote(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCreateNote");

        }
        public static void ClickPersonalNoteCreateButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCreateButton");
        }

        public static void SetNameToPersonalNote(AutomationAgent notebookAutomationAgent, string personalNoteName)
        {
            if (personalNoteName != string.Empty)
                notebookAutomationAgent.SetText("PersonalNotesView", "PersonalNoteNameTextbox", personalNoteName);
            else
                notebookAutomationAgent.SendText("{BKSP}");
        }

        public static void VerifyPersonalNoteFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("PersonalNotesTopView", "PersonalNoteName");
        }

        public static void CancelDeleteNotebookPage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DeleteIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "CancelLabel");
        }

        public static void CreatetextboxInsideNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "NotebookPanel");
            notebookAutomationAgent.Click("NotebookView", "NotebookTextBox");
        }

        public static void ClickTextIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "TextIcon");
        }

        public static void EnterTextInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "AlphabetE");
            notebookAutomationAgent.Click("NotebookView", "AlphabetS");
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "CloseKeyboard");
        }

        public static void ClickPenIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "PenIcon");
        }

        public static void VerifyTextInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "Enteredtext");
        }

        public static void RemovetextFromNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "RemoveText");
            notebookAutomationAgent.Click("NotebookView", "NotebookBoundingRemove");
        }

        public static void ClickShareNotebookIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "ShareIcon");
        }

        public static void SelectTeacherNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "TeacherRow");
        }

        public static void ClickNextNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "NextButton");
        }

        public static void ClickSendNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("SelectRecipientsView", "SendButton");
        }

        public static void EnterSharingMessage(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
            notebookAutomationAgent.Click("NotebookView", "AlphabetE");
            notebookAutomationAgent.Click("NotebookView", "AlphabetS");
            notebookAutomationAgent.Click("NotebookView", "AlphabetT");
        }

        public static void ConfirmNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("PopUpView", "NotebookShareMessage");
            notebookAutomationAgent.Click("PopUpView", "NotebookShareOkLabel");
        }

        public static void SuccessNotebookShare(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("PopUpView", "NotebookShareSuccessMessage");
            notebookAutomationAgent.Click("PopUpView", "NotebookShareOkLabel");
        }

        public static void ClickOnSharedWorkIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("TasksTopMenuView", "SharedWorkIcon");
        }

        public static void ClickOnReceivedWork(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("ReceivedWorkView", "LatestSharedWork");
        }

        public static void VerifyTextInComment(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "CommentText");
        }

        public static void VerifyStudentNameInComment(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookView", "StudentName");
        }

        public static void VerifyCommentTextNotFoundInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookView", "CommentText");
        }

        public static void VerifyCommentIconNotFoundInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NotebookTopMenuView", "CommentIcon");
        }

        public static void ClickCommentIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookTopMenuView", "CommentIcon");
        }

        public static void ReceivedWorkOverlayFound(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("ReceivedWorkView", "ReceivedWorkTitle");
        }


        public static int GetCountAssociated(AutomationAgent notebookAutomationAgent, string notesType)
        {
            if (notesType == "ReceivedNotes")
            {
                string text = notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "ReceivedNotebook", "text");
                return int.Parse(text.Substring(text.IndexOf('('), text.IndexOf(')') - text.IndexOf('(')));
            }
            else if (notesType == "PersonalNotes")
            {
                string text = notebookAutomationAgent.GetElementProperty("NotebookWorkBrowserView", "PersonalNotes", "text");
                return int.Parse(text.Substring(text.IndexOf('('), text.IndexOf(')') - text.IndexOf('(')));
            }
            else
            {
                return 0;
            }

        }

        public static void VerifyPersonalNoteCreateButtonStatus(AutomationAgent notebookAutomationAgent, bool enabled)
        {
            Assert.AreEqual<bool>(enabled, bool.Parse(notebookAutomationAgent.GetElementProperty("PersonalNotesView", "PersonalNoteCreateButton", "enabled")));
        }

        public static void ClickCancelPersonalNoteCrate(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("PersonalNotesView", "PersonalNoteCancelButton");
        }

        public static void VerifyPersonalNoteTitle(AutomationAgent notebookAutomationAgent, string name)
        {
            Assert.AreEqual<string>(name, notebookAutomationAgent.GetElementProperty("PersonalNotesTopView", "PersonalNoteName", "text"));
        }
    }
}
