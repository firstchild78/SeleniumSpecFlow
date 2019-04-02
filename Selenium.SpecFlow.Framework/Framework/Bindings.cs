using BoDi;
using OpenQA.Selenium.Chrome;
using Selenium.SpecFlow.Framework.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium.SpecFlow.Framework.Framework
{
    [Binding]
    public class Bindings
    {
        private ContextObject _context;
        private IObjectContainer _container;

        public Bindings(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void SetUp()
        {
            _context = new ContextObject();
            _container.RegisterInstanceAs(_context);
            _context.Driver = new ChromeDriver();
        }

        [AfterScenario]
        public void CleanUp()
        {
            _context.Driver.Close();
            _context.Driver.Quit();
        }
    }
}
