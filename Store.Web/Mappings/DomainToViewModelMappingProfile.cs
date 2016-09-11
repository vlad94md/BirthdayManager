using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Store.Model;
using Store.Web.ViewModels;

namespace Store.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Gadget, GadgetViewModel>();
        }
    }
}