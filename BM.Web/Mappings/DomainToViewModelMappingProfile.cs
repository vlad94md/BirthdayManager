using AutoMapper;
using BM.Model;
using BM.Model.Models;
using BM.Web.ViewModels;

namespace BM.Web.Mappings
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