using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        private IProductImageDal _ımageDal;
        private IFileHelper _fileHelper;

        public ProductImageManager(IProductImageDal ımageDal, IFileHelper fileHelper)
        {
            _ımageDal = ımageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, ProductImage productImage)
        {
            var imageRule = BusinessRules.Run(CheckImageCount(productImage.ProductId));
            if(imageRule != null )
            {
                return imageRule;
            }
            productImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            productImage.UploadDate= DateTime.Now;
            _ımageDal.Add(productImage);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(ProductImage productImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath+productImage.ImagePath);
            _ımageDal.Delete(productImage);
            return new SuccessResult(Messages.Deleted); 
        }

        public IDataResult<List<ProductImage>> GetAll()
        {
            var allImages = _ımageDal.GetAll();
            return new SuccessDataResult<List<ProductImage>>(allImages);
        }

        public IDataResult<ProductImage> GetByImageId(int imageId)
        {
            var image = _ımageDal.Get(p=>p.Id==imageId);
            return new SuccessDataResult<ProductImage>(image);
        }

        public IDataResult<List<ProductImage>> GetImageByProductId(int productId)
        {
            var imagesOfProducts = _ımageDal.GetAll(p=>p.ProductId==productId);
            return new SuccessDataResult<List<ProductImage>>(imagesOfProducts);
        }

        public IResult Update(IFormFile formFile, ProductImage productImage)
        {
            productImage.ImagePath = _fileHelper.Update(formFile, PathConstants.ImagesPath+productImage.ImagePath,PathConstants.ImagesPath);
            _ımageDal.Update(productImage);
            return new SuccessResult(Messages.Updated);
        }


        /*Business Rule*/

        private IResult CheckImageCount(int productId)
        {
            var productImageCount = _ımageDal.GetAll(p=>p.ProductId==productId).Count;
            if (productImageCount > 5)
            {
                return new ErrorResult("Fotoğraf yükleme sınırına ulaştınız.");
            }
            return new SuccessResult();
        }
    }
}
