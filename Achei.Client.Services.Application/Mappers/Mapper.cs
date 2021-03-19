using AutoMapper;
using System;
using System.Linq.Expressions;

namespace Achei.Client.Services.Application.Mappers {
    public static class Mapper {

        private static AutoMapper.Configuration.MapperConfigurationExpression mapperConfiguration = new AutoMapper.Configuration.MapperConfigurationExpression();

        public static IMappingExpression<TSource, TDestination> CreateMap<TSource, TDestination>() {
            return mapperConfiguration.CreateMap<TSource, TDestination>();
        }

        public static IMappingExpression<TSource, TDestination> ForMember<TSource, TDestination, TMember, TSourceMember>(this IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TDestination, TMember>> destinationMember, Expression<Func<TSource, TSourceMember>> sourceMember) {
            return mappingExpression.ForMember(destinationMember, opt => opt.MapFrom(sourceMember));
        }

        public static IMappingExpression<TSource, TDestination> ConstructUsing<TSource, TDestination>(this IMappingExpression<TSource, TDestination> mappingExpression, Expression<Func<TSource, TDestination>> ctor) {
            return mappingExpression.ConstructUsing(ctor); 
        }

        public static void Initialize() { 
            AutoMapper.Mapper.Initialize(mapperConfiguration); 
        }

        public static TDestination Map<TDestination>(this object source) { 
            return AutoMapper.Mapper.Map<TDestination>(source); 
        } 
    }
}
