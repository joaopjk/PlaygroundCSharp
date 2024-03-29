﻿using CleanArchMvc.Application.CQRS.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.CQRS.Products.Handlers
{
  public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
  {
    private readonly IProductRepository _repository;

    public ProductCreateCommandHandler(IProductRepository repository)
    {
      _repository = repository;
    }

    public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
      var product = new Product(request.Name, request.Description, request.Price, request.Stock, request.Image);

      if (product == null)
      {
        throw new ApplicationException("Error to creating entity");
      }
      else
      {
        product.CategoryId = request.CategoryId;
        return await _repository.CreateAsync(product);
      }
    }
  }
}
