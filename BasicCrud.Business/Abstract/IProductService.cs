using BasicCrud.Core.Utilities.Results;
using BasicCrud.Entities.Dtos;

namespace BasicCrud.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<ProductListDto>> GetList();
        IDataResult<ProductDto> GetById(int productId);
        IResult Add(ProductAddDto productAddDto);
        IResult Update(ProductUpdateDto productUpdateDto);
        IResult Delete(int productId);
    }
}