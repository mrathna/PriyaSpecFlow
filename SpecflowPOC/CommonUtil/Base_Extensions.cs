using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPOC.CommonUtil
{
    public static class Base_Extensions
    {
        public static void EnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        public static void ClickOnElement(this IWebElement element)
        {
            element.Click();
        }

        public static bool IsDisplayed(this IWebElement element)
        {
            bool result;
            try
            {
                result = element.Displayed;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static bool CompareText(this IWebElement element,string text)
        {
            bool result;

            if (element.Text == text)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public static void WaitForElement(this IWebElement element)
        {
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele) =>
            {
                if (ele.Enabled)
                {
                    return true;
                }
                return false;
            });
            wait.Until(waiter);
        }
    }
}
