using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByMail(string email);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<List<User>> GetAllUsers();
        IDataResult<User> GetByUserId(int Id);
        IResult AddUser(User user);
        IResult DeleteUser(User user);
        IResult UpdateUser(User user);
    }
}
