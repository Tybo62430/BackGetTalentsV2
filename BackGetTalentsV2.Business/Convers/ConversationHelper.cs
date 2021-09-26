﻿using BackGetTalentsV2.Business.Message;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Convers
{
    public class ConversationHelper
    {
        public static List<ConversationDTO> ConvertConversations(List<Conversation> conversations)
        {
            return conversations.ConvertAll(conversation => ConvertConversation(conversation));
        }

        public static ConversationDTO ConvertConversation(Conversation conversation)
        {
            MessageDTOMinimalist lastMessage = MessageHelper.ConvertMessageDTOMinimalist(conversation.Messages.ToList().Last());

            ICollection<string> pseudos = new Collection<string>();

            foreach (UserHasConversation.UserHasConversation userHasConversation in conversation.UserHasConversations)
            {
                if(userHasConversation.ConversationId == conversation.Id)
                {
                    pseudos.Add(userHasConversation.User.Pseudo);
                }
            }

            ConversationDTO conversationDTO = new()
            {
                Id = conversation.Id,
                UserPseudoList = pseudos,
                DateLastMessage = (DateTime)lastMessage.SendAt,
                LastContent = lastMessage.Content,                
            };

            return conversationDTO;
        }
    }
}