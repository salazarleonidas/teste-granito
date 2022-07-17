using Domain.Shared.ViewModels;

namespace Domain.Services.Interfaces
{
    public interface IDomainService
    {
        Task<string> CalcularJurosAsync(JurosViewModel jurosViewModel);
    }
}
