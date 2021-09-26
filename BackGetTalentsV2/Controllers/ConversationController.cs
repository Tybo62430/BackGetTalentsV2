using BackGetTalentsV2.Business.Convers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackGetTalentsV2.Controllers
{
    [Route("conversations")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        [Route("GetConversationByUserId/{userId}")]
        public IActionResult GetConversationByUserId([FromRoute] int userId)
        {
            IList<Conversation> conversations = _conversationService.FindAllConversationByUserId(userId).ToList();

            IList<ConversationDTO> conversationsDTO = ConversationHelper.ConvertConversations(conversations.ToList());

            return Ok(conversationsDTO);
        }
    }
}
