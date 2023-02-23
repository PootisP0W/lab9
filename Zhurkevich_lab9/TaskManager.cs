using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Zhurkevich_lab9
{
    internal static class TaskManager
    {
        public static Process[] Processes { get; set; } = null;

        private static void PrintTaskManager()
        {
            Console.Clear();
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Диспетчер задач");
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        public static void PrintTasks()
        {
            Console.Clear();
            Processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToArray();
            PrintTaskManager();
            Console.SetCursorPosition(20, 2);
            Console.Write("Название");
            Console.SetCursorPosition(40, 2);
            Console.Write("Закр. память");
            Console.SetCursorPosition(60, 2);
            Console.Write("Физ. память");
            Console.SetCursorPosition(80, 2);
            Console.Write("Приоритет");
            Console.SetCursorPosition(0, 3);
            foreach (Process process in Processes)
            {
                Console.Write($"  {process.ProcessName}");
                Console.SetCursorPosition(42, Console.CursorTop);
                Console.Write($"{Math.Round(process.PrivateMemorySize64 / 8.0 / 1024 / 1024, 2)} МБ");
                Console.SetCursorPosition(62, Console.CursorTop);
                Console.Write($"{Math.Round(process.WorkingSet64 / 8.0 / 1024 / 1024, 2)} МБ");
                Console.SetCursorPosition(84, Console.CursorTop);
                Console.Write(process.BasePriority);
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(0, 3);
            Console.Write("->");
        }

        public static void PrintTaskInfo(Process process)
        {
            try
            {
                Console.Clear();
                PrintTaskManager();
                Console.SetCursorPosition(24, Console.CursorTop);
                Console.WriteLine(process.ProcessName);
                Console.Write("  ИД процесса:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(process.Id);
                Console.Write("  Физическая память:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine($"{process.WorkingSet64} байт");
                Console.Write("  Закрытая память:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine($"{process.PrivateMemorySize64} байт");
                Console.Write("  Приоритет:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine($"{process.BasePriority}");
                Console.Write("  Класс приоритета:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(process.PriorityClass);
                Console.Write("  Время использования процесса:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(process.UserProcessorTime);
                Console.Write("  Все время использования:");
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(process.TotalProcessorTime);
                Console.WriteLine("-----------------------------------------------------------");
                if (process.Responding)
                {
                    Console.WriteLine("  Статус - Запущен");
                }
                else
                {
                    Console.WriteLine("  Статус - Не запущен");
                }
            }
            catch
            {
                Console.Clear();
                PrintTaskManager();
                Console.WriteLine("  Процесс недоступен для отображения");
                Console.WriteLine("  Причина: Отказано в доступе");
            }
            finally
            {
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine($"  D - Завершить процесс");
                Console.WriteLine($"  Del - Завершить все процессы с этим именем");
            }
        }

        public static bool EndProcess(Process process)
        {
            try
            {
                process.Kill();
                return true;
            }
            catch
            {
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("Ошибка, отказано в доступе");
                return false;
            }
        }

        public static bool EndProcesses(Process process)
        {
            try
            {
                foreach (Process endProcess in Process.GetProcessesByName(process.ProcessName))
                {
                    endProcess.Kill();
                }
                return true;
            }
            catch
            {
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("Ошибка, отказано в доступе");
                return false;
            }
        }
    }
}
