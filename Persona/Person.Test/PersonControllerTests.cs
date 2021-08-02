namespace Person.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Person.API.Controllers;
    using Person.API.FakeDB;
    using Person.API.Validators;
    using Person.API.Models;
    using Xunit;

    public class PersonControllerTests
    {
        private PersonsFakeDb _fakeDb;
        private PersonValidator _personValidator;
        private PersonsController _controller;

        public PersonControllerTests()
        {
            _fakeDb = new PersonsFakeDb();
            _personValidator = new PersonValidator();
            _controller = new PersonsController(_fakeDb, _personValidator);
        }

        [Fact]
        public void Should_return_new_product_id()
        {
            //Arrange
            var product = new Person
            {
                Name = "Name",
                Age = 50,
                Email = "string@fff.com",
                Adress = "string",
                Phone = "2345678",
                Mobile = "3052289420",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 213450
            };

            //Act
            var result = _controller.Save(product);
            var convertedRersult = result.Result as OkObjectResult;

            //Assert
            Assert.IsType<int>(convertedRersult.Value);
        }

        [Fact]
        public void Should_return_BadRequest_for_validation_of_model_failure_name_empty()
        {
            //Arrange
            var person = new Person
            {
                Name = "",
                Age = 50,
                Email = "string@fff.com",
                Adress = "string",
                Phone = "2345678",
                Mobile = "3052289420",
                State = true,
                BirthDate = System.DateTime.Now,
                ZipCode = 213450
            };

            //Act
            var result = _controller.Save(person);

            //Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(result.Result);
        }

        
    }
}
