using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium.SpecFlow.Framework.DataModel
{
    public class ContextObject
    {
        public User User { get; set; }
        public IWebDriver Driver { get; set; }
    }
}
