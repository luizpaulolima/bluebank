using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueBank.WebApp;

namespace BlueBank.WebApp.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Models.ContaViewModels, EntityFramework.Conta>();
        }
    }
}