using Betting.API.REST.Helpers.WebSocketHelpers;
using Betting.Data.DataModels;
using Betting.Data.DataModels.BrandX;
using Betting.Entities.Models;
using Betting.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using static Betting.Common.Constants;

namespace Betting.API.REST.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IMessageDataModel _messageDataModel;
        private INotificationsMessageHandler _notificationsMessageHandler;

        public MessagesController(IMessageDataModel messageDataModel, INotificationsMessageHandler notificationsMessageHandler)
        {
            this._messageDataModel = messageDataModel;
            this._notificationsMessageHandler = notificationsMessageHandler;
        }

        [HttpGet()]
        public IActionResult Get([FromQuery]int? limit = 100)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var messages = _messageDataModel.GetDescending(limit);

                result.Entity = messages;
                result.IsComplete = true;

            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromQuery]int? limit)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var message = _messageDataModel.Get(id);

                result.Entity = message;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody]Message message)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                message.EntryTime = DateTime.UtcNow;
                message = _messageDataModel.Insert(message);

                if (String.IsNullOrWhiteSpace(message.TargetClientId))
                {
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToAll<Message>(SocketMessageType.SingleMessage, message);
                }
                else
                {
                    await new SocketPushHelper(_notificationsMessageHandler).SendMessageToSingle<Message>(SocketMessageType.SingleMessage, message.TargetClientId, message);
                }

                result.Entity = message;
                result.IsComplete = true;
            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Message message)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var messageDb = _messageDataModel.Get(id);

                if (messageDb != null)
                {
                    messageDb.SendOn = message.SendOn;
                    messageDb.Text = message.Text;
                    messageDb.Title = message.Title;
                    messageDb = _messageDataModel.Update(messageDb);

                    result.IsComplete = true;
                    result.Entity = messageDb;
                }

            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ResultViewModel result = new ResultViewModel();

            try
            {
                var deleted = _messageDataModel.Delete(id);

                result.Entity = id;
                result.IsComplete = deleted;

                if (!deleted)
                {
                    HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                //Log

                result.HasErrors = true;
            }

            return new ObjectResult(result);
        }
    }
}