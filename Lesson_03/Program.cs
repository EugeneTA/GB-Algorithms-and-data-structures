using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace Lesson_03
{
    class Program
    { 
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
            //BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            Console.ReadKey();
        }
    }

    public class PointBenchmarkClass
    {
        private const int N = 100;

        private readonly PointClass<float>[] pointClassArray;
        private readonly PointStruct<float>[] pointStructF;
        private readonly PointStruct<double>[] pointStructD;
        private readonly Random random = new Random(1000);

        public PointBenchmarkClass()
        {
            double x, y;

            pointClassArray = new PointClass<float>[N];
            pointStructF = new PointStruct<float>[N];
            pointStructD = new PointStruct<double>[N];

            for (int i = 0; i < N; i++)
            {
                x = random.NextDouble() * (100 * random.NextDouble());
                y = random.NextDouble() * (100 * random.NextDouble());

                pointClassArray[i] = new PointClass<float>
                {
                    X = (float)x,
                    Y = (float)y
                };

                pointStructF[i] = new PointStruct<float>
                {
                    X = (float)x,
                    Y = (float)y
                };

                pointStructD[i] = new PointStruct<double>
                {
                    X = x,
                    Y = y
                };
            }
        }

        public float PointDistanceClass(PointClass<float> pointOne, PointClass<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceClassUsingMathF(PointClass<float> pointOne, PointClass<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStruct(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (float)Math.Sqrt((x * x) + (y * y));
        }

        public float PointDistanceStructUsingMathF(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public double PointDistanceStruct(PointStruct<double> pointOne, PointStruct<double> pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt(((x * x) + (y * y)));
        }

        public float PointDistanceShort(PointStruct<float> pointOne, PointStruct<float> pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestPointDistanceClass()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceClass(pointClassArray[i], pointClassArray[i + 1]);
            }
        }

        [Benchmark]
        public void TestPointDistanceClassUsingMathF()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceClassUsingMathF(pointClassArray[i], pointClassArray[i + 1]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructFloat()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceStruct(pointStructF[i], pointStructF[i + 1]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructFloatUsingMathF()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceStructUsingMathF(pointStructF[i], pointStructF[i + 1]);
            }
        }

        [Benchmark]
        public void TestPointDistanceStructDouble()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceStruct(pointStructD[i], pointStructD[i + 1]);
            }
        }

        [Benchmark]
        public void TestPointDistanceShort()
        {
            for (int i = 0; i < N - 1; i++)
            {
                _ = PointDistanceShort(pointStructF[i], pointStructF[i + 1]);
            }
        }

    }
}
