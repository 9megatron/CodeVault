using SnippetBox.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Media;
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
using System.Text.Json;
using System.IO;


namespace SnippetBox
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        SoundPlayer Simple = new SoundPlayer("G:\\VS projects\\SnippetBox\\SnippetBox\\Sounds\\cartoon-button-click-sound.wav");
        private ObservableCollection<Snippet> _snippets = new ObservableCollection<Snippet>();

        private string JsonPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "snippets.json");



        public MainPage()
        {
            InitializeComponent();
            SnippetsItemControl.DataContext = _snippets;
            LoadFromJson();
            SnippetsItemControl.DataContext = _snippets;
        }

        private void NewVault_Click(object sender, RoutedEventArgs e)
        {
            var newSnippet = new Snippet
            {
                Id = _snippets.Count + 1,
                Title = "Новый сниппет",
                Content = " "

            };
            _snippets.Add(newSnippet);
            

            Simple.Play();
        }
        private void Card_Click(object sender, MouseButtonEventArgs e)
        {
            var border = (Border)sender;
            var snippet = (Snippet)border.DataContext;


            NavigationService.Navigate(new EditorWindow(snippet, _snippets, SaveToJson));

            Simple.Play();

        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Simple.Play();
        }

        

        private void SaveToJson()
        {
            try
            {
                var listToSave = _snippets.ToList();
                string json = JsonSerializer.Serialize(listToSave, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(JsonPath, json);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Ошибка сохранения: " + ex.Message);
            }
        }
        private void LoadFromJson()
        {
            if (File.Exists(JsonPath))
            {
                string json = File.ReadAllText(JsonPath);
                var loaded = JsonSerializer.Deserialize<List<Snippet>>(json);
                _snippets.Clear();
                foreach (var s in loaded) _snippets.Add(s);
            }
        }
    }

    
}
