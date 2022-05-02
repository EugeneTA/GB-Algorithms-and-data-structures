using Lesson_02_Task_01.LList;
using System;

namespace Lesson_02_Task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Node testNode;
            LinkedList linkedList = new LinkedList();
            linkedList.IfDebug = true;

            // ********************

            PrintLinkedList();

            // Добавляем первый элемент в список.
            linkedList.AddNode(1);
            PrintLinkedList();
            // Добавляем еще элемент в список. Становится последним
            linkedList.AddNode(2);
            PrintLinkedList();
            // Удаляем первый элемент в спсике. Последний становится первым
            linkedList.RemoveNode(0);
            PrintLinkedList();
            // Добавляем новый элемент. Он становится последним
            linkedList.AddNode(1);
            PrintLinkedList();
            // Удаляем 2-й элемент элемент
            linkedList.RemoveNode(1);
            PrintLinkedList();
            // Пытаемся удалить 2-й элемент. Не удалит, т.к. такого нет. Только 1 элемент в списке.
            linkedList.RemoveNode(1);
            PrintLinkedList();
            // Добавляем еще оди элемент в список
            linkedList.AddNode(99);
            PrintLinkedList();
            // Ищем элемент в спсике со значением 99
            testNode = linkedList.FindNode(99);
            // Пытаемся добавить после найденного новый со значением 70
            linkedList.AddNodeAfter(testNode, 70);
            PrintLinkedList();
            // Ищем элемент в спсике со значением 5
            testNode = linkedList.FindNode(5);
            // Пытаемся добавить после найденного новый со значением 50. Не должен добавить, т.к. предыдущий шаг не найдет элемент в списке и вернет NULL.
            linkedList.AddNodeAfter(testNode, 50);
            PrintLinkedList();
            // Ищем элемент в спсике со значением 55
            testNode = linkedList.FindNode(99);
            // Удаляем найденый элемент
            linkedList.RemoveNode(testNode);
            PrintLinkedList();
            // Удаляем 1-й элемент
            linkedList.RemoveNode(0);
            PrintLinkedList();
            // Удаляем 1-й элемент
            linkedList.RemoveNode(0);
            PrintLinkedList();
            // Удаляем 1-й элемент
            linkedList.RemoveNode(0);
            PrintLinkedList();


            Console.ReadKey();

            void WriteLineWithColor<T>(T value, ConsoleColor consoleColor)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = consoleColor;

                Console.WriteLine($"{value}");

                Console.ForegroundColor = defaultColor;
            }

            void PrintLinkedList()
            {
                WriteLineWithColor<LinkedList>(linkedList, ConsoleColor.Yellow);
            }
        }


    }
}
