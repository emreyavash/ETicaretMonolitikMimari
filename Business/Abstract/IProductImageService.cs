using Core.Utilities.Results;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductImageService
    {
        IResult Add(IFormFile file, ProductImage productImage);
        IResult Delete(ProductImage productImage);
        IResult Update(IFormFile formFile, ProductImage productImage);
        IDataResult<ProductImage> GetByImageId(int imageId);
        IDataResult<List<ProductImage>> GetImageByProductId(int productId);
        IDataResult<List<ProductImage>> GetAll();
    }
}
