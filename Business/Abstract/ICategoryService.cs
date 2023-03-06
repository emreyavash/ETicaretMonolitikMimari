using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Delete(Category category);
        IResult Update(Category category);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> Get(int id);

    }
}
