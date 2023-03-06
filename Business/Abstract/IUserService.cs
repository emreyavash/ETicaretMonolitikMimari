using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetUserById(int id);
        IDataResult<List<OperationClaim>> GetUserClaims(User user);
        IDataResult<User> GetByMail(string mail);
        IDataResult<UserDetailDTO> GetUserByMail(string mail);
    }
}
