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
                MessageBox.Show("Please enter a task");
                return;
            }

            string title = TitleInputBox.Text;
            bool isCompleted = false;
            DateTime? dueDate = DueDatePicker.SelectedDate;
            string priority = ((ComboBoxItem)PriorityBox.SelectedItem)?.Content.ToString();

            ToDoItem newTask = new ToDoItem
            {
                Title = title,
                IsComplete = isCompleted,
                DueDate = dueDate,
                Priority = priority
            };

            ActiveTasks.Add(newTask);
            TitleInputBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityBox.SelectedIndex = -1;
            TaskCoutner();
            ActiveTaskListBox.Items.Refresh();
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem selectedTask = ActiveTaskListBox.SelectedItem as ToDoItem;
            if (selectedTask == null)
            {
                MessageBox.Show("Please select a task");
                return;
            }

            selectedTask.IsComplete = true;
            CompleteTasks.Add(selectedTask);
            ActiveTasks.Remove(selectedTask);
            ActiveTaskListBox.Items.Refresh();
            TaskCoutner();
            CompleteTaskListBox.Items.Refresh();

        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem ActiveselectedTask = ActiveTaskListBox.SelectedItem as ToDoItem;
            ToDoItem CompleteselectedTask = CompleteTaskListBox.SelectedItem as ToDoItem;

            if (ActiveselectedTask == null && CompleteselectedTask == null)
            {
                MessageBox.Show("Please select a task");
                return;
            }


            if (string.IsNullOrWhiteSpace(TitleInputBox.Text))
            {
                MessageBox.Show("Please enter a task");
                return;
            }

            if (ActiveselectedTask != null)
            {
                ActiveselectedTask.Title = TitleInputBox.Text;
                if (DueDatePicker.SelectedDate != null)
                {
                    ActiveselectedTask.DueDate = DueDatePicker.SelectedDate;

                }
                if (PriorityBox.SelectedItem != null)
                {
                    ActiveselectedTask.Priority = PriorityBox.SelectedItem.ToString();
                }
            }


            if (CompleteselectedTask != null)
            {
                CompleteselectedTask.Title = TitleInputBox.Text;
                if (DueDatePicker.SelectedDate != null)
                {
                    CompleteselectedTask.DueDate = DueDatePicker.SelectedDate;

                }
                if (PriorityBox.SelectedItem != null)
                {
                    CompleteselectedTask.Priority = PriorityBox.SelectedItem.ToString();
                }
            }

            TaskCoutner();
            ActiveTaskListBox.Items.Refresh();
            CompleteTaskListBox.Items.Refresh();

        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem ActiveselectedTask = ActiveTaskListBox.SelectedItem as ToDoItem;
            ToDoItem CompleteselectedTask = CompleteTaskListBox.SelectedItem as ToDoItem;

            if (ActiveselectedTask == null && CompleteselectedTask == null)
            {
                MessageBox.Show("Please select a task");
                return;
            }

            if (ActiveselectedTask != null)
            {
                ActiveTasks.Remove(ActiveselectedTask);
            }


            if (CompleteselectedTask != null)
            {
                CompleteTasks.Remove(CompleteselectedTask);

            }

            TaskCoutner();
            ActiveTaskListBox.Items.Refresh();
            CompleteTaskListBox.Items.Refresh();

        }

        private void TaskCoutner()
        {

            ActiveTaskCounter.Text = $"Acitve: {ActiveTasks.Count()}";
            CompleteTaskCounter.Text = $"Complete: {CompleteTasks.Count()}";
        }
    }
}