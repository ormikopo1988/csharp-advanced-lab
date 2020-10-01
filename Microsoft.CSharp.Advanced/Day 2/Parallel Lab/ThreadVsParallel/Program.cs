using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadVsParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"{i + 1} iteration: {ParallelProcess()}");
            //    Console.WriteLine($"{i + 1} iteration: {ThreadProcess()}");
            //}

            // Exercise 2
            var path = Directory.GetCurrentDirectory();

            var files = Directory.GetFiles(path + @"\pictures", "*.jpg");

            var alteredPathParallel = path + @"\alteredPathParallel";
            var alteredPathThread = path + @"\alteredPathThread";
            var alteredPathNormal = path + @"\alteredPathNormal";

            Directory.CreateDirectory(alteredPathParallel);
            Directory.CreateDirectory(alteredPathThread);
            Directory.CreateDirectory(alteredPathNormal);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1} iteration: ParallelExecution");
                ParallelExecution(files, alteredPathParallel);
                Console.WriteLine($"{i + 1} iteration: ThreadExecution");
                ThreadExecution(files, alteredPathThread);
                //Console.WriteLine($"{i + 1} iteration: NormalExecution");
                //NormalExecution(files, alteredPathNormal);
            }

            Console.ReadLine();
        }

        #region Exercise 1

        private static string ParallelProcess()
        {
            var sw = new Stopwatch();

            sw.Start();

            Parallel.For(0, Environment.ProcessorCount, x =>
            {
                Console.WriteLine(string.Format("Printing {0} thread = {1}", x, Thread.CurrentThread.ManagedThreadId));
            });

            sw.Stop();

            return string.Format("ParallelProcess: Time in milliseconds {0}", sw.Elapsed.TotalMilliseconds);
        }

        private static string ThreadProcess()
        {
            var sw = new Stopwatch();

            sw.Start();

            var threads = Enumerable.Range(0, Environment.ProcessorCount).Select(x => new Thread(() =>
            {
                Console.WriteLine(string.Format("Printing {0} thread = {1}", x, Thread.CurrentThread.ManagedThreadId));
            })).ToList();

            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();

            sw.Stop();

            return string.Format("ThreadProcess: Time in milliseconds {0}", sw.Elapsed.TotalMilliseconds);
        }

        #endregion

        #region Exercise 2

        private static void ParallelExecution(string[] files, string alteredPath)
        {
            var sw = Stopwatch.StartNew();

            var parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(files, parallelOptions, currentFile =>
            {
                var file = Path.GetFileName(currentFile);

                using (var fileBitmap = new Bitmap(currentFile))
                {
                    fileBitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                    fileBitmap.Save(Path.Combine(alteredPath, file));

                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished rotating {file}.");
                }
            });

            sw.Stop();

            Console.WriteLine("Time passed in parallel execution: " + sw.Elapsed.TotalMilliseconds);

            Console.WriteLine();
        }

        private static void ThreadExecution(string[] files, string alteredPath)
        {
            var sw = Stopwatch.StartNew();

            var threads = new List<Thread>();

            foreach (var currentFile in files)
            {
                var thread = new Thread(() =>
                {
                    var file = Path.GetFileName(currentFile);

                    using (var fileBitmap = new Bitmap(currentFile))
                    {
                        fileBitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                        fileBitmap.Save(Path.Combine(alteredPath, file));

                        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished rotating {file}.");
                    }
                });

                threads.Add(thread);
            };

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            sw.Stop();

            Console.WriteLine("Time passed in thread execution: " + sw.Elapsed.TotalMilliseconds);

            Console.WriteLine();
        }

        private static void NormalExecution(string[] files, string alteredPath)
        {
            var sw = Stopwatch.StartNew();

            foreach (var currentFile in files)
            {
                var file = Path.GetFileName(currentFile);

                using (var fileBitmap = new Bitmap(currentFile))
                {
                    fileBitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                    fileBitmap.Save(Path.Combine(alteredPath, file));

                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished rotating {file}.");
                }
            };

            sw.Stop();

            Console.WriteLine("Time passed in normal execution: " + sw.Elapsed.TotalMilliseconds);

            Console.WriteLine();
        }

        #endregion
    }
}