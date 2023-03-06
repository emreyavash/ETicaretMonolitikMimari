using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User,ETicaretContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ETicaretContext() )
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                on operationClaim.Id equals userOperationClaim.ClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();
            }
        }

        public UserDetailDTO GetUserByEmail(string email)
        {
            using (var context = new ETicaretContext())
            {
                var result = from user in context.Users
                             join userClaims in context.UserOperationClaims
                             on user.Id equals userClaims.UserId
                             select new UserDetailDTO
                             {
                                 Id = user.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Status = user.Status,
                                 Email = user.Email,
                                 ClaimId = userClaims.ClaimId,
                             };
                return result.Where(x=>x.Email==email).FirstOrDefault();
            }
        }
    }
}
