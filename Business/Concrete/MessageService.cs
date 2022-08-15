using AutoMapper;
using Business.Abstract;
using Business.Configuration.Extensions;
using Business.Configuration.Response;
using Business.Configuration.Validator.FluentValidation.MessageValidation;
using DAL.Abstract;
using DTO.Message;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _repository;
        private readonly IMapper _mapper;
        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public CommandResponse Delete(Message message)
        {
            _repository.Delete(message);
            return new CommandResponse
            {
                Success = true,
                Message = $"Message deleted successfully."
            };
        }

        public IEnumerable<MessageGetResponse> GetAll()
        {
            var data = _repository.GetAll();
            var mappedData = data.Select(x => _mapper.Map<MessageGetResponse>(x)).ToList();
            return mappedData;
        }

        public MessageGetResponse GetById(int id)
        {
            //Mapping
            var data = _repository.Get(x => x.Id == id);
            var mappedData = _mapper.Map<MessageGetResponse>(data);
            return mappedData;
        }

        public CommandResponse SendMessage(MessageSendRequest request)
        {
            //Validator
            var validator = new MessageSendRequestValidator();
            validator.Validate(request).ThrowIfException();

            //Add request to database  
            var entity = _mapper.Map<Message>(request);
            _repository.Add(entity);
            _repository.SaveChanges();

            return new CommandResponse
            {
                Success = true,
                Message = $"Message sent successfully."
            };
        }
    }
}
