using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace RPScreenshotIssue.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        public IWebDriver driver;
        public  IObjectContainer ObjectContainer;
        public FeatureContext _featureContext;
        public ScenarioContext _scenarioContext;

        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public Hooks1(ObjectContainer container, FeatureContext featureContext, ScenarioContext scenarioContext)
        {
            ObjectContainer = container;
            _featureContext = featureContext;
            _scenarioContext = scenarioContext;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
             driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            driver.Navigate().GoToUrl("https://www.google.com/");
            

        }

        [AfterScenario]
        public void AfterScenario()
        {
            var file = TakeScreenshot();
            ReportPortal.Shared.Log.Error(" this screenshot came from AfterScenario hook {rp#file#" + file + "}");
            driver.Close();
            driver.Quit();
        }

        private string TakeScreenshot()
        {
            try
            {
                Screenshot screenshot;
                string screenshotFilePath = "";
                string fileNameBase =
                    $"{DateTime.Now:yyyyMMdd_HHmmss}";


                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory());


                ITakesScreenshot takesScreenshot = ((ITakesScreenshot)driver);




                screenshot = takesScreenshot.GetScreenshot();

                screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);


                return screenshotFilePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex.Message);

                throw;
            }


        }
    }
}
