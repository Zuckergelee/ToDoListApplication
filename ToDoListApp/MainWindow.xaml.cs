using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using ToDoListApp.DataModel;
using ToDoListApp.Services;

namespace ToDoListApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private BindingList<TasksModel> _tasksDataList;
        private FileManager _fileManager;
        private readonly string Path = $"{Environment.CurrentDirectory}\\tasksDataList.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dgToDoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileManager = new FileManager(Path);
            try
            {
                _tasksDataList = _fileManager.LoadData();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                Close();
            }
            dgToDoList.ItemsSource = _tasksDataList;
            _tasksDataList.ListChanged += _tasksDataList_ListChanged;
        }

        private void _tasksDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileManager.SaveData(sender);
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    Close();
                }
            }
        }
    }
}
