using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAllUsers()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result, Messages.UserListed);
        }
        public IDataResult<User> GetByUserId(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == Id));
        }

        public IDataResult<User> GetByMail(string email)
        {
            var result = _userDal.Get(u => u.Email == email);
            if (result == null)
            {
                return new ErrorDataResult<User>(result, "Kullanıcıya ait mail yok");
            }
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
