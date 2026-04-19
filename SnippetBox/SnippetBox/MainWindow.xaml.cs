using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace SnippetBox
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer Simple = new SoundPlayer("G:\\VS projects\\SnippetBox\\SnippetBox\\Sounds\\cartoon-button-click-sound.wav");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewVault_Click(object sender, RoutedEventArgs e)
        {
            
            Simple.Play();
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Simple.Play();
        }
    }
}
