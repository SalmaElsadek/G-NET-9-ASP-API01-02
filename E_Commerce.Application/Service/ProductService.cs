using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTO.Products;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Application.Service
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IReadOnlyList<BrandDTO>>> GetAllBrandsAsync(CancellationToken ct = default)
        {
            var brands= await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync(ct);
            var data = _mapper.Map< IReadOnlyList<BrandDTO>>(brands);
            return Result<IReadOnlyList<BrandDTO>>.Ok(data);
        }

        public async Task<Result<IReadOnlyList<ProductDTO>>> GetAllProductsAsync(CancellationToken ct = default)
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(ct);
            var data = _mapper.Map<IReadOnlyList<ProductDTO>>(products);
            return Result<IReadOnlyList<ProductDTO>>.Ok(data);
        }

        public async Task<Result<IReadOnlyList<TypeDTO>>> GetAllTypesAsync(CancellationToken ct = default)
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct);
            var data = _mapper.Map<IReadOnlyList<TypeDTO>>(types);
            return Result<IReadOnlyList<TypeDTO>>.Ok(data);
        }

        public async Task<Result<ProductDTO>> GetProductByIdAsync(int id, CancellationToken ct = default)
        {
            var product= await _unitOfWork.GetRepository<Product,int>().GetByIdAsync(id, ct);
            if (product == null)
                return Error.NotFound("Product.NotFound", $"Product With Id {id} Is Not FOund");

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
