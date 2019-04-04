using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using Selenium.SpecFlow.Framework.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium.SpecFlow.Framework.StepDefinitions
{
    [Binding]
    public class BugStatusStep
    {
        private ContextObject _context;
        private IObjectContainer _container;

        RestClient client;
        RestRequest request;
        IRestResponse response;
        public string user;

        public BugStatusStep(ContextObject context, IObjectContainer container)
        {
            _context = context;
            _container = container;
        }

        [Given(@"I have requested usernames")]
        public void GivenIHaveRequestedUsernames()
        {
            client = new RestClient("http://platform12-api.azurewebsites.net/api");
            request = new RestRequest("/GetAllNames");
            response = client.Execute(request);
            String text = response.Content;
            Console.WriteLine(text);
            user = "CYRA";

        }

        [When(@"I have passed them to the web UI")]
        public void WhenIHavePassedThemToTheWebUI()
        {
            // ScenarioContext.Current.Pending();
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://platform12.azurewebsites.net/");
            driver.FindElement(By.Id("nameEntered")).SendKeys(user);
            driver.FindElement(By.Id("button_search")).Click();

            driver.SwitchTo().Frame("result");
            Thread.Sleep(3000);
            string tot = driver.FindElement(By.Id("NumTot")).Text;
            string time = driver.FindElement(By.Id("TatAll")).Text;

            Assert.AreEqual("3", tot);
            Assert.AreEqual("151.8", time);
            driver.Quit();
        }

        [Then(@"I will get total number of bugs")]
        public void ThenIWillGetTotalNumberOfBugs()
        {
           // ScenarioContext.Current.Pending();
        }

    }
}
