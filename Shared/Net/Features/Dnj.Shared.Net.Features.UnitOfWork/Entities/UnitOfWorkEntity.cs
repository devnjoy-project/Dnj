using Dnj.Shared.Net.Data.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Dnj.Shared.Net.Features.UnitOfWork.Entities
{
    [Table("UnitOfWork")]
    public class UnitOfWorkEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get ; set ; }
        public string? ParamString { get; set; }
        public int ParamInt { get; set; }
        public DateTime ParamDate { get; set; }
        public decimal ParamDecimal { get; set; }
    }
}
