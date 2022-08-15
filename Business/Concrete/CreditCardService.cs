using BackgroundJobs.Abstract;
using Business.Abstract;
using DAL.Abstract;
using Models.Document;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CreditCardService : ICreditCardService
    {
        private readonly ICreditCardRepository _repository;
        private readonly IJobs _jobs;
        public CreditCardService(ICreditCardRepository repository, IJobs jobs)
        {
            _repository = repository;
            _jobs = jobs;
        }

        public void Add(CreditCard creditCard)
        {
            _repository.Add(creditCard);
        }

        public void Update(CreditCard creditCard)
        {
            _repository.Update(creditCard);
        }

        public void Delete(ObjectId id)
        {
            _repository.Delete(id);
        }

        public CreditCard Get(ObjectId id)
        {
            return _repository.Get(x => x.Id == id);
        }

        public IEnumerable<CreditCard> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
