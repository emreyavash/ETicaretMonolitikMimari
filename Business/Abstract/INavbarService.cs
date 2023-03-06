using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface INavbarService
    {
        IResult Add(Navbar navbar);
        IResult Delete(Navbar navbar);
        IResult Update(Navbar navbar);
        IDataResult<List<Navbar>> GetAll(); 
        IDataResult<Navbar> Get(int id);
    }
}
