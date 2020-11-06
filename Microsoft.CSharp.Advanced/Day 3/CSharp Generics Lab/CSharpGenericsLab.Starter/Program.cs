using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace CSharpGenericsLab.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
           // ScenarioOne();
           // ScenarioTwo();
           // ScenarioThree();
           // ScenarioFour();
            ScenarioFive();
        }

        static void ScenarioOne()
        {
            // The elements of the collection are enumerated and thus do not change the state of the collection.
            // The storage of the information will be temporary; that is, you might want to discard an element after retrieving its value.
            // Choose the collection that after adding the elements you can access the information in the same order that it is stored in the collection.
            // Make sure that the collection can be accessed from multiple threads concurrently

            // Create a generic collection with five strings and default capacity and give it the name "requests".
            // Put inside the collection the strings "Request1", "Request2", "Request3", "Request4", "Request5".
            ConcurrentQueue<string> requests = new ConcurrentQueue<string>();
            requests.Enqueue("Request1");
            requests.Enqueue("Request2");
            requests.Enqueue("Request3");
            requests.Enqueue("Request4");
            requests.Enqueue("Request5");
            // Write code to enumerate through the elements of the collection.
            foreach (var req in requests) 
            {
                Console.WriteLine(req);
            }

            // Write code to get the "Request2" from the collection

            var res = requests.TryDequeue(out string itemReq1);
            if (res) { Console.WriteLine(itemReq1); }
            res = requests.TryDequeue(out string itemReq2);
            if (res) { Console.WriteLine(itemReq2); }
            // Delete all the elements from the collection.
            requests.Clear();

            // Print the number of the elements in the collection.
            Console.WriteLine(requests.Count);

        }

        static void ScenarioTwo()
        {
            // Create a collection of key/value pairs that are sorted on the key.
            // Keys are unique inside the collection and access to the collection elements is happening by key.
            // Retrievals are fast, this collection is best for high performance lookups.
            // The key type will be string and the value type will also be string.
            // The generic collection class is a binary search tree with O(log n) retrieval, where n is the number of elements in the collection.

            // Create the sorted collection here.
            // Name the sorted collection "openWith".
            // Add some elements to the collection.
            // 1st item => Key: "txt", Value: "notepad.exe"
            // 2nd item => Key: "bmp", Value: "paint.exe"
            // 3rd item => Key: "dib", Value: "paint.exe"
            // 4th item => Key: "rtf", Value: "wordpad.exe"

            SortedDictionary<string, string> openWith = new SortedDictionary<string, string>();
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");
           
            // Try add an element with the same key, e.g. "txt".
            // Surround with try catch block. The catch block will expect an ArgumentException.
            // Inside the catch block write a message that the element with the specified key already exists.

            try
            {
                openWith.Add("txt", "llalalalla.exe");
            }
            catch(ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            // Access the "rtf" element of the collection by using the string indexer and write to console.
            Console.WriteLine($"rtf element value is: {openWith["rtf"]}");

            // Use the indexer "rtf" to change the value associated with it.
            // Write the new value to the console.
            openWith["rtf"] = "ttttt.exe";
            Console.WriteLine($"rtf element new value is: {openWith["rtf"]}");


            // Add a new element in the collection by setting the indexer for a key "doc" with a value "winword.exe".
            openWith.Add("doc", "winword.exe");

            // Use the indexer to request a key called "tif" that does not exist in the collection.
            // Surround with try / catch block with a KeyNotFoundException and write the error message 
            // that the specified key was not found in the console.
            try 
            {
                var tifValue = openWith["tif"];
            }
            catch (KeyNotFoundException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            // Use a more efficient way to find the value in the collection by 
            // using a try get value logic that the collection has.
            // Try find the "tif" element in the collection and print its value to the console.
            var containsTif = openWith.ContainsKey("tif");
            if (containsTif) 
            {
                Console.WriteLine(openWith["tif"]);
            }

            // Check if the key "ht" is contained inside the collection.
            // If not then add it with the value of "hypertrm.exe" to the collection.
            if (!openWith.ContainsKey("ht")) 
            {
                openWith.Add("ht", "hypertrm.exe");
            }

            // Enumerate the collection elements and print their key and value to the console.
            foreach (KeyValuePair<string, string> element in openWith)
            {
                Console.WriteLine($"Key: {element.Key} & Value: {element.Value}");
            }

            // Get the values of the collection alone
            SortedDictionary<string, string>.ValueCollection values = openWith.Values;

            // Get the keys of the collection alone
            SortedDictionary<string, string>.KeyCollection keys = openWith.Keys;

            // Remove the "doc" element from the collection.
            openWith.Remove("doc");

            // Enumerate the collection elements and print their key and value to the console.
            foreach (KeyValuePair<string, string> element in openWith)
            {
                Console.WriteLine($"Key: {element.Key} & Value: {element.Value}");
            }
        }

        static void ScenarioThree()
        {
            // Create a generic collection that contains strongly typed objects that can be accessed by index.
            // Internally, it uses an array whose size is dynamically increased as required.
            // The collection is not guaranteed to be sorted.
            // Elements in this collection can be accessed using an integer index.
            // Indexes in this collection are zero - based.

            // Create a Part object with two properties => PartName: string & PartId: int
            // Override the ToString() method of it and put: return "ID: " + PartId + "   Name: " + PartName;
            // Make sure you make the Part class implement the IEquatable<Part> interface.
            // Implement the necessary methods as follows:
            //public override bool Equals(object obj)
            //{
            //    if (obj == null)
            //    {
            //        return false;
            //    }

            //    Part objAsPart = obj as Part;

            //    if (objAsPart == null)
            //    {
            //        return false;
            //    }
            //    else
            //    {
            //        return Equals(objAsPart);
            //    }
            //}
            //public override int GetHashCode()
            //{
            //    return PartId;
            //}

            //public bool Equals(Part other)
            //{
            //    // Write code here to return false if null vaue is provided


            //    // Write code here to compare the two objects (this -> the current object & other -> the object provided as input argument) based on their PartId properties
            //    // and using the .Equals method

            //}

            // Choose the proper collection and name it "parts" and add inside it 6 Part objects.
            // 1st object => PartName = "creank arm", PartId = 1234
            // 2nd object => PartName = "chain ring", PartId = 1334
            // 3rd object => PartName = "regular seat", PartId = 1434
            // 4th object => PartName = "banana seat", PartId = 1444
            // 5th object => PartName = "cassette", PartId = 1534
            // 6th object => PartName = "shift lever", PartId = 1634

            // Create a collection of parts.
            List<Part> parts = new List<Part>();
            parts.Add(new Part() { PartId = 1234, PartName = "creank arm" });
            parts.Add(new Part() { PartId = 1334, PartName = "chain ring" });
            parts.Add(new Part() { PartId = 1434, PartName = "regular seat" });
            parts.Add(new Part() { PartId = 1444, PartName = "banana seat" });
            parts.Add(new Part() { PartId = 1534, PartName = "cassette" });
            parts.Add(new Part() { PartId = 1634, PartName = "shift lever" });
            // Add parts to the collection.
           

            // Write out the parts in the collection. This will call the overridden ToString method in the Part class.
            foreach (var item in parts) 
            {
                Console.WriteLine(item);
            }

            // Check the collection for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            if (parts.Contains(new Part() { PartId = 1734, PartName = "" }))
            {
                Console.WriteLine("there it is");
            }
            else 
            {
                Console.WriteLine("nooooooo");
            }

            // This will remove part 1534 even though the PartName is different,
            // because the Equals method only checks PartId for equality.
            parts.Remove(new Part { PartId = 1534, PartName = "" });


            // Remove the part at index 3.


            // Print the parts again
            parts.RemoveAt(3);

            // Print the parts again
            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }
        }

        static void ScenarioFour()
        {
            // The elements of the collection are enumerated and thus do not change the state of the collection.
            // The storage of the information will be temporary; that is, you might want to discard an element after retrieving its value.
            // Choose the collection that after adding the elements you can access the information in the reverse order than the one that were originally stored.
            // A common use for this particular collection is to preserve variable states during calls to other procedures.
            Stack<string> shirts = new Stack<string>();
            shirts.Push("GreenShirt");
            shirts.Push("BlueShirt");
            shirts.Push("RedShirt");
            shirts.Push("OrangeShirt");
            shirts.Push("YellowShirt");
            // Create a generic collection with five strings and default capacity and give it the name "shirts".
            // Put inside the collection the strings "GreenShirt", "BlueShirt", "RedShirt", "OrangeShirt", "YellowShirt".


            // Write code to enumerate through the elements of the collection.
            foreach (var shirt in shirts) 
            {
                Console.WriteLine(shirt);
            }

            // Write code to get the "RedShirt" from the collection
            shirts.Pop();
            shirts.Pop();
            Console.WriteLine(shirts.Peek());

            // Delete all the elements from the collection.

            shirts.Clear();
            // Print the number of the elements in the collection.
            Console.WriteLine(shirts.Count);
        }

        static void ScenarioFive()
        {
            // Create a collection that represents a set of values.
            // You need a collection that is based on the model of mathematical sets and 
            // provides high-performance set operations similar to accessing the keys of a Dictionary<TKey,TValue>
            // The collection is not sorted and cannot contain duplicate elements.
            // Performance for your application is more important than order or element duplication.

            // Create a collection of integers called "evenNumbers"
            HashSet<int> evenNumbers = new HashSet<int>();
            // Create a collection of integers called "oddNumbers"

            HashSet<int> oddNumbers = new HashSet<int>();
            // Uncomment this when you chose and created the two collections above
            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            // Iterate through the collection "evenNumbers" and print the elements to the console
            foreach (var item in evenNumbers) 
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            // Iterate through the collection "oddNumbers" and print the elements to the console
            foreach (var item in oddNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            // Create a new collection populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);

            // Compute the union of "numbers" and "oddNumbers" collections
            numbers.UnionWith(oddNumbers);
            // Iterate through the collection "numbers" and print the elements to the console//
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}