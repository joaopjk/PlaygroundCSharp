using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m,
                                99, "product image");
            };
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            {
                Product product = new(-1, "Product Name", "Product Description", 9.99m,
                                99, "product image");
            };

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () =>
            {
                Product product = new(1, "Pr", "Product Description", 9.99m, 99,
                                "product image");
            };
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m,
                                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");
            };

            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                 .WithMessage("Invalid image name, too long, maximum 250 characters.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, "Image.jpg");
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", 9.99m, 99, "Image.jpg");
            };
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () =>
            {
                Product product = new(1, "Product Name", "Product Description", -9.99m,
                                99, "Image.jpg");
            };
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Invalid price value.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () =>
            {
                Product product = new(1, "Pro", "Product Description", 9.99m, value,
                                "product image");
            };
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid stock value.");
        }
    }
}
