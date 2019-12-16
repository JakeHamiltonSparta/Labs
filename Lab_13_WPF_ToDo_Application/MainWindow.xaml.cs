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

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();
        Task task;
        Task taskToAdd = new Task();
        List<Category> categories = new List<Category>();
        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            using (var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.DisplayMemberPath = "Description";
            ListBoxTasks.ItemsSource = tasks;
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";
        }
        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Print out details of a selected item
            // Instance = (Convert to Task) the item seleceted in the list box by user
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextBoxID.Text = task.TaskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryID.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID-1;

                }
                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }
         
        }
        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryID.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;
                TextBoxID.Background = Brushes.White;
            }
            else
            {
                using (var db = new TasksDBEntities())
                {
                    var taskToEdit = db.Tasks.Find(task.TaskID);
                    // Update description and CategoryID
                    taskToEdit.Description = TextBoxDescription.Text;
                    int.TryParse(TextBoxCategoryID.Text, out int categotyID);
                    taskToEdit.CategoryID = categotyID;
                    db.SaveChanges();

                    // Update List Box
                    ListBoxTasks.ItemsSource = null; // Reset the listbox
                    tasks = db.Tasks.ToList(); // Get fresh list
                    ListBoxTasks.ItemsSource = tasks;

                }
                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryID.IsReadOnly = true;

                var brush = new BrushConverter();

                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryID.Background = (Brush)brush.ConvertFrom("#EEFAFF"); ;
                TextBoxID.Background = (Brush)brush.ConvertFrom("#EEFAFF");
            }
            
        }
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";

                // Set boxes to editable
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryID.IsReadOnly = false;
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;
                
                // Clear out boxes
                TextBoxID.Text = "";
                TextBoxCategoryID.Text = "";
                TextBoxDescription.Text = "";
            }
            else
            {
                ButtonAdd.Content = "Add";
                // Set boxes to Readonly
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryID.IsReadOnly = true;
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;

                var brush = new BrushConverter();

                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#EEFAFF");
                TextBoxCategoryID.Background = (Brush)brush.ConvertFrom("#EEFAFF"); ;
                TextBoxID.Background = (Brush)brush.ConvertFrom("#EEFAFF");

                // Update description and CategoryID
                int.TryParse(TextBoxCategoryID.Text, out int categoryID);

                var taskToAdd = new Task()
                {
                  Description = TextBoxDescription.Text,
                  CategoryID = categoryID
                };


                using (var db = new TasksDBEntities())
                {
                    db.Tasks.Add(taskToAdd);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }

            }

        }
        public void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Confirm";

                // Set boxes to editable
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryID.IsReadOnly = false;

                TextBoxDescription.Background = Brushes.Red;
                TextBoxCategoryID.Background = Brushes.Red;

            }
            else
            {
                using (var db = new TasksDBEntities())
                {

                    var delete = db.Tasks.Find(task.TaskID);
                    db.Tasks.Remove(delete);


                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null;
                    tasks = db.Tasks.ToList();
                    ListBoxTasks.ItemsSource = tasks;
                }
                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                // Clear out boxes
                TextBoxID.Text = "";
                TextBoxCategoryID.Text = "";
                TextBoxDescription.Text = "";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryID.Background = Brushes.White;
            }
        }
    }
}