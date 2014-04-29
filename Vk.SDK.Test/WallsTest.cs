using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Vk.SDK.Context;
using Vk.SDK.Http;
using Vk.SDK.Interfaces;
using Vk.SDK.Vk;

namespace Vk.SDK.Test
{
    [TestClass]
    public class WallsTest
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
            kernel.Bind<IWallService>().To<WallService>();
        }


        [TestMethod]
        public void GetWallTest()
        {
            var service = kernel.Get<IWallService>();
            var posts = service.Get(new VKParameters()).GetModel();
            Assert.AreNotEqual(posts.Count, 0);
        }
    }
}
