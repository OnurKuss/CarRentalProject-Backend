using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult("Kart Eklendi");
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult("Kart Silindi");
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            var result = _creditCardDal.GetAll();
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IDataResult<List<CreditCard>> GetAllByCustomerId(int customerId)
        {
            var result = _creditCardDal.GetAll(c => c.CustomerId == customerId);
            return new SuccessDataResult<List<CreditCard>>(result);
        }

        public IDataResult<CreditCard> GetById(int id)
        {
            var result = _creditCardDal.Get(c => c.Id == id);
            return new SuccessDataResult<CreditCard>(result);
        }
    }
}
