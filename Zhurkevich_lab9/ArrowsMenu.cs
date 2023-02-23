using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhurkevich_lab9
{
    public enum Key
    {
        Unused,
        UpArrow,
        DownArrow,
        Enter,
        Backspace,
        D,
        Del     
    }

    internal class ArrowsMenu
    {
        private int min;
        private int max;
        private int current;
        public int Current { get { return current - 3; } }

        public ArrowsMenu(int min, int max)
        {
            this.min = min;
            this.max = max;
            current = min;
        }

        public Key ReadKey()
        {
            Key key= new Key();
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    key = Key.UpArrow;
                    break;
                case ConsoleKey.DownArrow:
                    key = Key.DownArrow;
                    break;
                case ConsoleKey.Enter:
                    key = Key.Enter;
                    break;
                case ConsoleKey.Backspace:
                    key = Key.Backspace;
                    break;
                case ConsoleKey.D:
                    key = Key.D;
                    break;
                case ConsoleKey.Delete:
                    key = Key.Del;
                    break;
                default:
                    key = Key.Unused;
                    break;
            }
            return key;
        }

        public void Up()
        {
            EraseArrow();
            if (current == min)
            {
                current = max;
            }
            else
            {
                current--;
            }
            DrawArrow();
        }

        public void Down()
        {
            EraseArrow();
            if (current == max)
            {
                current = min;
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                current++;
            }
            DrawArrow();
        }

        private void DrawArrow()
        {
            Console.SetCursorPosition(0, current);
            Console.Write("->");
        }

        private void EraseArrow()
        {
            Console.SetCursorPosition(0, current);
            Console.Write("  ");
        }
    }
}
