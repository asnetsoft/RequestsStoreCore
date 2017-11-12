using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace WebUI.Infrastructure.Mappers
{
    public class CommonMapper : IMapper
    {
        static CommonMapper()
        {
            MapperCollection.MapCollection.Init();

        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }
    }
}
