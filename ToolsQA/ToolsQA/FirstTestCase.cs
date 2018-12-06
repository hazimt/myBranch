using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

//Running Automation
namespace ToolsQA
{
    class FirstTestCase
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            //IWebDriver driver = new EdgeDriver();

            driver.Url = "http://www.demoqa.com";
        }
    }
}
