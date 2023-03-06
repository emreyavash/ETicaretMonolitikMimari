using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
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
    public class NavbarManager : INavbarService
    {
        private INavbarDal _navbarDal;

        public NavbarManager(INavbarDal navbarDal)
        {
            _navbarDal = navbarDal;
        }

        public IResult Add(Navbar navbar)
        {
            _navbarDal.Add(navbar);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Navbar navbar)
        {
            _navbarDal.Delete(navbar);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Navbar> Get(int id)
        {
            var result = _navbarDal.Get(x => x.Id == id);
            return new SuccessDataResult<Navbar>(result);
        }

        public IDataResult<List<Navbar>> GetAll()
        {
            var result = _navbarDal.GetAll();
            return new SuccessDataResult<List<Navbar>>(result);
        }

        public IResult Update(Navbar navbar)
        {
            _navbarDal.Update(navbar);
            return new SuccessResult(Messages.Updated);
        }
    }
}
