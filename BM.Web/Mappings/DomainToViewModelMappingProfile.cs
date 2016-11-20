using AutoMapper;
using BM.Data.Entities;
using BM.Data;
using BM.DemoWeb.ViewModels;

namespace BM.DemoWeb.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            //CreateMap<Category, CategoryViewModel>();
            //CreateMap<Gadget, GadgetViewModel>();
            CreateMap<AppUser, UserViewModel>();
        }
    }
}