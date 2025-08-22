using FluentValidation.TestHelper;
using Xunit;


namespace Shop.Application.Products.Commands.CreateProduct.Tests
{
    public class CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandValidatorTests
    {
        [Fact()]
        public void CreateProductValidator_ForValidCreateCommand_ShouldNotHaveValidationErrors()
        {
            // arrange

            var command = new CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand()
            {
                Name = "Test",
                Description = "Something about product",
                IsAvailable = true,
                Cost = 9.9999f,
                StockQuantity = 999,
                CategoryId = 10,
                SubCategoryId = 8,
                BrandId = 10
            };

            var validator = new CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandValidator();

            // act 

            var result = validator.TestValidate(command);

            // assert 

            result.ShouldNotHaveAnyValidationErrors();
        }
        
        [Fact()]
        public void CreateProductValidator_ForInvalidCreateCommand_ShouldHaveValidationErrors()
        {
            // arrange
            var validator = new CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommandValidator();

            var command = new CreateProductForCategoryIdAndSubcateoryIdWithBrandIdCommand()
            {
                Name = "T",
                Description = "Some",
                IsAvailable = true,
                Cost = 99999f,
                StockQuantity = 0,
                CategoryId = 0,
                SubCategoryId = 0,
                BrandId = 0
            };    

            // act 

            var result = validator.TestValidate(command);

            // assert 

            result.ShouldHaveValidationErrors();
        }
    }
}