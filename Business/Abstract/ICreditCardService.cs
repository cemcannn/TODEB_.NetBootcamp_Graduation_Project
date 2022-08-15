using Models.Document;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICreditCardService
    {
        void Add(CreditCard creditCard);
        void Update(CreditCard creditCard);
        void Delete(ObjectId id);
        CreditCard Get(ObjectId id);
        IEnumerable<CreditCard> GetAll();
    }
}
