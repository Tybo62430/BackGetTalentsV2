using BackGetTalentsV2.Business.Message;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Controllers
{
    [Route("messages")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Route("GetLastMessageByConversationId/{conversationId}")]
        public IActionResult GetLastMessageByConversationId([FromRoute] int conversationId)
        {
            Message message = this._messageService.FindLastMessageByConversationId(conversationId);

            MessageDTOMinimalist messageDTOMinimalist = MessageHelper.ConvertMessageDTOMinimalist(message);

            return Ok(messageDTOMinimalist);
        }

        [HttpGet]
        [Route("GeAllMessagesByConversationId/{conversationId}")]
        public IActionResult GeAllMessagesByConversationId([FromRoute] int conversationId)
        {
            List<Message> messages = this._messageService.FindAllMessagesByConversationId(conversationId).ToList();

            ICollection<MessageDTO> messagesDTO = MessageHelper.ConvertMessages(messages);

            return Ok(messagesDTO);
        }

        [HttpPost]
        public IActionResult NewMessage([FromBody] Message message)
        {
            _messageService.AddMessage(message);

            return Created(nameof(NewMessage), message);
        }


    }
}
