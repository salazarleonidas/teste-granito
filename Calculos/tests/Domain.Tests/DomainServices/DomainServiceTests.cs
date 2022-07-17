using AutoMapper;
using Domain.Http.Interfaces;
using Domain.Services.DomainServices;
using Domain.Shared.AutoMapper;
using Mock.Generator;
using Moq;
using System.Net;

namespace Domain.Tests.DomainServices
{
    public class DomainServiceTests
    {
        private readonly IMapper _mapper;

        private readonly Mock<IHttpTaxas> _httpTaxas;

        public DomainServiceTests()
        {
            _mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            _httpTaxas = new Mock<IHttpTaxas>();
        }

        [Fact]
        public async void CalcularJurosAsync_Sucesso()
        {
            //Arrange
            var jurosViewModel = JurosModel.JurosViewModelValoresFixosFake();

            _httpTaxas.Setup(q => q.GetTaxasAsync()).Returns(Task.FromResult(0.01));

            var service = new DomainService(_httpTaxas.Object, _mapper);

            //Act
            var valorFinal = await service.CalcularJurosAsync(jurosViewModel);

            //Assert
            Assert.Equal("105,10", valorFinal);
        }

        [Fact]
        public async Task CalcularJurosAsync_FalhaHttpTaxas_NotFoundAsync()
        {
            //Arrange
            var jurosViewModel = JurosModel.JurosViewModelValoresFixosFake();

            _httpTaxas.Setup(q => q.GetTaxasAsync()).Throws(new HttpRequestException("Pagina não encontrada", null, HttpStatusCode.NotFound));

            var service = new DomainService(_httpTaxas.Object, _mapper);

            //Act
            async Task act() => await service.CalcularJurosAsync(jurosViewModel);

            //Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(act);

            Assert.Equal("Pagina não encontrada", exception.Message);
            Assert.Equal(HttpStatusCode.NotFound, exception.StatusCode);
        }
    }
}