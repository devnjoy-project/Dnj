using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Dnj.Shared.Net.Data.Abstractions
{
    public abstract class DnjService : IDnjService<DnjService>
        
    {
        public static TU MapTo<TT, TU>(TT source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TT, TU>();
                cfg.AllowNullCollections = true;
                
            });

            var mapper = config.CreateMapper();
            return mapper.Map<TU>(source);
        }
    }
}
