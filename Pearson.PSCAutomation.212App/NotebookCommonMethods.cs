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
            return notebookAutomationAgent.GetElementPropery("NotebookBottomMenuView", "DeleteIcon", "enabled");
        }
    }
}
