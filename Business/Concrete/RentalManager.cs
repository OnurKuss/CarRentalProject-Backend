using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(RentalValidator))]
        public IResult AddRental(Rental rental)
        {
            var result = BusinessRules.Run(IsCarEverRented(rental.CarId),IsCarReturned(rental.CarId),IsCarAvaible(rental.CarId));

            if (result != null)
            {
                return result;
            }

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

        public IResult IsCarEverRented(int carId)
        {
            var results = this.GetAllRentals().Data;
            foreach (var result in results)
            {
                if (result.CarId==carId && result.RentDate==null!)
                {
                    return new ErrorResult(Messages.RentedCars);
                }
            }
            return new SuccessResult();
        }

        public IResult IsCarReturned(int carId)
        {
            var results = this.GetAllRentals().Data;

            foreach (var result in results)
            {
                if (result.CarId==carId && result.ReturnDate==null)
                {
                    return new ErrorResult("Araç henüz geri dönmedi");
                }
            }
            return new SuccessResult();
            
        }

        public IResult IsCarAvaible(int Id)
        {
            if (IsCarEverRented(Id).Success)
            {
                if (IsCarReturned(Id).Success)
                {
                    return new SuccessResult();
                }
            }
            return new ErrorResult();
        }
    }
}
