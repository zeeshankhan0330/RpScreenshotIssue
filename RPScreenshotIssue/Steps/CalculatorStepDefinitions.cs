using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace RPScreenshotIssue.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {



        private readonly ScenarioContext _scenarioContext;
  

        public CalculatorStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {

      
            Assert.IsTrue(false);
        }

       
    }
}
