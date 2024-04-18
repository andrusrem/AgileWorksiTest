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
using NuGet.Protocol;

namespace AgileWorksiTest.Tests
{
    public class RequestServiceTests
    {
        private readonly RequestService _service;
        private readonly Mock<IHttpRequestService> _mockHttpRequestService;
        public RequestServiceTests()
        {
            _mockHttpRequestService = new Mock<IHttpRequestService>();
            _service = new RequestService(_mockHttpRequestService.Object);
        }

        [Fact]
        public async Task GetAllRequests_return_all_requests()
        {
            //Arrange
            string baseUrl = "http://localhost:5091/api/request/";
            object data = null;
            List<Request> list = new List<Request>{
                new Request
                {
                    Id = 0,
                    Description = "Test",
                    WhenMade = DateTime.UtcNow,
                    WhenFinish = DateTime.UtcNow,
                    Status = false
                }
            };
            _mockHttpRequestService.Setup(u => u.SendRequest<List<Request>>(baseUrl, HttpMethod.Get, data)).ReturnsAsync(list).Verifiable();
            //Act
            var result = await _service.GetAllRequests(baseUrl);

            //Assert
            Assert.Equal(list.Count, result.Count);
        }
        [Fact]
        public async Task GetAllFinishedRequests_return_all_requests()
        {
            //Arrange
            string baseUrl = "http://localhost:5091/api/request/finished";
            object data = null;
            List<Request> list = new List<Request>{
                new Request
                {
                    Id = 0,
                    Description = "Test",
                    WhenMade = DateTime.UtcNow,
                    WhenFinish = DateTime.UtcNow,
                    Status = true
                }
            };
            _mockHttpRequestService.Setup(u => u.SendRequest<List<Request>>(baseUrl, HttpMethod.Get, data)).ReturnsAsync(list).Verifiable();
            //Act
            var result = await _service.GetAllFinishedRequests(baseUrl);

            //Assert
            Assert.Equal(list.Count, result.Count);
        }
        [Fact]
        public async Task GetRequest_return_needed_request()
        {
            //Arrange
            int id = 0;
            string baseUrl = $"http://localhost:5091/api/request/{id}";
            object data = null;
            List<Request> list = new List<Request>{
                new Request
                {
                    Id = 0,
                    Description = "Test",
                    WhenMade = DateTime.UtcNow,
                    WhenFinish = DateTime.UtcNow,
                    Status = true
                }
            };
            _mockHttpRequestService.Setup(u => u.SendRequest<Request>(baseUrl, HttpMethod.Get, data)).ReturnsAsync(list.Where(x => x.Id == id).FirstOrDefault()).Verifiable();
            //Act
            var result = await _service.GetRequest(baseUrl);

            //Assert
            Assert.Equal(id, result.Id);
        }
        [Fact]
        public async Task PostRequest_Return_Request_If_it_saved()
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
            object data = request.ToJson();
            string baseUrl = "http://localhost:5091/api/request/";
            _mockHttpRequestService.Setup(u => u.SendRequest<Request>(baseUrl, HttpMethod.Post, data)).ReturnsAsync(request).Verifiable();
            //Act
            var result = await _service.PostRequest(baseUrl, data);

            //Assert
            Assert.Equal(request, result);
        }
        [Fact]
        public async Task GiveId_Return_Next_Id()
        {
            //Arrange
            object data = null;
            string baseUrl = "http://localhost:5091/api/request/";
            List<Request> list = new List<Request>{
                new Request
                {
                    Id = 0,
                    Description = "Test",
                    WhenMade = DateTime.UtcNow,
                    WhenFinish = DateTime.UtcNow,
                    Status = true
                }
            };
            _mockHttpRequestService.Setup(u => u.SendRequest<List<Request>>(baseUrl, HttpMethod.Get, data)).ReturnsAsync(list).Verifiable();
            //Act
            var result = await _service.GiveId(baseUrl);
            //Assert
            Assert.Equal(list.Count, result);
        }
    }
}
