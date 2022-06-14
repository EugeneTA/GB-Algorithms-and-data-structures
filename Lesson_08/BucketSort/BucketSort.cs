using System;
using System.Collections.Generic;


namespace Lesson_08_BucketSort
{
    public static class BucketSort
    {
        /// <summary>
        /// Bucket sort
        /// </summary>
        /// <param name="listToSort">list to sort</param>
        public static void Sort(List<int> listToSort)
        {
            if (listToSort != null && listToSort.Count > 1)
            {
                int numOfBuckets;

                // Define number of bucket's
                if (listToSort.Count < 10)
                {
                    numOfBuckets = 1;
                }
                else if (listToSort.Count < 1000)
                {
                    numOfBuckets = 10;
                }
                else if (listToSort.Count < 100_000)
                {
                    numOfBuckets = 100;
                }
                else
                {
                    numOfBuckets = 1000;
                }


                int index;

                // Assign element's to a bucket's
                List<int>[] buckets = new List<int>[numOfBuckets + 1];
                foreach (var item in listToSort)
                {
                    index = (numOfBuckets / 2) + (int)((double)((double)item / int.MaxValue) * (numOfBuckets / 2));

                    if (buckets[index] == null)
                    {
                        buckets[index] = new List<int>();
                    }

                    buckets[index].Add(item);
                }

                // Sort element's in bcuket's and merge them
                index = 0;
                foreach (var bucket in buckets)
                {
                    if (bucket != null)
                    {
                        bucket.Sort();

                        foreach (var item in bucket)
                        {
                            listToSort[index] = item;
                            index++;
                        }
                    }
                }
            }
        }
    }
}
