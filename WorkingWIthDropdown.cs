using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace learningSelenium;

public class WorkingWithDropdown
{

    IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        // or we can also just join it with the variable above in line 12
        Driver = new ChromeDriver();

        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);     // Time limit before finishing the pageload
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);    // 
        Driver.Url = "https://test.qatechhub.com/form-elements/";
    }

    [Test]
    public void VerifyContactUsFormFill()
    {

        Driver.FindElement(By.Id("wpforms-49-field_1")).SendKeys("Marvin");
        Driver.FindElement(By.Name("wpforms[fields][1][last]")).SendKeys("Santos");
        Driver.FindElement(By.Id("wpforms-49-field_2")).SendKeys("test123@gmail.com");
        Driver.FindElement(By.Id("wpforms-49-field_4")).SendKeys("9004567892");


        Driver.FindElement(By.XPath ("//input[@value='Male']")).Click();
        // Creating an Element and an Instance of it

        IWebElement dropdown = Driver.FindElement(By.Name("wpforms[fields][5]"));

        SelectElement select = new SelectElement(dropdown);

        // Perform Operation to select the value from the outcome which will be the following: 

        select.SelectByText("Selenium");

        Driver.FindElement(By.Name("wpforms[submit]")).Click();

        // string expectedMessage = "Thanks for contacting us! We will be in touch with you shortly.";
        // string actualMessage = Driver.FindElement(By.Id("wpforms-confirmation-20")).Text;
     
        // Assert.AreEqual( expectedMessage , actualMessage ); 


    }
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }

}