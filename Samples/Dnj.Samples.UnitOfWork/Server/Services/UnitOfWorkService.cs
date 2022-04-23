using Dnj.Shared.Net.Features.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dnj.Shared.Net.Data.Abstractions;
using Dnj.Samples.UnitOfWork.Server.Data;
using Dnj.Samples.UnitOfWork.Shared;

namespace Dnj.Samples.UnitOfWork.Server.Services
{
    public class UnitOfWorkService : DnjService
    {
        private readonly UnitOfWorkContext _context;

        public UnitOfWorkService(UnitOfWorkContext ctx){
            _context = ctx;
        }
        public async Task<List<UnitOfWorkDto>> Get()
        {
            var items = await _context.UnitOfWorkSet.Select(t =>
                new UnitOfWorkDto()
                {
                    Id = t.Id,
                    ParamString = t.ParamString,
                    ParamDate = t.ParamDate,
                    ParamDecimal = t.ParamDecimal,
                    ParamInt = t.ParamInt
                }).ToListAsync();

            return items;
        }
        public async Task<UnitOfWorkDto> Get(Guid id)
        {
            
            var unitOfWork = await _context.UnitOfWorkSet.FirstOrDefaultAsync(a => a.Id == id);
            return MapTo<UnitOfWorkEntity,UnitOfWorkDto>(unitOfWork);
        }

        public async Task<Guid> Post(UnitOfWorkDto unitOfWork)
        {
            _context.Add(MapTo<UnitOfWorkDto, UnitOfWorkEntity>(unitOfWork));
            await _context.SaveChangesAsync();
            return unitOfWork.Id; 
        }
        public async Task Put(UnitOfWorkDto unitOfWork)
        {
            _context.Entry(MapTo<UnitOfWorkDto,UnitOfWorkEntity>(unitOfWork)).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var unitOfWork = new UnitOfWorkDto { Id = id };
            _context.Remove(MapTo<UnitOfWorkDto, UnitOfWorkEntity>(unitOfWork));
            await _context.SaveChangesAsync();
        }
    }
}
