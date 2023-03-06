using Business.Abstract;
using Business.Constants;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult Add(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Category> Get(int id)
        {
            var result = _categoryDal.Get(c=>c.Id== id);
            return new SuccessDataResult<Category>(result);
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll();
            return new SuccessDataResult<List<Category>>(result, Messages.Listed);
        }

        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.Updated);
        }
    }
}
