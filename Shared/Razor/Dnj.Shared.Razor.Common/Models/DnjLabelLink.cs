using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dnj.Shared.Razor.Common.Models
{
    public class DnjLabelLink
    {
        public string Label { get; set; } = "";
        public string? Href { get; set; }

        public string CssClass { get; set; } = "px-3";

        public string? CssIonicIcon { get; set; }

    }
}
