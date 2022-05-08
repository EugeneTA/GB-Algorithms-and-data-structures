using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_02_Task_01.LList
{
    public class LinkedList : Debug, ILinkedList
    {
        private Node _firstNode = null; // Ссылка на первый элемент списка
        private Node _lastNode = null; // ССылка на последнийэлемент списка

        /// <summary>
        /// добавляет новый элемент списка c заданным значением
        /// </summary>
        /// <param name="value">значение</param>
        public void AddNode(int value)
        {
            
            if (_firstNode == null)
            {
                // Если пустой список
                _firstNode = new Node(value);
                DebugWriteLine("AddNode", $"Создаем firstNode: {_firstNode}");
            }
            else if (_lastNode == null)
            {
                // Если в списке только один элемент
                _lastNode = new Node()
                {
                    Value = value,
                    NextNode = null,
                    PrevNode = _firstNode
                };
                _firstNode.NextNode = _lastNode;
                DebugWriteLine("AddNode", $"создаем lastNode: {_lastNode}");
            }
            else
            {
                // Во всех остальных случаях добавляем в конец списка
                Node newNode = new Node()
                {
                    Value = value,
                    NextNode = null,
                    PrevNode = _lastNode
                };

                _lastNode.NextNode = newNode;
                _lastNode = newNode;

                DebugWriteLine("AddNode", $"добавляем в конец списка: {_lastNode}");
            }

        }

        /// <summary>
        /// добавляет новый элемент списка после определённого элемента
        /// </summary>
        /// <param name="node">элемент, после кототого надо добавить новый со значением указанным в value</param>
        /// <param name="value">значение</param>
        public void AddNodeAfter(Node node, int value)
        {
            if (node != null)
            {                
                if (node.Equals(_lastNode) || (node.Equals(_firstNode) && _lastNode == null))
                {
                    // Если указанный элемент последний или только один элемент в списке, то добавляем в конец списка
                    DebugWriteLine("AddNodeAfter", $"Добавляем {value} в конец списка");
                    AddNode(value);
                }
                else
                {
                    // Во всех остальных случаях добавляем новый элемент после указанного
                    DebugWriteLine("AddNodeAfter", $"Добавляем {value} после {node.Value}");
                    Node newNode = new Node()
                    {
                        Value = value,
                        NextNode = node.NextNode,
                        PrevNode = node
                    };

                    if (node.NextNode != null)
                    {
                        node.NextNode.PrevNode = newNode;
                    }

                    node.NextNode = newNode;
                }
            }
        }

        /// <summary>
        /// ищет элемент по его значению
        /// </summary>
        /// <param name="searchValue">значение, которое надо найти</param>
        /// <returns></returns>
        public Node FindNode(int searchValue)
        {
            // проверяем, что список не пустой
            if (_firstNode != null)
            {
                DebugWriteLine("FindNode", $"Ищем элемент со значением {searchValue}:");

                // Проверяем последний элемент списка на совпадение значения
                if (_lastNode != null) 
                {
                    // Если совпадает, то возвращаем его.
                    if (_lastNode.Value == searchValue)
                    {
                        DebugWriteLine("FindNode", "Искомое значение нашли в последнем элементе.");
                        //return (Node)_lastNode.Clone();
                        return _lastNode;
                    }
                }

                // Если это не последний элемент, то провереям последовательно все, начиная с первого
                int count = 0;
                Node next = _firstNode;

                do
                {
                    count++;
                    if (next.Value == searchValue)
                    {
                        DebugWriteLine("FindNode", $"Искомое значение нашли в {count} элементе.");
                        //return (Node)next.Clone();
                        return next;
                    }
                    next = next.NextNode;

                } while (next != null);
            }

            DebugWriteLine("FindNode", $"Не нашли значение {searchValue} в списке или список пуст");
            return null;
        }

        /// <summary>
        /// ищет элемент по порядковому номеру
        /// </summary>
        /// <param name="index">порядковый номер элемента (первый элемент в спсике имеет индекс 0)</param>
        /// <returns></returns>
        public Node FindNodeByIndex(int index)
        {
            // Проверяем, сто список не пустой и индекс не отрицательный
            if (_firstNode != null && index >= 0)
            {
                DebugWriteLine("FinNodeByIndex", $"Ищем элемент с индексом {index}");

                // Возвращаем первый элемент, если ииндекс нулевой
                if (0 == index)
                {
                    DebugWriteLine("FinNodeByIndex", $"Нашли. Его значение: {_firstNode}");
                    return _firstNode;
                }
                else
                {
                    // Последовательно ищем элемент с нужным индексом
                    Node next = _firstNode.NextNode;

                    for (int i = 1; i < index; i++)
                    {
                        // Если элменет нулевой или следующий элемент пустой, то выходим с сообщением, что ничего не нашли
                        if (next == null || next.NextNode == null)
                        {
                            
                            DebugWriteLine("FinNodeByIndex", $"Не нашли элемент с индексом {index}. Запрашиваемый индекс больше кол-ва элементов");
                            return null;
                        }
                        next = next.NextNode;
                    }

                    DebugWriteLine("FinNodeByIndex", $"Нашли элемент с индексом {index}. Его значение: {next}");
                    //return (Node)next.Clone();
                    return next;
                }
            }

            DebugWriteLine("FinNodeByIndex", $"Не нашли элемент с индексом {index}. Список пуст или индекс < 0");
            return null;
        }

        /// <summary>
        /// возвращает количество элементов в списке
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;

            if (_firstNode != null)
            {
                result++;

                DebugWriteLine();
                DebugWrite("GetCount", "Считаем кол-во: ");
                
                Node next = _firstNode.NextNode;
                
                DebugWrite(_firstNode.ToString());
                
                while (next != null)
                {
                    DebugWrite($", {next}");
                    next = next.NextNode;
                    result++;
                }
                
                DebugWriteLine();
                DebugWriteLine("GetCount", $"Итого {result} элементов в списке.");
            }

            return result;
        }

        /// <summary>
        /// // Удаляет элемент по порядковому номеру
        /// </summary>
        /// <param name="index">порядковый номер элемента</param>
        public void RemoveNode(int index)
        {
            // Проверяем, сто список не пустой и индекс не отрицательный
            if (_firstNode != null && index >= 0)
            {
                DebugWriteLine("RemoveNode(index)", $"Удаляем элемент в списке с индексом {index}");

                // Удаляем первый элемент, если ииндекс нулевой
                if (0 == index)
                {
                    RemoveNode(_firstNode);
                }
                else
                {
                    // Последовательно ищем элемент с нужным индексом
                    Node next = _firstNode.NextNode;

                    for (int i = 1; i < index; i++)
                    {
                        // Если элеменет нулевой или следующий элемент пустой, то выходим с сообщением, что ничего не нашли
                        if (next == null || next.NextNode == null)
                        {
                            DebugWriteLine("RemoveNode(index)", $"Не нашли элемент с индексом {index}. Запрашиваемый индекс больше кол-ва элементов");
                            return;
                        }
                        next = next.NextNode;
                    }
                    // Если нашли, то удаляем
                    if (next != null)
                    {
                        DebugWriteLine("RemoveNode(index)", $"Нашли элемент с индексом {index}. Его значение: {next}");
                        RemoveNode(next);
                    }
                }
            }
            else
            {
                DebugWriteLine("RemoveNode(index)", $"Невозможно удалить элемент с индексом {index}. Список пуст или индекс < 1");
            }

        }


        /// <summary>
        /// удаляет указанный элемент
        /// </summary>
        /// <param name="node">элемент</param>
        public void RemoveNode(Node node)
        {
            if (node != null)
            {
                DebugWriteLine("RemoveNode(Node)", $"Удаляем элемент со значением {node}.");

                // Если элемент является первым
                if (node.Equals(_firstNode))
                {
                    DebugWriteLine("RemoveNode(Node)", $"Это первый элемент списка.");
                    
                    _firstNode.Value = 0;

                    if (_firstNode.NextNode == null)
                    {
                        // Один элемент в списке
                        DebugWriteLine("RemoveNode(Node)", $"В списке только 1 элемент. Удаляем его. Список пустой.");
                        _firstNode = null;
                    }
                    else if (_firstNode.NextNode.Equals(_lastNode))
                    {
                        // Если 2 элемента в списке
                        DebugWriteLine("RemoveNode(Node)", $"В списке только 2 элемента. Удаляем 1-й. Последний становится первым.");
                        var next = _firstNode.NextNode;
                        _firstNode = next;
                        _firstNode.PrevNode = null;
                        _lastNode = null;
                    }
                    else
                    {
                        // во всех остальных случаях
                        DebugWriteLine("RemoveNode(Node)", $"Удаляем 1-й элемент.");
                        var next = _firstNode.NextNode;
                        _firstNode = next;
                        _firstNode.PrevNode = null;
                    }

                    DebugWriteLine("RemoveNode(Node)", $"Теперь 1-й элемент со значением {_firstNode}.");
                }
                // Если последний элемент в списке
                else if (node.Equals(_lastNode))
                {
                    DebugWriteLine("RemoveNode(Node)", $"Удаляем последний элемент списка.");
                    
                    _lastNode.Value = 0;
                    _lastNode.PrevNode.NextNode = null;

                    if (_lastNode.PrevNode.Equals(_firstNode))
                    {
                        DebugWriteLine("RemoveNode(Node)", $"Всего было 2 элемента в списке. lastNode теперь null");
                        _lastNode = null;
                    }
                    else
                    {
                        _lastNode = _lastNode.PrevNode;
                    }                   
                }
                // Во всех остальных случаях
                else
                {
                    DebugWriteLine("RemoveNode(Node)", $"Удаляем значение {node} между {node.PrevNode} и {node.NextNode}");
                    node.Value = 0;
                    node.PrevNode.NextNode = node.NextNode;
                    node.NextNode.PrevNode = node.PrevNode;
                }
            }
            else
            {
                DebugWriteLine("RemoveNode(Node)", $"Невозможно удалить элемент. Указанный элемент == null.");
            }

        }

        public override string ToString()
        {
            int count = 0;
            StringBuilder result = new("Empty");

            if (_firstNode != null)
            {
                count++;
                result.Clear();
                Node next = _firstNode.NextNode;
                result.Append(_firstNode);
                while (next != null)
                {
                    result.Append($", {next}");
                    next = next.NextNode;
                    count++;
                }
            }

            return $"Список. Кол-во элементов: {count}. Элемнеты: {result}";
        }

    }
}
