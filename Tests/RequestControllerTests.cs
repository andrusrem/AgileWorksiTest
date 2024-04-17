using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using AgileWorksiTest.Controllers;
using AgileWorksiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;


namespace AgileWorksiTest.Tests
{
    public class RequestControllerTests
    {
        private readonly RequestController _controller;

        public RequestControllerTests()
        {
            _controller = new RequestController();
        }
        [Fact]
        public void Get_Retun_OkResult()
        {
            //Arrange
            
            //Act
            var result = _controller.Get() as IActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }
        [Fact]
        public void Post_Retun_OkResult_If_Request_Added()
        {
            //Arrange

            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };

            //Act
            var result = _controller.Post(request) as IActionResult;
            //Assert
            Assert.IsType<OkResult>(result);

        }
        [Fact]
        public void Get_Retun_NotFount_If_Id_Is_Not_Valid()
        {
            //Arrange
            int id = 0;
            //Act
            var result = _controller.Get(id) as IActionResult;
            //Assert
            Assert.IsType<NotFoundResult>(result);

        }
        [Fact]
        public void Get_Retun_OkResult_If_Id_Is_Valid()
        {
            //Arrange
            int id = 0;
            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };
            var post = _controller.Post(request) as OkResult;
            //Act
            var result = _controller.Get(id) as IActionResult;
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Put_Return_BadRequest_If_Given_Wrong_Id()
        {
            //Assert
            int id = 1;
            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };
            //Act
            var result = _controller.Put(id, request) as IActionResult;
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public void Put_Return_NoContent_If_Given_Id_Is_Right()
        {
            //Assert
            int id = 0;
            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };
            var post = _controller.Post(request) as OkResult;
            //Act
            var result = _controller.Put(id, request) as IActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void Put_Return_NoFound_When_Exception_Is_Catched_And_Request_Is_Null()
        {
            //Assert
            int id = 0;
            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = true
            };
            var savedRequest = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };
            var post = _controller.Post(savedRequest) as OkResult;
            var delete = _controller.Delete(id);

            
            //Act
            var result = _controller.Put(id, request) as IActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Delete_Return_NotFound_If_Request_Is_Null()
        {
            //Assert
            int id = 1;
            //Act
            var result = _controller.Delete(id) as IActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Delete_Return_NoContent_If_Request_Deteled()
        {
            //Assert
            int id = 0;
            var request = new Request
            {
                Id = 0,
                Description = "Test",
                WhenMade = DateTime.UtcNow,
                WhenFinish = DateTime.UtcNow,
                Status = false
            };
            var post = _controller.Post(request) as OkResult;
            //Act
            var result = _controller.Delete(id) as IActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
