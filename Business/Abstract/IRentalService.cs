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
        IResult AddRental(Rental rental);
        IResult DeleteRental(Rental rental);
        IResult UpdateRental(Rental rental);

        IResult IsCarEverRented(int Id);
        IResult IsCarReturned(int Id);
        IResult IsCarAvaible(int Id);
    }
}
