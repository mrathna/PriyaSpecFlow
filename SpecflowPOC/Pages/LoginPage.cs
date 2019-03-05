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
    class LoginPage
    {
        #region Fields
        IWebDriver _driver;
        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Locators
        [FindsBy(How = How.Id, Using = "txt-username")]
        private IWebElement Username_txtbx { get; set; }

        [FindsBy(How = How.Id, Using = "txt-password")]
        private IWebElement Password_txtbx { get; set; }

        [FindsBy(How = How.Id, Using = "btn-login")]
        private IWebElement Login_btn { get; set; }
        #endregion

        #region Methods
        public void EnterCredentials(string _userNameTxt, string _passWordTxt)
        {
            Username_txtbx.EnterText(_userNameTxt);
            Password_txtbx.EnterText(_passWordTxt);
        }

        public void ClickLogin()
        {
            Login_btn.ClickOnElement();
        }
        #endregion
    }
}
