using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult AddRental(Rental rental)
        {
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult DeleteRental(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAllRentals()
        {
            var result = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(result, Messages.RentalListed);
        }

        public IDataResult<Rental> GetByRentalId(int Id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == Id));
        }

        public IResult UpdateRental(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public IResult IsCarEverRented(int Id)
        {
            if (_rentalDal.GetAll(r => r.CarId == Id && r.RentDate==null!).Any())
            {
                return new SuccessResult(Messages.RentedCars);  
            }
            else
            {
                return new ErrorResult("Araba kiralanmadı zzz");
            }
            
        }
        public IResult IsCarReturned(int Id)
        {
            if (_rentalDal.GetAll(r=> r.CarId==Id && r.ReturnDate==null).Any())
            {
                return new ErrorResult("Başarılı");
            }
            return new SuccessResult("Başarısız");
        }

        public IResult IsCarAvaible(int Id)
        {
            if (IsCarEverRented(Id).Success)
            {
                if (IsCarReturned(Id).Success)
                {
                    return new SuccessResult("Araç geri teslim alınmıştır.");
                }
                return new ErrorResult("Kiramala için araç müsait değildir.");
            }
            return new SuccessResult("Ara");
        }
    }
}
