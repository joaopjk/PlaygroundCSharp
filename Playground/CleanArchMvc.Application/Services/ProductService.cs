using AutoMapper;
using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Application.CQRS.Products.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        //private readonly IProductRepository _repository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductService(/*IProductRepository repository*/IMediator mediator, IMapper mapper)
        {
            //_repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _repository.CreateAsync(productEntity);

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            //var productEntity = await _repository.GetByIdAsync(id);
            //return _mapper.Map<ProductDTO>(productEntity);

            var productByIdQuery = new GetProductByIdQuery(id.Value);
            var result = await _mediator.Send(productByIdQuery);

            return _mapper.Map<ProductDTO>(result);
        }

        //public async Task<ProductDTO> GetProductCategory(int? id)
        //{
        //    //var productEntity = await _repository.GetProductCategoryAsync(id);
        //    //return _mapper.Map<ProductDTO>(productEntity);

        //    var productByIdQuery = new GetProductByIdQuery(id.Value);
        //    var result = await _mediator.Send(productByIdQuery);

        //    return _mapper.Map<ProductDTO>(result);
        //}

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            // var productsEntity = await _repository.GetProductsAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);

            var productsQuery = new GetProductsQuery();
            var result = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task Remove(int? id)
        {
            //var productEntity = _repository.GetByIdAsync(id).Result;
            //await _repository.RemoveAsync(productEntity);

            var productRemoveCommand = new ProductRemoveCommand(id.Value);
            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO productDTO)
        {
            //var productEntity = _mapper.Map<Product>(productDTO);
            //await _repository.UpdateAsync(productEntity);

            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
