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

            // Exercise 2
            //var path = Directory.GetCurrentDirectory();

            //var files = Directory.GetFiles(path + @"\pictures", "*.jpg");

            //var alteredPathParallel = path + @"\alteredPathParallel";
            //var alteredPathThread = path + @"\alteredPathThread";
            //var alteredPathNormal = path + @"\alteredPathNormal";

            //Directory.CreateDirectory(alteredPathParallel);
            //Directory.CreateDirectory(alteredPathThread);
            //Directory.CreateDirectory(alteredPathNormal);

            // Write a for loop (i=0 to i=10)
            // Inside the for loop write three messages in the console:
            // - $"{i + 1} iteration: ParallelExecution"
            // - $"{i + 1} iteration: ThreadExecution"
            // - $"{i + 1} iteration: NormalExecution"
            // Just below each of these messages call the respective method execution that you wrote below and pass:
            // - The files array
            // - The appropriate alteredPath variable based on the model execution of code.

            // Your code here...

            Console.ReadLine();
        }

        #region Exercise 1

        private static string ParallelProcess()
        {
            // Initialize new Stopwatch

            // Your code here...

            // Start Stopwatch

            // Your code here...

            // Write a for loop using the Parallel.For TPL construct from 0 to Environment.ProcessorsCount and pass it a simple Action giving it an input with name index 
            // and also the CurrentThread ManagedThreadId. The format used in the console woule be: "Printing {0} thread = {1}", where {0} is the 
            // iterator index passed as an input in the Action<int> of the body of Parallel.For loop construct.

            // Your code here...

            // Stop Stopwatch

            // Your code here...

            // Return "ParallelProcess: Time in milliseconds {0}", where {0} is the time elapsed in milliseconds.

            return string.Empty; // Just for the code to compile - Your return statement goes here...
        }

        private static string ThreadProcess()
        {
            // Initialize new Stopwatch

            // Your code here...

            // Start Stopwatch

            // Your code here...

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

            // Stop Stopwatch

            // Your code here...

            // Return "ThreadProcess: Time in milliseconds {0}", where {0} is the time elapsed in milliseconds.

            return string.Empty; // Just for the code to compile - Your return statement goes here...
        }

        #endregion

        #region Exercise 2

        private static void ParallelExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch

            // Your code here...

            // Start Stopwatch

            // Your code here...

            // Write a parallel loop using Parallel.Foreach construct. 
            // Pass in the input files argument (string[]) as the first argument
            // Create a ParallelOptions object and set the MaxDegreeOfParallelism to Environment.ProcessorCount and pass it as the second argument.
            // Create an Action<string> body and pass it as the third argument. The Action<string> will take each as input a string called "currentFile" 
            // and inside its body will call: RotateImageFile(currentFile, alteredPath);

            // Your code here...

            // Stop Stopwatch

            // Your code here...

            // Write in the console: "Time passed in parallel execution: {0}", where {0} is the time elapsed in milliseconds.

            Console.WriteLine();
        }

        private static void ThreadExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch

            // Your code here...

            // Start Stopwatch

            // Your code here...

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

            // Stop Stopwatch

            // Your code here...

            // Write in the console: "Time passed in thread execution: {0}", where {0} is the time elapsed in milliseconds.

            Console.WriteLine();
        }

        private static void NormalExecution(string[] files, string alteredPath)
        {
            // Initialize new Stopwatch

            // Your code here...

            // Start Stopwatch

            // Your code here...

            // Write a foreach loop hear that will iterate over files and will call:
            // RotateImageFile(currentFile, alteredPath);

            // Stop Stopwatch

            // Your code here...

            // Write in the console: "Time passed in normal execution: {0}", where {0} is the time elapsed in milliseconds.

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
