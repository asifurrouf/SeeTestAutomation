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

        public static Boolean VerifyLessonNumber(AutomationAgent notebookAutomationAgent, string lessonNumber)
        {
            string lessonDetails = notebookAutomationAgent.GetElementText("LessonView", "LessonNumber");
            if (lessonDetails.Substring(lessonDetails.Length - 1).Equals(lessonNumber))
            {
                return true;
            }
            return false;
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
            if(personalNoteName!=string.Empty)
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

        public static void ClickEraserIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
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
            notebookAutomationAgent.Click("TasksTopMenuView", "NotebookSharedWorkIcon");
        }

        public static void ClickOnReceivedWork(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("ReceivedWorkView", "LatestSharedWork"); 
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

        public static void VerifyPenColorPopup(AutomationAgent notebookAutomationAgent, bool onScreen)
        {
            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "SelectColorPopup", "onScreen")));
        }

        public static void VerifyEraserPopup(AutomationAgent notebookAutomationAgent, bool onScreen)
        {
            
            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "SelectColorPopup", "onScreen")));
        
        }

        public static void ClickOnNotebookButton(AutomationAgent notebookAutomationAgent,bool onScreen )
        {
           //
            Assert.AreEqual<bool>(onScreen, bool.Parse(notebookAutomationAgent.GetElementProperty("NotebookView", "NotebookPanel", "onScreen")));
        }

        public static void ClickNoteBookEmptyPage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookTextBoxCursor");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboard");
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView","NoteBookTextBoxValue"));
            notebookAutomationAgent.ClickCoordinate(x+800, y);
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.DragElement("NotebookView", "NotebookTextBox", x, y);
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ClearPage");
         }
        public static void EditMovingTextBox(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookTextBoxCursor");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboard");
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            notebookAutomationAgent.ClickCoordinate(x + 800, y);
            notebookAutomationAgent.ClickCoordinate(x, y);
            notebookAutomationAgent.DragElement("NotebookView", "NotebookTextBox", x, y);
            Assert.IsNotNull(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookTextBoxValue"));
            //xpath for moved text box is copied 
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookMovedTextBoxValue");
            notebookAutomationAgent.Click("NoteBookTouchView", "NoteBookPredictionKeyboardBackspace");
            
          
        }

        public static void SetPersonalNoteTextBoxtoEmpty(AutomationAgent notebookAutomationAgent, string textBoxValue)
        {
            //while((notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookMovedTextBoxValue")!=string.Empty))
            notebookAutomationAgent.SendText("{BKSP}");
            notebookAutomationAgent.SendText("{BKSP}");
            Assert.IsTrue(notebookAutomationAgent.GetElementText("NoteBookTouchView", "NoteBookEditEmptyTextBox") == string.Empty);
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraserIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ClearPage");
        }

        public static void ClickEraseIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "EraseIcon");
        }

        public static string VerifySliderExists(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "EraseSlider", "enabled");
        }

        public static void ClickOnWrenchIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "WrenchIcon");
        }

        public static void VerifyDesmosTool(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "GraphingTool");
        }

        public static void VerifyUndoRedoButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "UndoRedoIcon");
        }

        public static void VerifyUndoRedoSubMenu(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "UndoIcon");
        }


        public static void ClickSharedWorkBrowserView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "SharedWorkBrowserIcon");
        }

        public static void ClickTaskNoteBookButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookWorkBrowserView", "TaskNoteBookButton");
        }

        public static void VerifyNotebookBrowserExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookWorkBrowserView", "WorkBrowserIcon");
        }

        public static void VerifyDeleteIconExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "DeleteIcon");
        }

        public static void VerifyWrenchToolSubMenuExists(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NotebookBottomMenuView", "WrenchIconSubMenuPanel");
        }

        public static void ClickOnUndoRedoIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoRedoIcon");
        }
        public static void ClickOnNotebookDrawView(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookDrawView", "DrawViewPanel");
        }

        public static void ClickTwiceTextRegion(AutomationAgent annotationAutomationAgent)
        {
            annotationAutomationAgent.Click("CommonReadContentView", "CommonReadContent", 2);

        }

        public static void DrawADot(AutomationAgent annotationAutomationAgent, int x, int y, int clickcount)
        {
            annotationAutomationAgent.ClickOnScreen(x, y, clickcount);
        }


        public static void ClickUndoRedoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoRedoIcon");
        }

        public static string VerifyRedoButtonIncative(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "RedoIcon", "enabled");
        }

        public static string VerifyUndoButtonIncative(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "UndoIcon", "enabled");
        }

        public static void ClickUndoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "UndoIcon");
        }


        public static void ClickRedoIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "RedoIcon");
        }


        public static string GetWordCountsInTextBox(AutomationAgent notebookAutomationAgent)
        {
            //return notebookAutomationAgent.GetElementText("NotebookBottomMenuView", "NotebookDrawRegion");

            //return notebookAutomationAgent.GetText("Native");
            return "Yet to implement";
        }


        public static void ClickDrawingIconInNotebook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "DrawingIcon");
        }

        public static string IsDrawingIconPopUpOpen(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DrawingIconPopup", "enabled");
        }

        public static string VerfiyDrawingIconPopUpOpen(AutomationAgent notebookAutomationAgent)
        {
            return (notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "DrawingIconPopup")).ToString();
        }

        public static void ClickAddGradeNoWifiMsg(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("UnitLibraryView", "AddGrades");
            for (int i = 0; i < 11; i++)
            {
                if (notebookAutomationAgent.GetElementProperty("SelectGradeView", "GradeButton", "enabled", i.ToString(), WaitTime.DefaultWaitTime).Equals("true"))
                {
                    notebookAutomationAgent.Click("SelectGradeView", "GradeButton", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    break;
                }
            }
            notebookAutomationAgent.Click("SelectGradeView", "ContinueButton");
        }

        public static void SendText(AutomationAgent notebookAutomationAgent, string Text)
        {
            notebookAutomationAgent.SendText(Text);
        }

        public static void Swipe(AutomationAgent notebookAutomationAgent, Direction direction, int p, int q)
        {
            //notebookAutomationAgent.Swipe(direction, p, q);
        }

        public static void ClickHandIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "HandIcon");
        }

        public static string NoInternetConnectPopupHeader(AutomationAgent notebookAutomationAgent)
        {
            return (notebookAutomationAgent.IsElementFound("LoginView", "NoInternetConnection")).ToString();
        }
        public static void ClickUsernamePasswordOkButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("LoginView", "OK");
        }

        public static string NoInternetConnectPopupBody(AutomationAgent notebookAutomationAgent)
        {
            return (notebookAutomationAgent.IsElementFound("LoginView", "NoInternetConnectionBody")).ToString();
        }

        public static void VerifyNotebookToolbarActiveInactiveIcons(AutomationAgent notebookAutomationAgent)
        {
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "FullscreenIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "HandIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "TextIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "PenIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "EraseIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "ImageIcon", "enabled").ToString()));
            // Assert.AreEqual<string>("false", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "ToolIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "BackgroundIcon", "enabled").ToString()));
            Assert.AreEqual<string>("true", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "UndoRedoIcon", "enabled").ToString()));
            Assert.AreEqual<string>("false", (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "DeleteIcon", "enabled").ToString()));
        }


        public static void SwipeTextBoxControl(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "NotebookTextBoxRegion", x, y);

        }


        public static void VerifyNotebookOpen(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementFound("NoteBookTouchView", "NoteBookRegionPanel");
        }

        public  static void VerifyNotebookNotOpen(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.VerifyElementNotFound("NoteBookTouchView", "NoteBookRegionPanel");
        }

        public static void VerifyCurrentPageNumber(AutomationAgent notebookAutomationAgent, string taskTitle, int currentPageNumber, int totalPageNumbers)
        {
           notebookAutomationAgent.VerifyElementFound("","", GetNotebookTitleWithPageNumbers(taskTitle, currentPageNumber, totalPageNumbers));
        }

        public static string GetNotebookTitleWithPageNumbers(string taskTitle, int currentPageNumber, int totalPageNumbers)
        {
            return taskTitle + " (" + currentPageNumber.ToString() + "/" + totalPageNumbers.ToString() + ")";
        }

        public static int GetWidthOfNavigationBar(AutomationAgent notebookAutomationAgent)
        {
            string[] width = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "NotebookBackgroundBlack", "width");
            return Int32.Parse(width[0]);

        }

        public static int GetWidthOfLessonTemplate(AutomationAgent notebookAutomationAgent)
        {
            string[] width = notebookAutomationAgent.GetAllValues("NotebookBottomMenuView", "DivLessonTemplate", "width");
            return Int32.Parse(width[0]);
        }

       
        public static void ClickBackButton(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("CommonReadTopMenuView", "GradeBackButton");
        }



        public static void ClickNotebookTopViewIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("CommonReadTopMenuView", "NotebookTopViewIcon");
        }

        public static string VerifyNotebookIconHighlighted(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("CommonReadTopMenuView", "NotebookHighlightedTopViewIcon").ToString();
        }


        public static void ClickNotebookTopViewIcon2(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("CommonReadTopMenuView", "NotebookTopViewIcon2");
        }

        public static string VerifyHandIconActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "HandIcon", "enabled");
        }

        public static string VerifyKeyboardPresence(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.IsElementFound("NotebookBottomMenuView", "KeyboardUIToolbar").ToString();
        }



        public static void ClickOnImageIcon(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");

        }

        public static void AddImageInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.Click("NotebookBottomMenuView", "ImageIcon");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "AddPhoto");
            notebookAutomationAgent.Click("NotebookBottomMenuView", "Album");
            for (int i = 1; i <= 100; i++)
            {
                if (notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "SelectPhoto", "enabled", i.ToString(), WaitTime.DefaultWaitTime).Equals("true"))
                {
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "SelectPhoto", i.ToString(), 1, WaitTime.DefaultWaitTime);
                    notebookAutomationAgent.Click("NotebookBottomMenuView", "UsePhoto");

                    break;
                }
            }
        }

        public static void ResizeImageInNoteBook(AutomationAgent notebookAutomationAgent)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "ResizePhoto", 100, 100);
        }        
        public static void SwipeImage(AutomationAgent notebookAutomationAgent, int x, int y)
        {
            notebookAutomationAgent.DragElement("NotebookBottomMenuView", "PhotoRegion", x, y);


        }
        public static string VerifyEraseIconActive(AutomationAgent notebookAutomationAgent)
        {
            return notebookAutomationAgent.GetElementProperty("NotebookBottomMenuView", "EraserIcon", "enabled");
        }
    }
}
