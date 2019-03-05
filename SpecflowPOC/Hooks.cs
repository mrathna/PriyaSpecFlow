using AventStack.ExtentReports;
using AventStack.ExtentReports.Core;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecflowPOC
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private static ExtentTest _featureName;
        private static ExtentTest _scenerioName;
        private static ExtentReports _extent;
        public IWebDriver _driver;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void IntializeReport()
        {
            string filePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Hooks)).Location), @"..\..\"));
            string fileName = "Automation_Report" + System.DateTime.Now.Millisecond;
            string savePath = filePath + @"Reports\"  + fileName + ".html";
            ExtentHtmlReporter htmlreport = new ExtentHtmlReporter(savePath);
            htmlreport.AnalysisStrategy = AnalysisStrategy.BDD;
            htmlreport.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlreport.Config.DocumentTitle = "Automation Testing Report";
            htmlreport.Config.ReportName = "SampleReport";
            htmlreport.Config.EnableTimeline = true;
            _extent = new ExtentReports();
            _extent.AttachReporter(htmlreport);
        }

        [AfterTestRun]
        public static void CloseReport()
        {
            _extent.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _featureName = _extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var browser = ConfigurationManager.AppSettings["browser"];
            switch(browser)
            {
                case "IE":
                    _driver = new InternetExplorerDriver();
                    break;
                case "Chrome":
                    _driver = new ChromeDriver();
                    break;
                case "Firefox":
                    _driver = new FirefoxDriver();
                    break;
            }
            //TODO: implement logic that has to run before executing each scenario
            
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
            _driver.Manage().Window.Maximize();
            _scenerioName = _featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            _driver.Quit();
        }

        [AfterStep]
        public void AfterStep()
        {
            //Screenshots
            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            string filePath = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(Hooks)).Location), @"..\..\"));
            string fileName = ScenarioContext.Current.ScenarioInfo.Title + System.DateTime.Now.Millisecond;
            string fullFilePath = filePath + @"\Screenshots\" + fileName + ".png";
            ss.SaveAsFile(fullFilePath, ScreenshotImageFormat.Png);

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
            {
                if (stepType == "Given")
                {
                    _scenerioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending");
                }
                else if (stepType == "When")
                {
                    _scenerioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending");
                }
                else if (stepType == "And")
                {
                    _scenerioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending");
                }
                else if (stepType == "Then")
                {
                    _scenerioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition is Pending");
                }
            }
            else
            {
                if (ScenarioContext.Current.TestError == null)
                {
                    if (stepType == "Given")
                    {
                        _scenerioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                    }
                    else if (stepType == "When")
                    {
                        _scenerioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                    }
                    else if (stepType == "And")
                    {
                        _scenerioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                    }
                    else if (stepType == "Then")
                    {
                        _scenerioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass("Pass");
                    }
                }
                else if (ScenarioContext.Current.TestError != null)
                {
                    if (stepType == "Given")
                    {
                        _scenerioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).AddScreenCaptureFromPath(fullFilePath);                         
                    }
                    else if (stepType == "When")
                    {
                        _scenerioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).AddScreenCaptureFromPath(fullFilePath);         
                    }
                    else if (stepType == "And")
                    {
                        _scenerioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException).AddScreenCaptureFromPath(fullFilePath);                            
                    }
                    else if (stepType == "Then")
                    {
                        _scenerioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message).AddScreenCaptureFromPath(fullFilePath);
                    }

                }
            }
        }
    }
}
