using Business.Configuration.Response;
using DTO.Message;
using Models.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMessageService
    {
        public IEnumerable<MessageGetResponse> GetAll();
        public MessageGetResponse GetById(int id);
        public CommandResponse SendMessage(MessageSendRequest request);
        public CommandResponse Delete(Message message);
    }
}
