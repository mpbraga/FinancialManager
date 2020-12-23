using FinancialManager.Services;
using FinancialManager.Services.Interfaces;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace FinancialManager.Tests.Services
{
    public class FileServiceTests
    {
        private Mock<IBillService> _billService;
        private Mock<ISupplierService> _supplierService;
        private Mock<ISupplierFilePatternService> _supplierFilePatternService;
        private Mock<ILogger<FileService>> _logger;

        public FileServiceTests()
        {
            _billService = new Mock<IBillService>();
            _supplierService = new Mock<ISupplierService>();
            _supplierFilePatternService = new Mock<ISupplierFilePatternService>();
            _logger = new Mock<ILogger<FileService>>();
        }

        private FileService BuildService() => new FileService(
            _billService.Object,
            _supplierService.Object,
            _supplierFilePatternService.Object,
            _logger.Object
            );

        [Fact]
        public void FileService_ProcessFile_ShouldLogErrorWhenFilePathIsNullOrEmpty()
        {
            var service = BuildService();

            var exception = Assert.ThrowsAsync<Exception>(() =>
                service.ProcessFile("")).Result;

            exception.Should().BeOfType<Exception>(); // When type is implemented, validate with the new type
            exception.Message.Should().Be("Arquivo inválido");
        }

        [Fact]
        public void FileService_ProcessFile_ShouldLogErrorWhenFilePathIsNullOrEmpty1()
        {
            var service = BuildService();

            var exception = Assert.ThrowsAsync<Exception>(() =>
                service.ProcessFile("456")).Result;

            exception.Should().BeOfType<Exception>();
            exception.Message.Should().Be("Arquivo inexistente");
        }
    }
}
