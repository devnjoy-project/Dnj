using System;
using System.ComponentModel.DataAnnotations;
using Dnj.Shared.Net.Features.UnitOfWork.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dnj.Samples.UnitOfWork.Server.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UnitOfWorkContext(
                       serviceProvider.GetRequiredService<
                           DbContextOptions<UnitOfWorkContext>>()))
            {
                if (context.UnitOfWorkSet.Any())
                {
                    return;   // DB has been seeded
                }

                context.UnitOfWorkSet.AddRange(
                    new UnitOfWorkEntity
                    {
                        ParamString = "Camel",
                        ParamDate = DateTime.Parse("1989-2-12"),
                        ParamInt = 10,
                        ParamDecimal = 7.99M
                    },

                    new UnitOfWorkEntity
                    {
                        ParamString = "Panda",
                        ParamDate = DateTime.Parse("1989-2-12"),
                        ParamInt = 10,
                        ParamDecimal = 7.99M
                    },
                    new UnitOfWorkEntity
                    {
                        ParamString = "Ñú",
                        ParamDate = DateTime.Parse("1989-2-12"),
                        ParamInt = 10,
                        ParamDecimal = 7.99M
                    },
                    new UnitOfWorkEntity
                    {
                        ParamString = "Anonymous",
                        ParamDate = DateTime.Parse("1989-2-12"),
                        ParamInt = 10,
                        ParamDecimal = 7.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
