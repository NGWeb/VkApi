using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Vk.SDK.Context;
using Vk.SDK.Http;
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
            VKSdk.initialize("4256757", VKAccessToken.TokenFromUrlstring("access_token=4a6700a874589d86d43afa36aa08e9cee7ca40acaa7c413e6a18a6d009d34c1fd538dec7e40cc49e34e&expires_in=0&user_id=125342956"));
            kernel = new Ninject.StandardKernel();
            kernel.Bind<IRequestCreator>().To<RequestCreator>();
            kernel.Bind<IRequestFactory>().To<RequestFactory>();
            kernel.Bind<IUsersService>().To<UsersService>();
            kernel.Bind<IWallService>().To<WallService>();
        }


        [TestMethod]
        public void TestMethod1()
        {
            var service = kernel.Get<IWallService>();
            var posts = service.Get(new VKParameters()).GetModel();
            Assert.AreNotEqual(posts.Count, 0);
        }
    }
}
