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
    internal class ProductManager1 : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductManager1(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public IResult Add(ProductAddDto productAddDto)
        {
            IResult result = BusinessRules.Run(CheckIfProductNameExists(productAddDto.Name));

            if (result != null)
            {
                return result;
            }

            var product = _mapper.Map<Product>(productAddDto);
            _productRepository.Add(product);
            return new SuccessResult(Messages.Product.Add(product.Name));
        }

        public IResult Update(ProductUpdateDto productUpdateDto)
        {
            var oldProduct = _productRepository.GetById(productUpdateDto.Id);
            var product = _mapper.Map<ProductUpdateDto, Product>(productUpdateDto, oldProduct);
            _productRepository.Update(product);
            return new SuccessResult(Messages.Product.Update(product.Name));
        }

        public IResult Delete(int productId)
        {
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return new ErrorResult(Messages.Product.NotFound(false));
            }

            var title = product.Name;

            if (product != null)
            {
                _productRepository.Delete(productId);
            }
            return new SuccessResult(Messages.Product.Delete(title));
        }

        public IDataResult<ProductDto> GetById(int productId)
        {
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return new ErrorDataResult<ProductDto>(Messages.Product.NotFound(false));
            }
            return new SuccessDataResult<ProductDto>(_mapper.Map<ProductDto>(product));
        }

        public IDataResult<List<ProductListDto>> GetList()
        {
            var products = _productRepository.GetList();

            if (products.Count == 0)
            {
                return new ErrorDataResult<List<ProductListDto>>(Messages.Product.NotFound(true));
            }
            return new SuccessDataResult<List<ProductListDto>>(_mapper.Map<List<ProductListDto>>(products));
        }

        private IResult CheckIfProductNameExists(string name)
        {
            var result = _productRepository.GetList(name).Any();
            if (result)
            {
                return new ErrorResult(Messages.Product.NameAlreadyExists());
            }
            return new SuccessResult();
        }
    }
}