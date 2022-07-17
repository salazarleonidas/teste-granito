using AutoMapper;
using Domain.Shared.Models;
using Domain.Shared.ViewModels;

namespace Domain.Shared.AutoMapper.ModelToViewModel
{
    public class ModelToViewModelProfile : Profile
    {
        public ModelToViewModelProfile()
        {
            CreateMap<JurosViewModel, Juros>().ReverseMap();
        }
    }
}
