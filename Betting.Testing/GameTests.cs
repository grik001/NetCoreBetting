using Betting.API.REST.Controllers;
using Betting.API.REST.Helpers.WebSocketHelpers;
using Betting.Common.Helpers.IHelpers;
using Betting.Data.DataModels.BrandX;
using Betting.Entities.Models;
using Betting.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Betting.Testing
{
    [TestClass]
    public class GameTests
    {
        Mock<IGameDataModel> MockGameDataModel = new Mock<IGameDataModel>();
        Mock<ICacheHelper> MockCacheHelper = new Mock<ICacheHelper>();
        Mock<INotificationsMessageHandler> MockNotificationsMessageHandler = new Mock<INotificationsMessageHandler>();
        Mock<ILogger<GamesController>> MockLogger = new Mock<ILogger<GamesController>>();

        //Get

        [TestMethod]
        public void GameTest_GetData_Pass()
        {
            MockGameDataModel.Setup(x => x.Get()).Returns(new List<Game>());
            MockCacheHelper.Setup(x => x.GetData<List<Game>>(It.IsAny<string>())).Returns(new List<Game>());
            MockNotificationsMessageHandler.Setup(x => x.SendMessageToAllAsync(It.IsAny<string>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = model.Get(null);
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;
            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public void GameTest_GetData_Fail()
        {
            MockGameDataModel.Setup(x => x.Get()).Throws(new System.Exception());

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
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
            MockGameDataModel.Setup(x => x.Insert(It.IsAny<Game>())).Returns(new Game());
            MockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = await model.Insert(new Game() { Code = "test" });
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_InsertData_Fail()
        {
            MockGameDataModel.Setup(x => x.Insert(It.IsAny<Game>())).Throws(new System.Exception());
            MockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = await model.Insert(new Game() { Code = "test" });
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }

        //Put

        [TestMethod]
        public async Task GameTest_PutData_Pass()
        {
            MockGameDataModel.Setup(x => x.Get(It.IsAny<int>())).Returns(new Game());
            MockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = await model.Put(1, new Game());
            var objectResult = result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_PutData_Fail()
        {
            MockGameDataModel.Setup(x => x.Get(It.IsAny<int>())).Throws(new System.Exception());
            MockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
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
            MockGameDataModel.Setup(x => x.Delete(It.IsAny<int>())).Returns(true);

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = model.Delete(1);
            var objectResult = await result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, true);
            Assert.AreEqual(resultModel.HasErrors, false);
        }

        [TestMethod]
        public async Task GameTest_DeleteData_Fail()
        {
            MockGameDataModel.Setup(x => x.Delete(It.IsAny<int>())).Throws(new System.Exception());
            MockCacheHelper.Setup(x => x.SetData<List<Game>>(It.IsAny<string>(), It.IsAny<List<Game>>()));

            var model = new GamesController(MockGameDataModel.Object, MockCacheHelper.Object, MockNotificationsMessageHandler.Object, MockLogger.Object);
            var result = model.Delete(1);
            var objectResult = await result as ObjectResult;
            var resultModel = objectResult.Value as ResultViewModel;

            Assert.AreEqual(resultModel.IsComplete, false);
            Assert.AreEqual(resultModel.HasErrors, true);
        }
    }
}
