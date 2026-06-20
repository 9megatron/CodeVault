using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SnippetBox.Models;

namespace SnippetBox
{
    /// <summary>
    /// Логика взаимодействия для EditorWindow.xaml
    /// </summary>
    public partial class EditorWindow : Page
    {
        private ObservableCollection<Snippet> _collection;

        private Snippet _snippet;
        private bool _isNew;

        private Action _saveAction;

        public EditorWindow(Snippet snippet, ObservableCollection<Snippet> collection, Action saveCallback, bool isNew = false)
        {
            InitializeComponent();
            _snippet = snippet;
            _collection = collection;
            _saveAction = saveCallback;
            _isNew = isNew;

            TitleBox.Text = _snippet.Title;
            ContentBox.Text = _snippet.Content;
        }

        
        public EditorWindow()
        {
            InitializeComponent();
            _snippet = new Snippet { Id = 0, Title = " ", Content = " " };
            _isNew = true;
        }
       

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _snippet.Title = TitleBox.Text;
            _snippet.Content = ContentBox.Text;

            if (_isNew)
            {

            }
            _saveAction?.Invoke();
            NavigationService.GoBack();
        }
        private void DeleteButton_Click(Object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Удалить этот сниппет?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                _collection.Remove(_snippet);
                NavigationService.GoBack();
            }
        }
    }
}
