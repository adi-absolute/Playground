using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GUI
{
    public struct FileInfo
    {
        public string Name;
        public Stream Data;

        public FileInfo(string n, Stream s)
        {
            Name = n; Data = s;
        }
    }

    public delegate void FileSelectHandler(List<FileInfo> files);

    public interface IView
    {
        void SetVisibility(bool visible);
        void SetData(List<FileMetrics> fileMetrics);
        void UpdateDisplay();

        event FileSelectHandler FilesSelected;
    }
}
