using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Dnj.Samples.UnitOfWork.Shared.Resources;

namespace Dnj.Samples.UnitOfWork.Shared
{
    [DataContract]
    public class UnitOfWorkDto
    {
        [DataMember]
        public Guid Id { get ; set ; }
        [Required(ErrorMessage = "Field String is required")]
        [DataMember]
        public string? ParamString { get; set; }
        [DataMember]
        public int ParamInt { get; set; }
        [DataMember]
        public DateTime ParamDate { get; set; }
        [DataMember]
        public decimal ParamDecimal { get; set; }
    }
}
