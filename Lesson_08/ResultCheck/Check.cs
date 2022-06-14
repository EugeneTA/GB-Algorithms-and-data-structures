using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResultCheck
{
    public static class Check
    {
        /// <summary>
        /// Check, that list is sorted
        /// </summary>
        /// <param name="sortedList">list to check</param>
        /// <returns></returns>
        public static bool ListCheck(List<int> sortedList)
        {
            bool result;

            if (sortedList != null && sortedList.Count > 0)
            {
                result = true;

                int prevItem = sortedList[0];

                foreach (var item in sortedList)
                {
                    if (prevItem > item)
                    {
                        result = false;
                        break;
                    }
                    prevItem = item;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// Check, that data in file is sorted
        /// </summary>
        /// <param name="fileName">file name to check</param>
        /// <returns>true, if file is sorted; number of check record's before end of file or when found, that file not sorted</returns>
        public static (bool, long) FileCheck(string fileName, long totalRecords)
        {
            bool result = true;
            long recordsChecked = 0;
            int prevValue = int.MinValue;
            int currentValue;

            if (totalRecords > 0)
            {
                using (FileStream file = File.OpenRead(fileName))
                {
                    using (var reader = new BinaryReader(file, Encoding.UTF8, false))
                    {
                        while (totalRecords > 0)
                        {
                            currentValue = reader.ReadInt32();

                            totalRecords--;
                            recordsChecked++;

                            if (prevValue > currentValue)
                            {
                                result = false;
                                break;
                            }

                            prevValue = currentValue;
                        }
                    }
                }
            }

            return (result, recordsChecked);
        }

    }
}
