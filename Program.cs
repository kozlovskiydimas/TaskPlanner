using Kozlovskiy.TaskPlanner.Domain.Logic;
using Kozlovskiy.TaskPlanner.Domain.Models;
using Kozlovskiy.TaskPlanner.Domain.Logic;
using Kozlovskiy.TaskPlanner.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





namespace Kozlovskiy.TaskPlanner

{

    internal static class Program

    {

        static void Main(string[] args)

        {

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Workitem[] items =

                    {

            new Workitem("Підготувати презентацію", new DateTime(2025, 12, 20), Priority.High),

            new Workitem("Зробити лабу", new DateTime(2025, 12, 15), Priority.Medium),

            new Workitem("Зробити звіт до практичної", new DateTime(2025, 12, 12), Priority.High),

            new Workitem("Помити посуд", new DateTime(2025, 12, 18), Priority.Low),

            new Workitem("Зробити курсову", new DateTime(2025, 12, 10), Priority.High),

            new Workitem("Полити город", new DateTime(2025, 12, 17), Priority.Low),

            new Workitem("Купити хліб", new DateTime(2025, 12, 13), Priority.High),

            new Workitem("Пропилососити", new DateTime(2025, 12, 14), Priority.Low)

        };

            SimpleTaskPlanner planner = new SimpleTaskPlanner();



            bool running = true;

            while (running)

            {

                var sortedItems = planner.CreatePlan(items.ToArray());



                Console.WriteLine("\n--- Поточний список завдань ---");

                foreach (var item in sortedItems)

                {

                    Console.WriteLine($"{item.priority,-6} {item.DueDate.ToShortDateString(),-12} {item.Title}");

                }



                Console.Write("\nБажаєте додати новий елемент масиву? (y/n): ");

                string answer = Console.ReadLine()?.Trim().ToLower();



                if (answer == "n")

                {

                    running = false;

                    Console.WriteLine("Програма завершена.");

                }

                else if (answer == "y")

                {

                    Console.Write("Введіть назву завдання: ");

                    string title = Console.ReadLine();



                    int year;

                    while (true)

                    {

                        Console.Write("Введіть рік: ");

                        if (int.TryParse(Console.ReadLine(), out year) && year > 0) break;

                        Console.WriteLine("Некоректний рік. Спробуйте ще раз.");

                    }



                    int month;

                    while (true)

                    {

                        Console.Write("Введіть місяць (1-12): ");

                        if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12) break;

                        Console.WriteLine("Некоректний місяць. Спробуйте ще раз.");

                    }



                    int day;

                    while (true)

                    {

                        Console.Write("Введіть число: ");

                        if (int.TryParse(Console.ReadLine(), out day))

                        {

                            try

                            {

                                var testDate = new DateTime(year, month, day);

                                break;

                            }

                            catch

                            {

                                Console.WriteLine("Такої дати не існує. Спробуйте ще раз.");

                            }

                        }

                        else

                        {

                            Console.WriteLine("Некоректне число. Спробуйте ще раз.");

                        }

                    }



                    Priority priority;

                    while (true)

                    {

                        Console.WriteLine("Оберіть пріоритет:");

                        foreach (var pr in Enum.GetValues(typeof(Priority)))

                        {

                            Console.WriteLine($"- {pr}");

                        }

                        Console.Write("Введіть пріоритет: ");

                        string priorityInput = Console.ReadLine();



                        if (Enum.TryParse(priorityInput, true, out priority)) break;

                        Console.WriteLine("Некоректний пріоритет. Спробуйте ще раз.");

                    }



                    items = items.Append(new Workitem(title, new DateTime(year, month, day), priority)).ToArray();



                    Console.WriteLine("\nНовий елемент додано.\n");

                }

                else

                {

                    Console.WriteLine("Невірна відповідь. Введіть 'y' або 'n'.");

                }

            }

        }

    }

}