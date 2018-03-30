using CREATOR.Windows;
using MahApps.Metro.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using Chendrov = CREATOR.Entities;

namespace CREATOR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Chendrov::File> folders = new ObservableCollection<Chendrov::File>();
        public event PropertyChangedEventHandler PropertyChanged;
        private string _path;
        private string _folderName;
        public MainWindow()
        {
            InitializeComponent();

            // initialize folders for binding
            InitializeFolders();
           
            txtPath.DataContext = this;
            txtFolderName.DataContext = this;
            treeViewFolders.ItemsSource = folders;
        }

        private void InitializeFolders()
        {
            // index file
            Chendrov::File fileIndex = new Chendrov::File("index.html");

            // img folder
            Chendrov::Folder folderImg = new Chendrov::Folder("images");

            // css folder
            Chendrov::Folder folderCSS = new Chendrov::Folder("css");
            folderCSS.Add(new Chendrov::File("style.css"));
            folderCSS.Add(new Chendrov::File("bootstrap.min.css"));
            
            // script folder
            Chendrov::Folder folderJS = new Chendrov::Folder("js");
            folderJS.Add(new Chendrov::File("script.js"));
            folderJS.Add(new Chendrov::File("jquery-3.2.1.min.js"));
            folderJS.Add(new Chendrov::File("bootstrap.min.js"));
            
            // libs folder
            Chendrov::Folder folderLibs = new Chendrov::Folder("libs");
            folderLibs.Add(new Chendrov::File("reset.css"));

            folders.Add(folderCSS);
            folders.Add(folderJS);
            folders.Add(folderLibs);
            folders.Add(folderImg);

            folders.Add(fileIndex);
        }

        // the path to which the folder will be created
        public string Path
        {
            get { return _path; }
            set
            {
                if (value != _path)
                {
                    _path = value;
                    OnPropertyChanged("Path");
                }
            }
        }

        // the name of the folder to be created
        public string FolderName
        {
            get { return _folderName; }
            set
            {
                if (value != _folderName)
                {
                    _folderName = value;
                    OnPropertyChanged("FolderName");
                }
            }
        }


        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Browse_ButtonClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();

            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Path = folderBrowserDialog.SelectedPath;
            }
        }

        private void Generate_ButtonClick(object sender, RoutedEventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_path + "\\" + _folderName);
            // pass customMessageBox parent window
            CustomMessageBox messageBox = new CustomMessageBox(this);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
                foreach (var file in folders)
                {
                    // create all files in folder
                    if ((file as Chendrov::Folder) != null)
                    {
                        //create subdir for files
                        Chendrov::Folder folder = file as Chendrov::Folder;
                        string subDirPath = dirInfo.FullName + "\\" + folder.FolderName;
                        DirectoryInfo subDirInfo = new DirectoryInfo(subDirPath);
                        subDirInfo.Create();

                        foreach (var item in folder.Files)
                        {
                            if (item.IsSelected)
                            {
                                item.Create(subDirPath);
                            }
                        }
                    }
                    else
                    {
                        //create file in subdir
                        if (file.IsSelected)
                        {
                            file.Create(dirInfo.FullName + "\\");
                        }
                    }
                }
                messageBox.ShowDialog("The creation was completed successfully.", "Success", CustomMessageBoxStyle.Default);
            }
            else
            {
                messageBox.ShowDialog("Verify the correctness of the path.", "Error", CustomMessageBoxStyle.Error);
            }
        }
    }
}
