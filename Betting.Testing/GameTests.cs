using Betting.API.REST.Controllers;
using Betting.API.REST.Helpers.WebSocketHelpers;
using Betting.Common.Helpers.IHelpers;
using Betting.Data.DataModels.BrandX;
using Betting.Entities.Models;
using Betting.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Betting.Testing
{
    [TestClass]
    public class GameTests
    {
        //Get

        [TestMethod]
        public void GameTest_GetData_Pass()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Get()).Returns(new List<Game>());
            mockCacheHelper.Setup(x => x.GetData<List<Game>>(It.IsAny<string>())).Returns(new List<Game>());
            mockNotificationsMessageHandler.Setup(x => x.SendMessageToAllAsync(It.IsAny<string>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = model.Get(null);
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;
            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public void GameTest_GetData_Fail()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Get()).Throws(new System.Exception());

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = model.Get(null);
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;
            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }

        //Insert

        [TestMethod]
        public async Task GameTest_InsertData_Pass()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Insert(It.IsAny<Game>())).Returns(new Game());
            mockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = await model.Insert(new Game());
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_InsertData_Fail()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Insert(It.IsAny<Game>())).Throws(new System.Exception());
            mockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = await model.Insert(new Game());
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }

        //Put

        [TestMethod]
        public async Task GameTest_PutData_Pass()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Get(It.IsAny<int>())).Returns(new Game());
            mockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = await model.Put(1, new Game());
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_PutData_Fail()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Get(It.IsAny<int>())).Throws(new System.Exception());
            mockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = await model.Put(1, new Game());
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }

        //Delete

        [TestMethod]
        public async Task GameTest_DeleteData_Pass()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = model.Delete(1);
            var objectResult = await result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_DeleteData_Fail()
        {
            var mockGameDataModel = new Mock<IGameDataModel>();
            var mockCacheHelper = new Mock<ICacheHelper>();
            var mockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();

            mockGameDataModel.Setup(x => x.Delete(It.IsAny<int>())).Throws(new System.Exception());
            mockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(mockGameDataModel.Object, mockCacheHelper.Object, mockNotificationsMessageHandler.Object);
            var result = model.Delete(1);
            var objectResult = await result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }
    }
}
