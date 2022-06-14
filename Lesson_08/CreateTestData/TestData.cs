using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CreateTestData
{
    public static class TestData
    {
        /// <summary>
        /// Generate tets list of int's
        /// </summary>
        /// <param name="numOfItems">number of list items</param>
        /// <returns></returns>
        public static List<int> CreateTestList(int numOfItems)
        {
            Random random = new Random();
            List<int> result = new List<int>(numOfItems);

            for (int i = 0; i < numOfItems; i++)
            {
                result.Add(random.Next(int.MinValue, int.MaxValue));
            }

            if (numOfItems > 7)
            {
                result[0] = int.MinValue;
                result[1] = int.MaxValue;
                result[2] = -1;
                result[3] = 0;
                result[4] = 1;
                result[5] = int.MinValue + 1;
                result[6] = int.MaxValue - 1;
            }

            return result;

        }

        /// <summary>
        /// Create test file with 'int' record's
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="numOfItems">number of record's</param>
        public static void CreateTestFile(string fileName, long numOfItems)
        {
            Random random = new Random();

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (FileStream file = File.Open(fileName, FileMode.CreateNew))
            {
                using (var writer = new BinaryWriter(file, Encoding.UTF8, false))
                {
                    int i = 0;

                    if (numOfItems > 7)
                    {
                        writer.Write(int.MinValue);
                        writer.Write(int.MaxValue);
                        writer.Write(-1);
                        writer.Write(0);
                        writer.Write(1);
                        writer.Write(int.MinValue + 1);
                        writer.Write(int.MaxValue - 1);
                        i = 7;
                    }

                    for (; i < numOfItems; i++)
                    {
                        writer.Write(random.Next(int.MinValue, int.MaxValue));
                    }
                }
            }
        }

    }
}
