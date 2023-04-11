using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace learningSelenium;

public class DragAndDrop
{

    IWebDriver Driver;

    [SetUp]
    public void Setup()
    {
        Driver = new ChromeDriver();

        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Window.Maximize();
        Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);     // Time limit before finishing the pageload
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);    // 
        Driver.Url = "https://test.qatechhub.com/drag-and-drop/";
    }

    [Test]
    public void VerifyDragAndDrop()
    {
        Actions action = new Actions(Driver);
        IWebElement smallSquare = Driver.FindElement(By.Id("draggable"));

        IWebElement bigSquare = Driver.FindElement(By.Id("droppable"));

        string colorBeforeDragAndDrop = bigSquare.GetCssValue("color");
        action.DragAndDrop(smallSquare, bigSquare).Perform(); 

        string colorAfterDragAndDrop = bigSquare.GetCssValue("color");

        Assert.AreNotEqual(colorBeforeDragAndDrop, colorAfterDragAndDrop); 
    }
    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
    }

}