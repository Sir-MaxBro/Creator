using MahApps.Metro;
using MahApps.Metro.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace CREATOR.Windows
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : MetroWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _content;
        private string _caption;

        public CustomMessageBox()
        {
            InitializeComponent();

            txtText.DataContext = this;
            this.DataContext = this;
        }

        public CustomMessageBox(string message, string captionText)
            : this()
        {
            this.Caption = captionText;
            this.ContentText = message;
        }

        public CustomMessageBox(Window window)
            : this()
        {
            this.Owner = window;
        }


        public string Caption
        {
            get { return _caption; }
            private set
            {
                if (value != _caption)
                {
                    _caption = value;
                    OnPropertyChanged("Caption");
                }
            }
        }

        public string ContentText
        {
            get { return _content; }
            private set
            {
                if (value != _content)
                {
                    _content = value;
                    OnPropertyChanged("ContentText");
                }
            }
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Ok_ButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(Window window)
        {
            this.Owner = window;
            this.ShowDialog();
        }

        public void ShowDialog(Window window, CustomMessageBoxStyle style)
        {
            Check(style);
            ShowDialog(window);
        }

        public void ShowDialog(string message, string captionText, Window window)
        {
            this.Caption = captionText;
            this.ContentText = message;
            ShowDialog(window);
        }

        public void ShowDialog(string message, string captionText, CustomMessageBoxStyle style, Window window)
        {
            Check(style);
            ShowDialog(message, captionText, window);
        }

        public void ShowDialog(string message, string captionText, CustomMessageBoxStyle style)
        {
            Check(style);
            ShowDialog(message, captionText);
        }

        public void ShowDialog(string message, string captionText)
        {
            this.Caption = captionText;
            this.ContentText = message;
            this.ShowDialog();
        }

        // change current window style
        private void Check(CustomMessageBoxStyle style = CustomMessageBoxStyle.Default)
        {
            switch (style)
            {
                case CustomMessageBoxStyle.Error:
                    ThemeManager.ChangeAppStyle(Window.GetWindow(this),
                                    ThemeManager.GetAccent("Red"),
                                    ThemeManager.GetAppTheme("BaseDark"));
                    this.GlowBrush = Brushes.Red;
                    this.button.Style = Application.Current.Resources["CustomRedButton"] as Style;
                    break;

                case CustomMessageBoxStyle.Default:
                    ThemeManager.ChangeAppStyle(this, 
                        ThemeManager.GetAccent("Green"), 
                        ThemeManager.GetAppTheme("BaseDark"));
                    this.GlowBrush = Brushes.Green;
                    this.button.Style = Application.Current.Resources["CustomGreenButton"] as Style;
                    break;
            }
        }
    }

    public enum CustomMessageBoxStyle
    {
        Error,
        Default
    }
}
