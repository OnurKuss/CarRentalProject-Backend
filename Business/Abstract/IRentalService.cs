using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAllRentals();
        IDataResult<Rental> GetByRentalId(int Id);
        IResult AddCustomer(Rental rental);
        IResult DeleteCustomer(Rental rental);
        IResult UpdateCustomer(Rental rental);
    }
}
