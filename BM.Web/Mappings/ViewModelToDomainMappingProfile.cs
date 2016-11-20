using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BM.Data;
using BM.DemoWeb.ViewModels;

namespace BM.DemoWeb.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
        //    CreateMap<GadgetFormViewModel, Gadget>()
        //        .ForMember(g => g.Name, map => map.MapFrom(vm => vm.GadgetTitle))
        //        .ForMember(g => g.Description, map => map.MapFrom(vm => vm.GadgetDescription))
        //        .ForMember(g => g.Price, map => map.MapFrom(vm => vm.GadgetPrice))
        //        .ForMember(g => g.Image, map => map.MapFrom(vm => vm.File.FileName))
        //        .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.GadgetCategory));
        }
    }
}