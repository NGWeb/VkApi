using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vk.SDK.Vk;

namespace Vk.SDK.Test
{
    /// <summary>
    /// Summary description for UsersTest
    /// </summary>
    [TestClass]
    public class UsersTest
    {
        public UsersTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void GetUsersTest()
        {
            VKSdk.initialize("4256757", VKAccessToken.TokenFromUrlstring("https://oauth.vk.com/blank.html#access_token=0a6b9c8d685cbc1f0259aa6d8076612865efb100b328f5ed6fe7c2f3a10744227b26684114b9ee1c16036&expires_in=0&user_id=125342956"));
            var objects = VKApi.users().getFollowers(new VKParameters() { { "user_id", "125342956" }, { "fields", "screen_name" } }).GetResponse();
            Assert.IsNotNull(objects);
        }
    }
}
