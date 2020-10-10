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

            // Write a for loop (i=0 to i=10)
            // Inside the for loop write two messages in the console:
            // - $"{i + 1} iteration: {CallParallelProcess}", where CallParallelProcess is a placeholder for a call to ParallelProcess()
            // - $"{i + 1} iteration: {CallThreadProcess}", where CallThreadProcess is a placeholder for a call to ThreadProcess()           
            // Your code here...

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

            // Write a for loop (i=0 to i=10)
            // Inside the for loop write three messages in the console:
            // - $"{i + 1} iteration: ParallelExecution"
            // - $"{i + 1} iteration: ThreadExecution"
            // - $"{i + 1} iteration: NormalExecution"
            // Just below each of these messages call the respective method execution that you wrote below and pass:
            // - The files array
            // - The appropriate alteredPath variable based on the model execution of code.

            // Your code here...
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1} iteration: ParallelExecution");
                ParallelExecution(files, alteredPathParallel);
                Console.WriteLine($"{i + 1} iteration: ThreadExecution");
                ThreadExecution(files, alteredPathThread);
                Console.WriteLine($"{i + 1} iteration: NormalExecution");
                NormalExecution(files, alteredPathNormal);
            }

            Console.ReadLine();
        }

        #region Exercise 1

        private static string ParallelProcess()
        {
            // Initialize new Stopwatch
            // Your code here...
            var stopwatch = new Stopwatch();
            // Start Stopwatch
            // Your code here...

            stopwatch.Start();
            // Write a for loop using the Parallel.For TPL construct from 0 to Environment.ProcessorsCount and pass it a simple Action giving it an input with name index 
            // and also the CurrentThread ManagedThreadId. The format used in the console woule be: "Printing {0} thread = {1}", where {0} is the 
            // iterator index passed as an input in the Action<int> of the body of Parallel.For loop construct.

            // Your code here...
            Parallel.For(0, Environment.ProcessorCount, index =>
            {
                Console.WriteLine("Printing {0} thread = {1}", index, Thread.CurrentThread.ManagedThreadId);

            });
            // Stop Stopwatch
            // Your code here...
            stopwatch.Stop();

            // Return "ParallelProcess: Time in milliseconds {0}", where {0} is the time elapsed in milliseconds.
            return String.Format("ParallelProcess: Time in milliseconds {0}", stopwatch.ElapsedMilliseconds);
            //return string.Empty; // Just for the code to compile - Your return statement goes here...
        }

        private static string ThreadProcess()
        {
            // Initialize new Stopwatch

            // Your code here...
            var stopwatch = new Stopwatch();
            // Start Stopwatch

            // Your code here...
            stopwatch.Start();

            // Write a for loop using the Enumerable.Range loop construct from 0 to Environment.ProcessorsCount
            // Apply the .Select method of LINQ to the output of Enumerable.Range and pass it an input of type Func<int, Thread>.
            // Name the input integer as index and create a new Thread that will just print the index along with the CurrentThread ManagedThreadId in the format
            // "Printing {0} thread = {1}", where {0} is the iterator index passed as an input in the Func<int, Thread> of the LINQ Select construct.
            // Next apply .ToList() to the output of the Select LINQ method and name the output variable as threads.
            // var threads = Enumerable.Range(...).Select(...).ToList();

            // Your code here...
            var threads = Enumerable.Range(0, Environment.ProcessorCount).Select(index => (new Thread(() =>
            {
                Console.WriteLine(string.Format("Printing {0} thread = {1}", index, Thread.CurrentThread.ManagedThreadId));

            }))).ToList();


            // Write a foreach loop hear that will iterate over threads and will call .Start() to start each one of them

            // Your code here...
            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            // Write a foreach loop hear that will iterate over threads and will call .Join() to wait for each one of them to finish execution

            // Your code here...
            foreach (Thread thread in threads)
            {
                thread.Join();
            }
            // Stop Stopwatch
            // Your code here...

            stopwatch.Stop();
            // Return "ThreadProcess: Time in milliseconds {0}", where {0} is the time elapsed in milliseconds.
            return (string.Format("ThreadProcess: Time in milliseconds {0}", stopwatch.ElapsedMilliseconds));
            //return string.Empty; // Just for the code to compile - Your return statement goes here...
        }

        #endregion

        #region Exercise 2

        private static void ParallelExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch
            // Your code here...

            var stopwatch = new Stopwatch();

            // Start Stopwatch

            // Your code here...
            stopwatch.Start();

            // Write a parallel loop using Parallel.Foreach construct. 
            // Pass in the input files argument (string[]) as the first argument
            // Create a ParallelOptions object and set the MaxDegreeOfParallelism to Environment.ProcessorCount and pass it as the second argument.
            // Create an Action<string> body and pass it as the third argument. The Action<string> will take each as input a string called "currentFile" 
            // and inside its body will call: RotateImageFile(currentFile, alteredPath);

            // Your code here...
            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            ParallelLoopResult parallelLoopResult = Parallel.ForEach(files, options, currentFile =>
            {
                RotateImageFile(currentFile, alteredPath);

            });

            // Stop Stopwatch
            // Your code here...

            stopwatch.Stop();
            // Write in the console: "Time passed in parallel execution: {0}", where {0} is the time elapsed in milliseconds.

            Console.WriteLine("Time passed in parallel execution: {0}", stopwatch.ElapsedMilliseconds);
        }

        private static void ThreadExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch

            // Your code here...
            var stopwatch = new Stopwatch();
            // Start Stopwatch

            // Your code here...
            stopwatch.Start();
            // Create a new list of Thread objects

            // Your code here...
            var threads = new List<Thread>();

            // Iterate through files array passed in as an input to the current method with a foreach loop
            // In the body of the foreach loop create a new thread and inside the thread pass in a call to:
            // RotateImageFile(currentFile, alteredPath);
            // Finally before ending each iteration of the foreach loop add the created thread inside the list of threads.

            // Your code here...
            foreach (var file in files)
            {
                var thread = new Thread(() => RotateImageFile(file, alteredPath));
                threads.Add(thread);
            }


            // Write a foreach loop hear that will iterate over threads and will call .Start() to start each one of them

            // Your code here...

            foreach (var thread in threads)
            {
                thread.Start();
            }
            // Write a foreach loop hear that will iterate over threads and will call .Join() to wait for each one of them to finish execution

            // Your code here...
            foreach (var thread in threads)
            {
                thread.Join();
            }

            // Stop Stopwatch

            // Your code here...
            stopwatch.Stop();

            // Write in the console: "Time passed in thread execution: {0}", where {0} is the time elapsed in milliseconds.

            Console.WriteLine("Time passed in thread execution: {0}", stopwatch.ElapsedMilliseconds);
        }

        private static void NormalExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch

            // Your code here...
            var stopwatch = new Stopwatch();
            // Start Stopwatch

            // Your code here...
            stopwatch.Start();
            // Write a foreach loop hear that will iterate over files and will call:
            // RotateImageFile(currentFile, alteredPath);
            foreach (var currentfile in files)
            {
                RotateImageFile(currentfile, alteredPath);
            }
            // Stop Stopwatch

            stopwatch.Stop();
            // Your code here...

            // Write in the console: "Time passed in normal execution: {0}", where {0} is the time elapsed in milliseconds.

            Console.WriteLine("Time passed in normal execution: {0}", stopwatch.ElapsedMilliseconds);
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
