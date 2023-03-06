using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //[CacheAspect]
        [SecuredOperation("admin,seller")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Product> Get(int id)
        {
            var result = _productDal.Get(p=> p.Id == id);
            return new SuccessDataResult<Product>(result);
        }

        public IDataResult<List<ProductDetailDto>> GetAll()
        {
            var result = _productDal.GetProductDetail();
            return new SuccessDataResult<List<ProductDetailDto>>(result,Messages.Listed);
        }

        public IDataResult<List<ProductDetailDto>> GetAllById(int userId)
        {
            var result = _productDal.GetProductsByUserId(userId);
            return new SuccessDataResult<List < ProductDetailDto >> (result, Messages.Listed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetail(int id)
        {
            var result = _productDal.GetProductDetail(p=>p.Id == id);
            return new SuccessDataResult<List<ProductDetailDto>>(result);
        }

        public IResult Update(Product product)
        {
           _productDal.Update(product);
            return new SuccessResult(Messages.Updated);
        }
    }
}
