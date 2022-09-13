using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace APanel.Data
{
    public class FileManagerData
    {
        public Visibility? DirectoryInformationVisibility { get; set; }

        public Visibility? FileInformationVisibility { get; set; }

        public string? Icon { get; set; }

        public string? Name { get; set; }

        public string? Size { get; set; }

        public string? ToolTipSize { get; set; }

        public string? CreationTime { get; set; }

        public string? ModificationTime { get; set; }

        public string? Folders { get; set; }

        public string? Files { get; set; }

        public string? FileExtension { get; set; }
    }
}
