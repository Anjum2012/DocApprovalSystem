using Moq;
using Microsoft.AspNetCore.Mvc;
using DocumentAccessApproval.Api.Controllers;
using DocumentAccessApproval.Application.DTO;
using DocumentAccessApproval.Application.Repositories;
using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Tests
{
    [TestClass]
    public class AccessRequestServiceTests
    {
        private Mock<IAccessRequestRepository> _mockRepo;
        private AccessRequestController _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockRepo = new Mock<IAccessRequestRepository>();
            _controller = new AccessRequestController(_mockRepo.Object);
        }

        [TestMethod]
        public async Task CreateAccessRequest_ValidRequest_ReturnsOkResult()
        {
            // Arrange
            var dto = new CreateAccessRequestDto
            {
                RequestorUserId = 1,
                DocumentId = 10,
                Reason = "Quarterly report",
                AccessType = (int)AccessType.Read
            };

            var expected = new CreateAccessRequestDto
            {
                RequestorUserId = dto.RequestorUserId,
                DocumentId = dto.DocumentId,
                Reason = dto.Reason,
                AccessType = (int)AccessType.Read
            };

            _mockRepo.Setup(repo => repo.CreateAccessRequestAsync(It.IsAny<CreateAccessRequestDto>()))
                     .ReturnsAsync(expected);

            // Act
            var result = await _controller.CreateAccessRequest(dto);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);

            var returned = okResult?.Value as CreateAccessRequestDto;
            Assert.IsNotNull(returned);

            Assert.AreEqual(dto.RequestorUserId, returned.RequestorUserId);
        }
    }
}