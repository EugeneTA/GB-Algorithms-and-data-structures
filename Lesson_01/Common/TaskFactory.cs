using Lesson_01.Task_01;
using Lesson_01.Task_02;
using Lesson_01.Task_03;


namespace Lesson_01.Common
{
    public class TaskFactory
    {
        public ITask GetTask(int taskType)
        {
            return taskType switch
            {
                1 => new Task01(),
                2 => new Task02(),
                3 => new Task03(),
                _ => null
            };
        }
    }
}
