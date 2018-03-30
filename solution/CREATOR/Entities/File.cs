using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace CREATOR.Entities
{
    public class File : INotifyPropertyChanged
    {
        private string _fileName;
        private bool _isSelected = true;
        public event PropertyChangedEventHandler PropertyChanged;
        public File()
        { }

        public File(string fileName)
        {
            _fileName = fileName;
        }

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        // is selected to add
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        // create or copy file to the selection path
        public void Create(string path)
        {
            string fullPath = path + "\\" + _fileName;

            // take file from resources in surrent project
            FileInfo fileInfo = new FileInfo(@"../../Resources/" + this.FileName);
            
            if (fileInfo.Exists)
            {
                fileInfo.CopyTo(fullPath);
            }
            else
            {
                fileInfo = new FileInfo(fullPath);
                fileInfo.Create();
            }
        }


    }
}
