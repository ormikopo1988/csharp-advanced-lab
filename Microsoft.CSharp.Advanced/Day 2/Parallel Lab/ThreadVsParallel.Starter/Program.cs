using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadVsParallel.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exercise 1
            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"{i + 1} iteration: {ParallelProcess()}");
            //    Console.WriteLine($"{i + 1} iteration: {ParallelThread()}");
            //}

            // Exercise 2
            //var path = Directory.GetCurrentDirectory();

            //var files = Directory.GetFiles(path + @"\pictures", "*.jpg");

            //var alteredPathParallel = path + @"\alteredPathParallel";
            //var alteredPathThread = path + @"\alteredPathThread";
            //var alteredPathNormal = path + @"\alteredPathNormal";

            //Directory.CreateDirectory(alteredPathParallel);
            //Directory.CreateDirectory(alteredPathThread);
            //Directory.CreateDirectory(alteredPathNormal);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine($"{i + 1} iteration: ParallelExecution");
            //    ParallelExecution(files, alteredPathParallel);
            //    Console.WriteLine($"{i + 1} iteration: ThreadExecution");
            //    ThreadExecution(files, alteredPathThread);
            //    Console.WriteLine($"{i + 1} iteration: NormalExecution");
            //    NormalExecution(files, alteredPathNormal);
            //}

            Console.ReadLine();
        }

        #region Exercise 1

        private static string ParallelProcess()
        {
            var sw = new Stopwatch();

            sw.Start();

            // Write a for loop using the Parallel.For TPL construct from 0 to Environment.ProcessorsCount and pass it a simple Action giving it an input with name index 
            // and also the CurrentThread ManagedThreadId. The format used in the console woule be: "Printing {0} thread = {1}", where {0} is the 
            // iterator index passed as an input in the Action<int> of the body of Parallel.For loop construct.

            // Your code here...

            sw.Stop();

            return string.Format("ParallelProcess: Time in milliseconds {0}", sw.Elapsed.TotalMilliseconds);
        }

        private static string ParallelThread()
        {
            var sw = new Stopwatch();

            sw.Start();

            // Write a for loop using the Enumerable.Range loop construct from 0 to Environment.ProcessorsCount
            // Apply the .Select method of LINQ to the output of Enumerable.Range and pass it an input of type Func<int, Thread>.
            // Name the input integer as index and create a new Thread that will just print the index along with the CurrentThread ManagedThreadId in the format
            // "Printing {0} thread = {1}", where {0} is the iterator index passed as an input in the Func<int, Thread> of the LINQ Select construct.
            // Next apply .ToList() to the output of the Select LINQ method and name the output variable as threads.
            // var threads = Enumerable.Range(...).Select(...).ToList();

            // Your code here...

            // Write a foreach loop hear that will iterate over threads and will call .Start() to start each one of them

            // Your code here...

            // Write a foreach loop hear that will iterate over threads and will call .Join() to wait for each one of them to finish execution

            // Your code here...

            sw.Stop();

            return string.Format("ParallelThread: Time in milliseconds {0}", sw.Elapsed.TotalMilliseconds);
        }

        #endregion

        #region Exercise 2

        private static void ParallelExecution(string[] files, string alteredPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Write a parallel loop using Parallel.Foreach construct. 
            // Pass in the input files argument (string[]) as the first argument
            // Create a ParallelOptions object and set the MaxDegreeOfParallelism to Environment.ProcessorCount and pass it as the second argument.
            // Create an Action<string> body and pass it as the third argument. The Action<string> will take each as input a string called "currentFile" 
            // and inside its body will call: RotateImageFile(currentFile, alteredPath);

            // Your code here...

            stopwatch.Stop();

            Console.WriteLine("Time passed in parallel execution: " + stopwatch.ElapsedMilliseconds);

            Console.WriteLine();
        }

        private static void ThreadExecution(string[] files, string alteredPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Create a new list of Thread objects

            // Your code here...

            // Iterate through files array passed in as an input to the current method with a foreach loop
            // In the body of the foreach loop create a new thread and inside the thread pass in a call to:
            // RotateImageFile(currentFile, alteredPath);
            // Finally before ending each iteration of the foreach loop add the created thread inside the list of threads.

            // Your code here...

            // Write a foreach loop hear that will iterate over threads and will call .Start() to start each one of them

            // Your code here...

            // Write a foreach loop hear that will iterate over threads and will call .Join() to wait for each one of them to finish execution

            // Your code here...

            stopwatch.Stop();

            Console.WriteLine("Time passed in thread execution: " + stopwatch.ElapsedMilliseconds);

            Console.WriteLine();
        }

        private static void NormalExecution(string[] files, string alteredPath)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Write a foreach loop hear that will iterate over files and will call:
            // RotateImageFile(currentFile, alteredPath);

            stopwatch.Stop();

            Console.WriteLine("Time passed in normal execution: " + stopwatch.ElapsedMilliseconds);

            Console.WriteLine();
        }

        private static void RotateImageFile(string currentFile, string alteredPath)
        {
            var file = Path.GetFileName(currentFile);

            using (var fileBitmap = new Bitmap(currentFile))
            {
                fileBitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                fileBitmap.Save(Path.Combine(alteredPath, file));

                Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} finished rotating {file}.");
            }
        }

        #endregion
    }
}
