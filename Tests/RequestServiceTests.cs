using Xunit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using AgileWorksiTest.Controllers;
using AgileWorksiTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using AgileWorksiTest.Service;
using AgileWorksiTest.Pages;


namespace AgileWorksiTest.Tests
{
    public class RequestServiceTests
    {
        private readonly RequestService _service;
        private readonly Mock<IHttpRequestService> _mockHttpRequestService;
        private readonly RequestController _controller;
        public RequestServiceTests()
        {
            _mockHttpRequestService = new Mock<IHttpRequestService>();
            _controller = new RequestController();
            _service = new RequestService(_mockHttpRequestService.Object);
        }

        [Fact]
        public async Task GetAllRequests_return_all_requests()
        {
            //Arrange
            string baseUrl = "http://localhost:5091/api/request/";
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
            var result = await _service.GetAllRequests(baseUrl);
            //Assert
            Assert.NotNull(result);
        }
    }
}
