using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowPOC.CommonUtil;

namespace SpecflowPOC.Pages
{
    class HomePage
    {
        #region Fields
        IWebDriver _driver;
        #endregion

        #region Constructor
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Locators
        [FindsBy(How = How.Id, Using = "menu-toggle")]
        private IWebElement Mainmenu_lnk { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text() = 'Login']")]
        private IWebElement Login_lnk { get; set; }
        #endregion

        #region Methods
        public void ClickOnLoginLink()
        {
            Mainmenu_lnk.ClickOnElement();
            Login_lnk.ClickOnElement();
        }
        #endregion
    }
}
