using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Vk.SDK.Context;
using Vk.SDK.Http;
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
        private StandardKernel kernel;

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

        [TestInitialize]
        public void InitTest()
        {
            /*
             To generate access token call
             * https://oauth.vk.com/authorize?client_id=4256757&scope=groups,photos,friends,offline,wall,photos,notify,status&redirect_uri=http://oauth.vk.com/blank.html&display=popup&response_type=token
             
             */
            VKSdk.initialize("4256757", VKAccessToken.TokenFromUrlstring("access_token=e0c4be9e5eef8aab8d660f970f2d728b9d333a1c5a5ae7710baf4cbbd9dc882723122c5426c28a816a22f&expires_in=0&user_id=125342956"));
            kernel = new Ninject.StandardKernel();
            kernel.Bind<IRequestCreator>().To<RequestCreator>();
            kernel.Bind<IRequestFactory>().To<RequestFactory>();
            kernel.Bind<IUsersService>().To<UsersService>();
        }

        [TestMethod]
        public void GetUserTest()
        {
            var objects = kernel.Get<IUsersService>().Get(new VKParameters() { { "user_ids", "125342956" }, { "fields", "screen_name" } }).GetResponse();
            Assert.IsNotNull(objects);

        }

        [TestMethod]
        public void GetUsersTest()
        {
            var objects = kernel.Get<IUsersService>().GetFollowers(new VKParameters() { { "user_id", "125342956" }, { "fields", "screen_name" } }).GetResponse();
            Assert.IsNotNull(objects);
        }

        [TestMethod]
        public void GetSubscriptions()
        {
            var objects = kernel.Get<IUsersService>().GetSubscriptions(new VKParameters { { "user_id", "125342956" }, { "fields", "screen_name" } }).GetResponse();
            Assert.IsNotNull(objects);
        }
    }
}
