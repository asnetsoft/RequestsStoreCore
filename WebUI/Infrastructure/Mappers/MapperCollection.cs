using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Infrastructure.Mappers
{
    public static class MapperCollection
    {
        public static class MapCollection
        {
            public static void Init()
            {
                Mapper.Initialize(cfg =>
                {

                    cfg.CreateMap<Statuses, StatusesViewModel>();
                    cfg.CreateMap<Statuses, StatusesViewModel>().ReverseMap();
                    cfg.CreateMap<Requests, RequestsViewModel>();
                    cfg.CreateMap<Requests, RequestsViewModel>().ReverseMap();

                    cfg.CreateMap<RequestsStore, RequestsStoreViewModel>()
                                                    .ForMember(dest => dest.Requests, (IMemberConfigurationExpression<RequestsStore, RequestsStoreViewModel, RequestsViewModel> opt) => opt.MapFrom(src => src.Requests))
                                                    .ForMember(dest => dest.Statuses, (IMemberConfigurationExpression<RequestsStore, RequestsStoreViewModel, StatusesViewModel> opt) => opt.MapFrom(src => src.Statuses));
                    cfg.CreateMap<RequestsStore, RequestsStoreViewModel>()
                                                   .ForMember(dest => dest.Requests, (IMemberConfigurationExpression<RequestsStore, RequestsStoreViewModel, RequestsViewModel> opt) => opt.MapFrom(src => src.Requests))
                                                   .ForMember(dest => dest.Statuses, (IMemberConfigurationExpression<RequestsStore, RequestsStoreViewModel, StatusesViewModel> opt) => opt.MapFrom(src => src.Statuses)).ReverseMap();

                });

            }
        }
    }
}