using Domain.Shared.ViewModels;

namespace Mock.Generator
{
    public static class JurosModel
    {
        public static JurosViewModel JurosViewModelValoresFixosFake()
        {
            return new JurosViewModel
            {
                TempoMeses = 5,
                ValorInicial = 100
            };
        }
    }
}
