using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GUI
{
    public delegate void FileSelectHandler(string filename, Stream s);

    public interface IView
    {
        void SetVisibility(bool visible);
        void SetData(List<FileMetrics> fileMetrics);
        void UpdateDisplay();

        event FileSelectHandler FilesSelected;
    }
}
