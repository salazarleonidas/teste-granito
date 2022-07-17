namespace Domain.Http.Interfaces
{
    public interface IHttpTaxas
    {
        Task<double> GetTaxasAsync();
    }
}
