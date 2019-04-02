using BoDi;
using Selenium.SpecFlow.Framework.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Selenium.SpecFlow.Framework.StepDefinitions
{
    [Binding]
    public class BugStatusStep
    {
        private ContextObject _context;
        private IObjectContainer _container;

        public BugStatusStep(ContextObject context, IObjectContainer container)
        {
            _context = context;
            _container = container;
        }
    }
}
