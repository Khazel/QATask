using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CafeTownsendAutoTests
{
    class Login_Logout_Test
    {
        const string LOGGED_IN_PAGE_URL = "http://cafetownsend-angular-rails.herokuapp.com/employees";
        const string LOGGED_OUT_PAGE_URL = "http://cafetownsend-angular-rails.herokuapp.com/login";

        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void SuccessfullLogin()
        {
            Login("Luke", "Skywalker");
            Thread.Sleep(5000);
            Assert.AreEqual(driver.Url, LOGGED_IN_PAGE_URL);
        }

        public void SuccessfullLogout()
        {
            Login("Luke", "Skywalker");
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("/html/body/div[1]/header/div/p[1]")).Click();
            Assert.AreEqual(driver.Url, LOGGED_OUT_PAGE_URL);
        }

        private void Login(string name, string pswd)
        {
            driver.Url = "http://cafetownsend-angular-rails.herokuapp.com/login";
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/label[1]/input")).SendKeys(name);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/label[2]/input")).SendKeys(pswd);
            driver.FindElement(By.XPath("/html/body/div[1]/div/div/form/fieldset/button")).Click();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}