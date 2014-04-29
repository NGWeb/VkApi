using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Vk.SDK.Context;
using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Vk;
using Vk.SDK.Model;

namespace Vk.SDK.Test
{
    [TestClass]
    public class MessageTest
    {
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
            VKSdk.initialize("4256757", VKAccessToken.TokenFromUrlstring("access_token=d471731b564c57eb98dc97c6f4c722ba413a3a7cf320b3f2dd97de743dd1fd656ac44aa007183802e86b8&expires_in=0&user_id=125342956"));
            kernel = new Ninject.StandardKernel();
            kernel.Bind<IRequestCreator>().To<RequestCreator>();
            kernel.Bind<IRequestFactory>().To<RequestFactory>();
            kernel.Bind<IUsersService>().To<UsersService>();
            kernel.Bind<IMessagesService>().To<MessagesService>();
        }

        [TestMethod]
        public void GetMessageTest()
        {
            var service = kernel.Get<MessagesService>();

            var model = service.Get(new VKParameters()).GetModel();

            Assert.AreNotEqual(model.Items.Count, 0);
        }

        [TestMethod]
        public void GetChats()
        {

            var service = kernel.Get<IMessagesService>();
            var model = service.GetDialogs(new VKParameters()).GetModel();
            Assert.AreNotEqual(model.Items.Count, 0);

        }

        [TestMethod]
        public void Send()
        {
            var service = kernel.Get<IMessagesService>();
            //      var model = service.Send(new Message() { body = "По одному" }, 2391002).GetResponse();
            var model = service.Send(new Message() { body = "одному )" }, 29163158).GetResponse();
            Assert.AreNotEqual(model, null);
        }

        [TestMethod]
        public void GetHistory()
        {
            int userid = 29163158;
            var service = kernel.Get<IMessagesService>();
            var history = service.GetHistory(userid).GetModel();
            Assert.AreNotEqual(history.Items.Count, 0);


            foreach (var message in history.Items.Select(x => x.user_id))
            {
                Assert.AreEqual(message, userid);
            }

        }

    }
}
