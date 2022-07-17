﻿using AutoMapper;

namespace Domain.Shared.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModel.ModelToViewModelProfile());
            });
        }
    }
}
