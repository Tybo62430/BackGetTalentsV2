using BackGetTalentsV2.Business.Picture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackGetTalentsV2.Business.Message
{
    public class MessageHelper
    {
        public static List<MessageDTO> ConvertMessages(List<Message> messages)
        {
            return messages.ConvertAll(message => ConvertMessage(message));
        }

        public static MessageDTO ConvertMessage(Message message)
        {
            MessageDTO messageDTO = new()
            {
                Id = message.Id,
                Content = message.Content,
                SendAt = message.SendAt,
                UserPseudo = message.User.Pseudo,
                Pictures = PictureHelper.ConvertPictures(message.Pictures.ToList())         ,
                ConversationId = message.ConversationId
            };

            return messageDTO;
        }
        public static List<MessageDTOMinimalist> ConvertMessagesDTOMinimalist(List<Message> messages)
        {
            return messages.ConvertAll(message => ConvertMessageDTOMinimalist(message));
        }

        public static MessageDTOMinimalist ConvertMessageDTOMinimalist(Message message)
        {
            MessageDTOMinimalist messageDTOMinimalist = new()
            {
                Id = message.Id,
                Content = message.Content,
                SendAt = message.SendAt,
                ConversationId = message.ConversationId
            };

            return messageDTOMinimalist;
        }       
    }
}
