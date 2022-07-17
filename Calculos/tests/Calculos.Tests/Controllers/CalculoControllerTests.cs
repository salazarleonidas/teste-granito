using Calculos.Controllers;
using Domain.Services.Interfaces;
using Domain.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Mock.Generator;
using Moq;
using System.Net;

namespace Calculos.Tests.Controllers
{
    public class CalculoControllerTests
    {
        private readonly Mock<IDomainService> _domainService;

        public CalculoControllerTests()
        {
            _domainService = new Mock<IDomainService>();
        }

        [Fact]
        public async void CalculaJuros_Sucesso()
        {
            // Arrange
            var juros = JurosModel.JurosViewModelValoresFixosFake();
            var calculoController = new CalculoController(_domainService.Object);

            _domainService.Setup(q => q.CalcularJurosAsync(It.IsAny<JurosViewModel>())).Returns(Task.FromResult("105,10"));

            // Act
            var result = await calculoController.CalculaJuros(juros);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void CalculaJuros_ErroRequisicaoTaxaJuros()
        {
            // Arrange
            var juros = JurosModel.JurosViewModelValoresFixosFake();
            var calculoController = new CalculoController(_domainService.Object);

            _domainService.Setup(q => q.CalcularJurosAsync(It.IsAny<JurosViewModel>()))
                .Throws(new HttpRequestException("Pagina não encontrada", null, HttpStatusCode.NotFound));

            // Act
            var result = await calculoController.CalculaJuros(juros);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
