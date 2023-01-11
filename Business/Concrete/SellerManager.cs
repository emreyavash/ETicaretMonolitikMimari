using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SellerManager : ISellerService
    {
        private ISellerDal _sellerDal;

        public SellerManager(ISellerDal sellerDal)
        {
            _sellerDal = sellerDal;
        }

        public IResult Add(Seller seller)
        {
            var checkCompanyName = BusinessRules.Run(CheckCompanyName(seller.CompanyName));
            if (checkCompanyName!=null)
            {
                return checkCompanyName;
            }
            seller.CreateTime = DateTime.Now;
            _sellerDal.Add(seller);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Seller seller)
        {
            _sellerDal.Delete(seller);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Seller>> GetAll()
        {
            var result = _sellerDal.GetAll();
            return new SuccessDataResult<List<Seller>>(result); 
        }

        public IDataResult<Seller> GetById(int id)
        {
            var result = _sellerDal.Get(x=> x.Id == id);
            return new SuccessDataResult<Seller>(result);
        }

        public IResult Update(Seller seller)
        {
            var checkCompanyName = BusinessRules.Run(CheckCompanyName(seller.CompanyName));
            if (checkCompanyName != null)
            {
                return checkCompanyName;
            }
            _sellerDal.Update(seller);
            return new SuccessResult(Messages.Updated);
        }



        /*Business Rules*/
        private IResult CheckCompanyName(string companyName)
        {
            var result = _sellerDal.GetAll(c=>c.CompanyName==companyName).Any();
            if (result)
            {
                return new ErrorResult("Bu şirket adı daha önce kullanılmış.");
            }
            return new SuccessResult();
        }

    }
}
