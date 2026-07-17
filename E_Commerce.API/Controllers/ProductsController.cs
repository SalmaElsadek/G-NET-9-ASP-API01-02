using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTO.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ApiBaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        //Get all products
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDTO>>> GetAllProduct(CancellationToken ct)
        {
            var result= await _productService.GetAllProductsAsync(ct);
            return ToActionResult(result);
        }
        //Get products by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id,CancellationToken ct)
        {
            var result = await _productService.GetProductByIdAsync(id, ct);
            return ToActionResult(result);
        }
        //get all types
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<TypeDTO>>> GetAllTypes(CancellationToken ct)
        {
            return ToActionResult(await _productService.GetAllTypesAsync(ct));
        }
        //get all brands
        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<BrandDTO>>> GetAllBrands(CancellationToken ct)
        {
            return ToActionResult(await _productService.GetAllBrandsAsync(ct));
        }
    }
}
