using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ToDoList.Models;
using System.Text.Json;
using System.IO;

namespace ToDoList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ToDoItem> ActiveTasks = new ObservableCollection<ToDoItem>();
        private ObservableCollection<ToDoItem> CompleteTasks = new ObservableCollection<ToDoItem>();
        public MainWindow()
        {
            InitializeComponent();
            ActiveTaskListBox.ItemsSource = ActiveTasks;
            CompleteTaskListBox.ItemsSource = CompleteTasks;
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleInputBox.Text))
            {
                MessageBox.Show("Please enter a title");
                return;
            }

            string title = TitleInputBox.Text;
            bool isComplete = false;
            DateTime? dueDate = DueDatePicker.SelectedDate;
            string priority = ((ComboBoxItem)PriorityBox.SelectedItem)?.Content.ToString();

            ToDoItem newTask = new ToDoItem
            {
                Title = title,
                IsComplete = isComplete,
                DueDate = dueDate,
                Priority = priority

            };

            ActiveTasks.Add(newTask);
            TitleInputBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityBox.SelectedIndex = -1;
            TaskCounter();
            ActiveTaskListBox.Items.Refresh();
            SaveTasks();
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem selectedActiveTask = ActiveTaskListBox.SelectedItem as ToDoItem;
            ToDoItem selectedCompleteTask = CompleteTaskListBox.SelectedItem as ToDoItem;

            if (selectedActiveTask == null && selectedCompleteTask == null)
            {
                MessageBox.Show("Please select a task");
                return;
            }

            if (string.IsNullOrWhiteSpace(TitleInputBox.Text))
            {
                MessageBox.Show("Please enter a title");
                return;
            }

            if (selectedActiveTask != null)
            {
                selectedActiveTask.Title = TitleInputBox.Text;
                if (DueDatePicker.SelectedDate != null)
                {
                    selectedActiveTask.DueDate = DueDatePicker.SelectedDate;

                }
                if (PriorityBox.SelectedItem != null)
                {
                    selectedActiveTask.Priority = ((ComboBoxItem)PriorityBox.SelectedItem).Content.ToString();
                }
            }

            if (selectedCompleteTask != null)
            {
                selectedCompleteTask.Title = TitleInputBox.Text;
                if (DueDatePicker.SelectedDate != null)
                {
                    selectedCompleteTask.DueDate = DueDatePicker.SelectedDate;

                }
                if (PriorityBox.SelectedItem != null)
                {
                    selectedCompleteTask.Priority = ((ComboBoxItem)PriorityBox.SelectedItem).Content.ToString();
                }
            }

            TitleInputBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityBox.SelectedIndex = -1;
            ActiveTaskListBox.Items.Refresh();
            CompleteTaskListBox.Items.Refresh();
            SaveTasks();


        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem selectedActiveTask = ActiveTaskListBox.SelectedItem as ToDoItem;
            ToDoItem selectedCompleteTask = CompleteTaskListBox.SelectedItem as ToDoItem;

            if (selectedActiveTask == null && selectedCompleteTask == null)
            {
                MessageBox.Show("Please select a task");
                return;
            }

            if (selectedActiveTask != null)
            {
                ActiveTasks.Remove(selectedActiveTask);

            }
            if (selectedCompleteTask != null)
            {
                CompleteTasks.Remove(selectedCompleteTask);

            }
            TaskCounter();
            ActiveTaskListBox.Items.Refresh();
            CompleteTaskListBox.Items.Refresh();
            SaveTasks();

        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem selectedActiveTask = ActiveTaskListBox.SelectedItem as ToDoItem;

            if (selectedActiveTask == null)
            {
                MessageBox.Show("Please select a task");
                return;

            }
            selectedActiveTask.IsComplete = true;
            CompleteTasks.Add(selectedActiveTask);
            ActiveTasks.Remove(selectedActiveTask);
            TaskCounter();
            ActiveTaskListBox.Items.Refresh();
            CompleteTaskListBox.Items.Refresh();
            SaveTasks();


        }

        private void TaskCounter()
        {
            int activeNum = ActiveTasks.Count();
            int completeNum = CompleteTasks.Count();

            ActiveTaskCounter.Text = $"Active Task Number: {activeNum}";
            CompleteTaskCounter.Text = $"Complete Task Number: {completeNum}";


        }

        private void SaveTasks()
        {
            string filePath = "ToDoList.Json";
            var payload = new
            {
                ActiveTasks = ActiveTasks,
                CompleteTasks = CompleteTasks,
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(payload, options);
            File.WriteAllText(filePath, json);

        }
    }
}