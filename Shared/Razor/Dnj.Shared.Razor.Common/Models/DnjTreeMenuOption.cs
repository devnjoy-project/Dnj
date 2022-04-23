using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnj.Shared.Razor.Common.Models
{
    public class DnjTreeMenuOption
    {
        public string Label { get; set; } = "Default Option Label";
        public string? Href { get; set; }

        public List<DnjTreeMenuOption> SubMenuOptions { get; set; } = new List<DnjTreeMenuOption>();
    }
}
