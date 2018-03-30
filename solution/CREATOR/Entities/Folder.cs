using System.Collections.Generic;

namespace CREATOR.Entities
{
    public class Folder : File
    {
        private List<File> _files = new List<File>();
        private string _folderName;
        public Folder(string folderName)
        {
            _folderName = folderName;
        }

        public List<File> Files
        {
            get { return _files; }
            set { _files = value; }
        }

        public string FolderName
        {
            get { return _folderName; }
            set { _folderName = value; }
        }

        public void Add(File file)
        {
            _files.Add(file);
        }
    }
}
