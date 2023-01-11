using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISellerService
    {
        IResult Add(Seller seller);
        IResult Delete(Seller seller);
        IResult Update(Seller seller);
        IDataResult<Seller> GetById(int id);
        IDataResult<List<Seller>> GetAll();
    }
}
