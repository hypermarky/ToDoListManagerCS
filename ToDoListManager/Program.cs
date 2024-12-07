using System.Threading.Channels;

namespace ToDoListManager
{
    internal class Program
    {
        private static List<string> tasks;
        static void Main(string[] args)
        {                                 
                
            while (true)
            {
                Options();

                char input = char.Parse(Console.ReadLine());

                switch (input)
                {
                    case '1':
                        AddTask();
                        break;
                    case '2':
                        ViewTasks();
                        break;
                    case '3':
                        RemoveTasks();
                        break;
                    case '4':
                        return;
                    default:
                        throw new Exception();
                }
            }
        }
        public static void Options()
        {
            Console.Clear();
            Console.WriteLine("To do list manager\n==================");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. View tasks");
            Console.WriteLine("3. Remove a task");
            Console.WriteLine("4. Quit");
        }
        public static void AddTask()
        {
            tasks = new List<string>();

            Console.Clear();
            Console.WriteLine("Write the task you would like to your to do list. type 'exit' when done ");

            string task = null;
            while (task != "exit")
            {
                task = Console.ReadLine();
                tasks.Add(task);
            }
            if (task.Contains("exit"))
            {
                tasks.Remove("exit");
            }
        }
        public static void ViewTasks()
        {
            int i = 0;

            Console.Clear();
            
            if (tasks.Count < 0)
            {
                Console.WriteLine("No available tasks!");
            }
            else
            {
                Console.WriteLine("Here's an overview of your current tasks!\n");
                foreach (string task in tasks)
                {
                    i++;
                    Console.WriteLine($"{i}. {task}");
                }
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            
        }
        public static void RemoveTasks()
        {
            Console.Clear();
            
            Console.WriteLine("Enter the number of the task you want to remove.");
            int i = 0;
            foreach (string task in tasks)
            {
                i++;
                Console.WriteLine($"{i}. {task}");
            }
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= tasks.Count)
            {
                tasks.RemoveAt(index - 1);
                Console.WriteLine("Task removed successfully!");
            }
            else
            {
                Console.WriteLine("Invalid Input!");
            }
            Console.ReadLine();
            
        }
    }
}
