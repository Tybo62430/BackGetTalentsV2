using BackGetTalentsV2.Business.Convers;
using BackGetTalentsV2.Business.Message;
using BackGetTalentsV2.Business.User;
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
        private IUserService _iuserService;


        public MessageController(IMessageService messageService, IConversationService conversationService, IUserHasConversationService userHasConversationService, IUserService iuserService)
        {
            _messageService = messageService;
            _conversationService = conversationService;
            _userHasConversationService = userHasConversationService;
            _iuserService = iuserService;
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

            Conversation conversation = null;

            ICollection<Conversation> conversationsSender = this._conversationService.FindAllConversationByUserId(messagePostDTO.SenderId).ToList();
            IList<ConversationDTO> conversationsDTOSender = ConversationHelper.ConvertConversations(conversationsSender.ToList());

            foreach(ConversationDTO conversation1 in conversationsDTOSender)
            {
                foreach (string userPseudo in conversation1.UserPseudoList)
                {
                    User user = this._iuserService.GetUserById(messagePostDTO.ReciverId);

                    if(user.Pseudo == userPseudo)
                    {
                        conversation = this._conversationService.FindConversationById(conversation1.Id);
                    }
                }

            }

            if(conversation == null)
            {
                conversation = new Conversation();
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
            }

            message.ConversationId = conversation.Id;

            this._messageService.AddMessage(message);

            return Created(nameof(NewMessage), messagePostDTO);
        }
    }
}
