using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.Message;
using BackGetTalentsV2.Business.UserHasConversation;
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
        private IConversationService _conversationService;
        private IUserHasConversationService _userHasConversationService;

        public MessageController(IMessageService messageService, IConversationService conversationService, IUserHasConversationService userHasConversationService)
        {
            _messageService = messageService;
            _conversationService = conversationService;
            _userHasConversationService = userHasConversationService;
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
        public IActionResult NewMessage([FromBody] MessagePostDTO messagePostDTO)
        {
            Message message = MessageHelper.ConvertPostMessageDTO(messagePostDTO);

            if (message.ConversationId == 0)
            {
                Conversation conversation = new Conversation();
                conversation = this._conversationService.NewConversation(conversation);

                UserHasConversation sender = new UserHasConversation()
                {
                    UserId = messagePostDTO.SenderId,
                    ConversationId = conversation.Id

                };
                UserHasConversation reciver = new UserHasConversation()
                {
                    UserId = messagePostDTO.ReciverId,
                    ConversationId = conversation.Id
                };

                this._userHasConversationService.NewUserHasConversation(sender);
                this._userHasConversationService.NewUserHasConversation(reciver);

                message.ConversationId = conversation.Id;

            }

            this._messageService.AddMessage(message);

            return Created(nameof(NewMessage), messagePostDTO);
        }


    }
}
