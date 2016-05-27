using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlueBank.WebApp;

namespace BlueBank.WebApp.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<EntityFramework.Conta, Models.ContaViewModels>();
        }
    }
}