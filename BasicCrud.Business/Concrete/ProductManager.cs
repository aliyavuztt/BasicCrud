using AutoMapper;
using BasicCrud.Business.Abstract;
using BasicCrud.Business.Constants;
using BasicCrud.Core.Utilities.Business;
using BasicCrud.Core.Utilities.Results;
using BasicCrud.DataAccess.Abstract;
using BasicCrud.Entities.Concrete;
using BasicCrud.Entities.Dtos;

namespace BasicCrud.Business.Concrete
{
    internal class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly IMapper _mapper;

        public ProductManager(IMapper mapper, IProductDal productDal)
        {
            _mapper = mapper;
            _productDal = productDal;
        }

        public IResult Add(ProductAddDto productAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(productAddDto.Name));

            if (result != null)
            {
                return result;
            }

            var product = _mapper.Map<Product>(productAddDto);
            _productDal.Add(product);
            return new SuccessResult(Messages.Product.Add(product.Name));
        }

        public IResult Update(ProductUpdateDto productUpdateDto)
        {
            var oldProduct = _productDal.Get(x => x.Id == productUpdateDto.Id);
            var product = _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
            _productDal.Update(product);
            return new SuccessResult(Messages.Product.Update(product.Name));
        }

        public IResult Delete(int productId)
        {
            var product = _productDal.Get(x => x.Id == productId);

            if (product == null)
            {
                return new ErrorResult(Messages.Product.NotFound(false));
            }

            var title = product.Name;

            if (product != null)
            {
                _productDal.Delete(product);
            }
            return new SuccessResult(Messages.Product.Delete(title));
        }

        public IDataResult<ProductDto> GetById(int productId)
        {
            var product = _productDal.Get(x => x.Id == productId);

            if (product == null)
            {
                return new ErrorDataResult<ProductDto>(Messages.Product.NotFound(false));
            }

            return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(product));
        }

        public IDataResult<List<ProductListDto>> GetList()
        {
            var products = _productDal.GetList();

            if (products.Count == 0)
            {
                return new ErrorDataResult<List<ProductListDto>>(Messages.Product.NotFound(true));
            }
            return new SuccessDataResult<List<ProductListDto>>(_mapper.Map<List<ProductListDto>>(products));
        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productDal.GetList(p => p.Name == name).Any();
            if (result)
            {
                return new ErrorResult(Messages.Product.NameAlreadyExists());
            }
            return new SuccessResult();
        }
    }
}