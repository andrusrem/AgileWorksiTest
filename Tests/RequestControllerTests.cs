using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using AgileWorksiTest.Pages;
using AgileWorksiTest.Controllers;
using AgileWorksiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using AgileWorksiTest.Service;


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
        public async Task Get_Retun_OkResult()
        {
            //Arrange
            //Act
            var result = _controller.Get() as OkObjectResult;
            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            
        }
        [Fact]
        public async Task Post_Retun_OkResult_If_Request_Added()
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
            var result = _controller.Post(request) as OkResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            
        }
        [Fact]
        public async Task Get_Retun_NotFount_If_Id_Is_Not_Valid()
        {
            //Arrange
            int id = 0;
            //Act
            var result = _controller.Get(id) as NotFoundResult;
            //Assert
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);

        }
        [Fact]
        public async Task Get_Retun_OkResult_If_Id_Is_Valid()
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
            var result = _controller.Get(id) as OkObjectResult;
            //Assert
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        [Fact]
        public async Task Put_Return_BadRequest_If_Given_Wrong_Id()
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
            var result = _controller.Put(id, request) as BadRequestResult;
            //Assert
            Assert.IsType<BadRequestResult>(result);
        }
        [Fact]
        public async Task Put_Return_NoContent_If_Given_Id_Is_Right()
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
            var result = _controller.Put(id, request) as NoContentResult;
            //Assert
            Assert.Equal(StatusCodes.Status204NoContent, result.StatusCode);
        }
    }
}
