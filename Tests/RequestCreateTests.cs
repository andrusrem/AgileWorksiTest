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
    public class RequestCreateTests
    {
        private readonly RequestCreateModel _createModel;
        private readonly Mock<IRequestService> _requestService;

        public RequestCreateTests()
        {
            _requestService = new Mock<IRequestService>();
            _createModel = new RequestCreateModel(_requestService.Object);
        }
        [Fact]
        public void OnPost_Return_RedirectToPage()
        {
            //Arrange
            int id = 0;
            string baseUrl = "http://localhost:5091/api/request/";

            string description = "Test";
            DateTime whenFinish = DateTime.UtcNow;

            var newRequest = _requestService.Setup(u => u.PostRequest(baseUrl, new { Id = id, Description = description, WhenFinish = whenFinish }));
            //Act
            var result = _createModel.OnPost();
            //Assert
            Assert.IsType<RedirectToPageResult>(result.Result);
        }
    }
}
