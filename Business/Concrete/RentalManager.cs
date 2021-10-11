using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        public IResult AddCustomer(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IResult DeleteCustomer(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetByRentalId(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult UpdateCustomer(Rental rental)
        {
            throw new NotImplementedException();
        }
    }
}
