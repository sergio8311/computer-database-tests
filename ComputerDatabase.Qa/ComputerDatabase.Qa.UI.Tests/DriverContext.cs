using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace ComputerDatabase.Qa.UI.Tests
{
    public static class DriverContext
    {
        private static readonly List<IWebDriver> Drivers = new List<IWebDriver>();

        static DriverContext()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
                process.Kill();
        }

        public static IWebDriver GetDriver(string browser = null, bool isRemote = false)
        {
            var browserName = browser ?? Configuration.Configuration.GetConfiguration<string>("browser");
            try
            {
                if (browserName.Equals("Edge", StringComparison.InvariantCultureIgnoreCase))
                {
                    IWebDriver atWebDriver = new EdgeDriver();
                    Drivers.Add(atWebDriver);
                    return atWebDriver;
                }

                var options = new ChromeOptions();
                var isHeadless = Configuration.Configuration.GetConfiguration<bool>("Headless");
                if (isHeadless)
                    options.AddArgument("--headless");

                IWebDriver defaultWebDriver = new ChromeDriver(options);
                Drivers.Add(defaultWebDriver);
                return defaultWebDriver;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error initializing WebDriver {browserName}", ex);
            }
        }

        public static void CloseDriver(this IWebDriver driver)
        {
            var atWebDriver = Drivers.FirstOrDefault(d => d.Equals(driver));
            if (atWebDriver == null)
                return;

            using (atWebDriver)
            {
                atWebDriver.Manage().Cookies.DeleteAllCookies();
                atWebDriver.Close();
                atWebDriver.Quit();
            }
        }
    }
}
