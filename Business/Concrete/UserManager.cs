using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private  IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            IResult emailCheck = BusinessRules.Run(CheckEmail(user.Email));
            if (emailCheck != null)
            {
                return emailCheck;
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var user = _userDal.Get(x => x.Email == mail);
            return new SuccessDataResult<User>(user);
        }
        public IDataResult<UserDetailDTO> GetUserByMail(string mail)
        {
            var user = _userDal.GetUserByEmail(mail);
            return new SuccessDataResult<UserDetailDTO>(user);
        }
        public IDataResult<List<User>> GetAll()
        {
            var userList = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(userList);

        }

        public IDataResult<User> GetUserById(int id)
        {
            var user = _userDal.Get(x => x.Id == id);
            return new SuccessDataResult<User>(user);
        }

        public IDataResult<List<OperationClaim>> GetUserClaims(User user)
        {
            var userClaims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(userClaims);
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        //Business Kodları
        private IResult CheckEmail(string email)
        {
            var result = _userDal.GetAll(p => p.Email == email);
            if (result.Any())
            {
                return new ErrorResult(Messages.EmailUsed);
            }
            
            return new SuccessResult();
        }
    }
}
