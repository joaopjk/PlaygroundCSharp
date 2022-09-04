using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () =>
            {
                Category category = new(1, "CategoryName");
            };
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () =>
            {
                Category category = new(-1, "CategoryName");
            };
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid id value!");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () =>
            {
                Category category = new(1, "Ca");
            };
            action.Should()
                .Throw<DomainExceptionValidation>()
                   .WithMessage("Invalid name, too short, minimum 3 characters.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () =>
            {
                Category category = new(1, "");
            };
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () =>
            {
                Category category = new(1, null);
            };
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
