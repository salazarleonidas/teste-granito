using AutoMapper;
using Domain.Http.Interfaces;
using Domain.Services.Interfaces;
using Domain.Shared.Models;
using Domain.Shared.ViewModels;

namespace Domain.Services.DomainServices
{
    public class DomainService : IDomainService
    {
        private readonly IHttpTaxas _httpTaxas;
        private readonly IMapper _mapper;

        public DomainService(IHttpTaxas httpTaxas, IMapper mapper)
        {
            _httpTaxas = httpTaxas;
            _mapper = mapper;
        }

        public async Task<string> CalcularJurosAsync(JurosViewModel jurosViewModel)
        {
            var juros = _mapper.Map<Juros>(jurosViewModel);
            var taxa = await _httpTaxas.GetTaxasAsync();

            var valorFinal = Convert.ToDouble(juros.ValorInicial) * Math.Pow(1 + taxa, juros.TempoMeses);

            return valorFinal.ToString("F2");
        }
    }
}
