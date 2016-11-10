using NUnit.Framework.Internal;

namespace iPaaS.test
{
    using System;
    using System.Configuration;
    using FluentAutomation;
    using NUnit.Framework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using iPaaS.Base;
    using iPaaS.App_GlobalResources;

    [TestClass]
    [TestFixture]
    public class Test : Initialize
    {

        [ClassInitialize]
        public static void ClassInitialize(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext context)
        {
            var initialize = new Initialize();
            initialize.BeforeEachTest();
            FluentSession.EnableStickySession();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            FluentSession.DisableStickySession();
        }

        [TestInitialize]
        [SetUp]
        public void init()
        {
            
        }
  
        [TestCategory("Test")]
        [TestMethod]
        public void Test1()
        {
            I.Open(new Uri("https://google.com"));
            I.Wait(2);
            I.Enter("hacky sack").In(I.Find("#lst-ib"));
            I.Wait(2);
            I.Click(I.Find("button[type='Submit']"));
            I.Wait(2);
            I.Click(I.Find("#hdtb-msb > div:nth-child(2) > a")); // Shopping link
            I.Wait(2);
            I.Click(I.Find("#rso > div.sh-sr__shop-result-group._G2d > div > div:nth-child(4)")); // 4th shopping result
            I.Wait(2);
            I.Click(I.Find(".gko-a-lbl")); // 'Save to Short list' button
            I.Wait(2);
            //The below would work if i did not have to sign in first. 
            //I.Click(I.Find("#bubble-5 > div.gko-c-s > div._-e.gko-c-ad > div._-f > div._-t > div:nth-child(1)")); // Add Note link
            //I.Wait(2);
            //I.Enter("Please buy me").In(I.Find(".gko-c-ni")); // Note text box
            //I.Wait(2);
            //I.Click(I.Find(".jfk-button-action")); // OK button
        }
    }
}