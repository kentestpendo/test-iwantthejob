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
        public void GoogleSearchTest()
        {
            const string EmailAddress = "pendoio999@gmail.com";
            const string UserPwd = "Test@1234";
            const string SearchText = "hacky sack";
            const string NoteText = "Please buy me";

            I.Open(new Uri("https://google.com"));
            I.WaitUntil(() => I.Assert.Exists("#gb_70"), 3)
                .Click(I.Find("#gb_70")); // Sign In
            I.WaitUntil(() => I.Assert.Exists("#Email"), 3)
                .Enter(EmailAddress).In(I.Find("#Email")) // User Email Address
                .Click(I.Find("#next"))
                .Wait(2)
                .Enter(UserPwd).In(I.Find("#Passwd")) // User Password
                .Click(I.Find("#signIn"));
            I.WaitUntil(() => I.Assert.Exists("#lst-ib"), 3)
                .Enter(SearchText).In(I.Find("#lst-ib")) // Search text
                .Click(I.Find("button[type='Submit']"));
            I.WaitUntil(() => I.Assert.Exists("#hdtb-msb"), 3)
                .Click(I.Find("#hdtb-msb > div:nth-child(2) > a")) // Shopping link
                .Wait(2)
                .Click(I.Find("#rso > div.sh-sr__shop-result-group._G2d > div > div:nth-child(4)")) // 4th shopping result
                .Wait(2)
                .Focus(I.Find(".gko-a-lbl"))
                .Click(I.Find(".gko-a-lbl")) // 'Save to Short list' button
                .Wait(2);
            try
            {
                var noteBox1 = I.Find("#bubble-7 > div.gko-c-s > div._-e.gko-c-ad > div._-f > div._-t > div:nth-child(1)");
                I.Focus(noteBox1)
                    .Wait(1)
                    .Click(noteBox1); // Add Note link
            }
            catch
            {
                var noteBox2 = I.Find("#bubble-8 > div.gko-c-s > div._-e.gko-c-ad > div._-f > div._-t > div:nth-child(1)");
                I.Focus(noteBox2)
                    .Wait(1)
                    .Click(noteBox2); // Add Note link
            }
            I.Wait(2)
                .Enter(NoteText).In(I.Find(".gko-c-ni")) // Note text box
                .Wait(2)
                .Click(I.Find(".jfk-button-action")) // OK button
                .Wait(2);
            try
            {
                var noteBox3 = I.Find("#bubble-7 > div.gko-c-s > div._-e.gko-c-n > div._-f > div._-j > div:nth-child(1)");
                I.Expect.Text(x => x.Contains("Note saved for:")).In(noteBox3); // Note Saved!
            }
            catch
            {
                var noteBox4 = I.Find("#bubble-8 > div.gko-c-s > div._-e.gko-c-n > div._-f > div._-j > div:nth-child(1)");
                I.Expect.Text(x => x.Contains("Note saved for:")).In(noteBox4); // Note Saved!
            }
            I.Wait(2)
                .Click(I.Find(".gb_8a"))
                .Wait(2)
                .Click(I.Find("#gb_71")) // Sign out
                .Wait(2);
            I.Assert.Exists(I.Find("#gb_70")); // Sign In button
        }
    }
}
