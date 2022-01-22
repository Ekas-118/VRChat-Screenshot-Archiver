using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRC_Screenshot_Archiver
{
    public class ArchiveSettings
    {
        public string SourceDirectory { get; set; }
        public string DestinationDirectory { get; set; }
        public Grouping GroupingSettings { get; set; }
    }
}
