using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lesson_08_ExternalSort
{
    public static class ExternalSort
    {
        /// <summary>
        /// External sort file with int records
        /// </summary>
        /// <param name="inputFileName">file to sort</param>
        /// <param name="resultFileName">result file name</param>
        public static void Sort(string inputFileName, string resultFileName)
        {
            // Culculate number of record's in the input file
            long recordsNumber = GetRecordsNumber(inputFileName);

            // Calculate number of bucket's
            int numOfBuckets = CalculateBuckets(recordsNumber);

            if (recordsNumber > 0 &&
                String.IsNullOrWhiteSpace(inputFileName) == false &&
                String.IsNullOrWhiteSpace(resultFileName) == false)
            {
                // Split input file records by buckets
                SplitByBuckets(inputFileName, numOfBuckets, recordsNumber);

                // Sort buckets and merge into result file
                SortBuckets(inputFileName, resultFileName, numOfBuckets);

                // Delete temp files
                for (int i = 0; i <= numOfBuckets; i++)
                {
                    if (File.Exists($"{i}_{inputFileName}"))
                    {
                        File.Delete($"{i}_{inputFileName}");
                    }
                }
            }
        }

        /// <summary>
        /// Get total number of 'int' record's in file
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <returns>number of record's in file</returns>
        public static long GetRecordsNumber(string fileName)
        {
            long result = 0;

            if (String.IsNullOrWhiteSpace(fileName) == false)
            {
                using (FileStream file = File.Open(fileName, FileMode.Open))
                {
                    result = file.Length / 4;
                }
            }

            return result;
        }

        /// <summary>
        /// Calculate number of bucket's from record's number
        /// </summary>
        /// <param name="records">total number 'int' record's in file</param>
        /// <returns>number of buckets</returns>
        private static int CalculateBuckets(long records)
        {
            // Define bucket's number
            if (records <= 100)
            {
                return 1;
            }
            else if (records <= 1000)
            {
                return 10;
            }
            else if (records <= 1_000_000)
            {
                return 100;
            }
            else
            {
                return 1000;
            }
        }


        /// <summary>
        /// Split all record's in file by bucket's
        /// </summary>
        /// <param name="fileName">file name with int record's</param>
        /// <param name="numOfBuckets">number of bucket's</param>
        /// <param name="totalRecords">total number of record's in file</param>
        private static void SplitByBuckets(string fileName, int numOfBuckets, long totalRecords)
        {
            using (FileStream file = File.Open(fileName, FileMode.Open))
            {
                using (var fileReader = new BinaryReader(file, Encoding.UTF8, false))
                {
                    FileStream[] fileStreams = new FileStream[numOfBuckets + 1];
                    BinaryWriter[] binaryWriters = new BinaryWriter[numOfBuckets + 1];

                    Console.WriteLine($" {DateTime.Now} - Split records by bucket's");

                    // Bucket index
                    int bucketIndex;

                    // Record value
                    int value;

                    // Go throut all records in file
                    for (int i = 0; i < totalRecords; i++)
                    {
                        // read integer value
                        value = fileReader.ReadInt32();

                        // calculate backet index
                        bucketIndex = (numOfBuckets / 2) + (int)((double)((double)value / int.MaxValue) * (numOfBuckets / 2));

                        // create writer for this bucket
                        if (binaryWriters[bucketIndex] == null)
                        {
                            if (fileStreams[bucketIndex] == null)
                            {
                                fileStreams[bucketIndex] = File.Open($"{bucketIndex}_{fileName}", FileMode.Append);
                            }

                            binaryWriters[bucketIndex] = new BinaryWriter(fileStreams[bucketIndex], Encoding.UTF8, true);
                        }

                        // write data to the bucket
                        binaryWriters[bucketIndex].Write(value);
                    }

                    // close stream's and writer's
                    for (int i = 0; i <= numOfBuckets; i++)
                    {
                        if (binaryWriters[i] != null)
                        {
                            binaryWriters[i].Close();
                            binaryWriters[i].Dispose();
                            binaryWriters[i] = null;
                        }

                        if (fileStreams[i] != null)
                        {
                            fileStreams[i].FlushAsync();
                            fileStreams[i].Close();
                            fileStreams[i].Dispose();
                            fileStreams[i] = null;
                        }
                    }

                    Console.WriteLine($" {DateTime.Now} - Split to buckets finished");

                }
            }
        }


        /// <summary>
        /// Sort buckets and merge them to the result file
        /// </summary>
        /// <param name="fileName">file name of file to sort</param>
        /// <param name="resultFileName">result file name (sorted filed)</param>
        /// <param name="numOfBuckets">number of buckets</param>
        private static void SortBuckets(string fileName, string resultFileName, int numOfBuckets)
        {
            FileStream[] fileStreams = new FileStream[numOfBuckets + 1];
            BinaryReader[] binaryReaders = new BinaryReader[numOfBuckets + 1];

            // Delete output file if exist
            if (File.Exists(resultFileName) == true)
            {
                File.Delete(resultFileName);
            }

            // Create output file and writer
            using (FileStream result = File.Open(resultFileName, FileMode.Create))
            {
                using (BinaryWriter resultWriter = new BinaryWriter(result, Encoding.UTF8, true))
                {
                    // Go through all bucket's
                    for (int i = 0; i <= numOfBuckets; i++)
                    {
                        // Check, that bucket file exist
                        if (File.Exists($"{i}_{fileName}"))
                        {
                            Console.WriteLine($" {DateTime.Now} - Sorting bucket {i}");

                            // if bucket file exist, open file stream and create reader
                            fileStreams[i] = File.Open($"{i}_{fileName}", FileMode.Open);
                            binaryReaders[i] = new BinaryReader(fileStreams[i], Encoding.UTF8, true);

                            List<int> bucket = new List<int>();

                            // add bucket data to the list
                            while (fileStreams[i].Position < fileStreams[i].Length)
                            {
                                bucket.Add(binaryReaders[i].ReadInt32());
                            }

                            // sort list
                            bucket.Sort();

                            // write sorted data to the result stream
                            foreach (var item in bucket)
                            {
                                resultWriter.Write(item);
                            }
                        }

                    }
                }
            }

            // Clear file stream's and reader's
            for (int i = 0; i <= numOfBuckets; i++)
            {
                if (binaryReaders[i] != null)
                {
                    binaryReaders[i].Close();
                    binaryReaders[i].Dispose();
                    binaryReaders[i] = null;
                }

                if (fileStreams[i] != null)
                {
                    fileStreams[i].FlushAsync();
                    fileStreams[i].Close();
                    fileStreams[i].Dispose();
                    fileStreams[i] = null;
                }
            }
        }
    }
}
