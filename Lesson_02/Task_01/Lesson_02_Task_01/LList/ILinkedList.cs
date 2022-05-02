using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02_Task_01.LList
{
    //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
    public interface ILinkedList
    {
        int GetCount(); // возвращает количество элементов в списке
        void AddNode(int value); // добавляет новый элемент списка
        void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
        void RemoveNode(int index); // удаляет элемент по порядковому номеру
        void RemoveNode(Node node); // удаляет указанный элемент
        Node FindNode(int searchValue); // ищет элемент по его значению
        Node FindNodeByIndex(int index); // ищет элемент по порядковому номеру
    }
}
