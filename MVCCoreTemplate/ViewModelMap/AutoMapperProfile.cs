using AutoMapper;
using MVCCoreTemplate.Entities.DbEntities;
using MVCCoreTemplate.Models.ApplicationViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCCoreTemplate.ViewModelMap
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationViewModel, Application>();
        }
    }
}
