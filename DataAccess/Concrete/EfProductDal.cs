using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ETicaretContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetail(Expression<Func<ProductDetailDto, bool>> filter = null)
        {
            using (var context = new ETicaretContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join s in context.Sellers
                             on p.SellerId equals s.Id
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 ProductDescription = p.ProductDescription,
                                 Price = p.Price,
                                 Category = c.CategoryName,
                                 CategoryId=c.Id,
                                 Quantity = p.Quantity,
                                 SellerId = s.Id,
                                 CompanyName =s.CompanyName,
                                 ProductImage = (from pi in context.ProductImages where pi.ProductId == p.Id select pi.ImagePath).FirstOrDefault(),
                                 CreatedDate = DateTime.Now
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<ProductDetailDto> GetProductsByUserId(int userId)
        {
            using (var context = new ETicaretContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.Id
                             join s in context.Sellers
                             on p.SellerId equals s.Id
                             join u in context.Users
                             on s.UserId equals u.Id
                             where s.UserId == userId
                             select new ProductDetailDto
                             {
                                 Id = p.Id,
                                 ProductName = p.ProductName,
                                 ProductDescription = p.ProductDescription,
                                 Price = p.Price,
                                 Category = c.CategoryName,
                                 CategoryId = c.Id,
                                 Quantity = p.Quantity,
                                 SellerId = s.Id,
                                 CompanyName = s.CompanyName,
                                 ProductImage = (from pi in context.ProductImages where pi.ProductId == p.Id select pi.ImagePath).FirstOrDefault(),
                                 CreatedDate = DateTime.Now
                             };
                return result.ToList();
            }
        }
    }
}
