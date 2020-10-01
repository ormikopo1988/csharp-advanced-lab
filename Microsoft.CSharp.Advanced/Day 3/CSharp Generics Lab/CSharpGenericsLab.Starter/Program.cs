using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace CSharpGenericsLab.Starter
{
    class Program
    {
        static void Main(string[] args)
        {
            //ScenarioOne();
           // ScenarioTwo();
            //ScenarioThree();
            //ScenarioFour();
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

            foreach(string r in requests)
            {
                Console.WriteLine(r);
            }

            // Write code to get the "Request2" from the collection
            requests.TryDequeue(out string output1);
            Console.WriteLine(output1);
            requests.TryPeek(out string output2);
            Console.WriteLine(output2);


            // Delete all the elements from the collection.
            requests.Clear();

            // Print the number of the elements in the collection.
            Console.WriteLine("Count = {0}", requests.Count);

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
            SortedDictionary<string, string> openWith = new SortedDictionary<string, string>();

            // Add some elements to the collection.
            // 1st item => Key: "txt", Value: "notepad.exe"
            // 2nd item => Key: "bmp", Value: "paint.exe"
            // 3rd item => Key: "dib", Value: "paint.exe"
            // 4th item => Key: "rtf", Value: "wordpad.exe"
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // Try add an element with the same key, e.g. "txt".
            // Surround with try catch block. The catch block will expect an ArgumentException.
            // Inside the catch block write a message that the element with the specified key already exists.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The element with the specified key already exists.");
            }

            // Access the "rtf" element of the collection by using the string indexer and write to console.
            Console.WriteLine("rtf-->value={0}",openWith["rtf"]);

            // Use the indexer "rtf" to change the value associated with it.
            // Write the new value to the console.
            openWith["rtf"] = "new value!!!";
            Console.WriteLine("rtf-->new value={0}", openWith["rtf"]);
            // Add a new element in the collection by setting the indexer for a key "doc" with a value "winword.exe".

            openWith["doc"] = "winword.exe";
            Console.WriteLine("rtf-->new value={0}", openWith["rtf"]);

            // Use the indexer to request a key called "tif" that does not exist in the collection.
            // Surround with try / catch block with a KeyNotFoundException and write the error message 
            // that the specified key was not found in the console.

            try
            {
                
                    var tif=openWith["tif"];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("The specified key was not found in the console.");
            }


            // Use a more efficient way to find the value in the collection by 
            // using a try get value logic that the collection has.
            // Try find the "tif" element in the collection and print its value to the console.
            string output = "";
            if (openWith.TryGetValue("tif", out output))
            {
                Console.WriteLine("key =tif--> value = {0}.", output);
            }

            // Check if the key "ht" is contained inside the collection.
            // If not then add it with the value of "hypertrm.exe" to the collection.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("key = ht, Value= {0}", openWith["ht"]);
            }

            // Enumerate the collection elements and print their key and value to the console.
            foreach (KeyValuePair<string, string> el in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}",el.Key, el.Value);
            }

            // Get the values of the collection alone
            SortedDictionary<string, string>.ValueCollection values =openWith.Values;
            foreach (string v in values)
            {
                Console.WriteLine("Value = {0}", v);
            }
            // Get the keys of the collection alone
            SortedDictionary<string, string>.KeyCollection keys = openWith.Keys;
            foreach (string k in keys)
            {
                Console.WriteLine("Key = {0}", k);
            }
            // Remove the "doc" element from the collection.
            openWith.Remove("doc");

            // Enumerate the collection elements and print their key and value to the console.
            foreach (KeyValuePair<string, string> el in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", el.Key, el.Value);
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

            // Add parts to the collection.
            parts.Add(new Part { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part { PartName = "chain ring", PartId = 1334 });
            parts.Add(new Part { PartName = "regular seat", PartId = 1434 });
            parts.Add(new Part { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part { PartName = "shift lever", PartId = 1634 });

            // Write out the parts in the collection. This will call the overridden ToString method in the Part class.
            foreach (Part pa in parts)
            {
                Console.WriteLine(pa.ToString());
            }

            // Check the collection for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Part p = parts.Where(p => p.PartId == 1734).FirstOrDefault();
            if(p!=null)
            {
                Console.WriteLine($@"parts contains partId {p.PartId.ToString()}");
            }

            // This will remove part 1534 even though the PartName is different,
            // because the Equals method only checks PartId for equality.
            parts.Remove(new Part { PartId = 1534});

            // Remove the part at index 3.
            parts.RemoveAt(3);

            // Print the parts again
            foreach (Part pa in parts)
            {
                Console.WriteLine(pa.ToString());
            }

        }

        static void ScenarioFour()
        {
            // The elements of the collection are enumerated and thus do not change the state of the collection.
            // The storage of the information will be temporary; that is, you might want to discard an element after retrieving its value.
            // Choose the collection that after adding the elements you can access the information in the reverse order than the one that were originally stored.
            // A common use for this particular collection is to preserve variable states during calls to other procedures.


            // Create a generic collection with five strings and default capacity and give it the name "shirts".
            // Put inside the collection the strings "GreenShirt", "BlueShirt", "RedShirt", "OrangeShirt", "YellowShirt".
            Stack<string> shirts = new Stack<string>();
            shirts.Push("GreenShirt");
            shirts.Push("BlueShirt");
            shirts.Push("RedShirt");
            shirts.Push("OrangeShirt");
            shirts.Push("YellowShirt");

            // Write code to enumerate through the elements of the collection.
            foreach (string s in shirts)
            {
                Console.WriteLine(s);
            }

            // Write code to get the "RedShirt" from the collection
            Console.WriteLine("1.'", shirts.Pop());
            Console.WriteLine("2.'", shirts.Pop());
            Console.WriteLine("3.", shirts.Peek());

            // Delete all the elements from the collection.
            shirts.Clear();

            // Print the number of the elements in the collection.
            Console.WriteLine("Count = {0}", shirts.Count);

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
            Console.WriteLine("EvenNumbers:");
            // Iterate through the collection "evenNumbers" and print the elements to the console
            foreach (int en in evenNumbers)
            {
                Console.WriteLine(en.ToString());
            }

            // Iterate through the collection "oddNumbers" and print the elements to the console
            Console.WriteLine("oddNumbers:");
            foreach (int od in oddNumbers)
            {
                Console.WriteLine(od.ToString());
            }
            // Create a new collection populated with even numbers.
            HashSet<int> numbers = new HashSet<int>();
            numbers = evenNumbers;

            // Iterate through the collection "numbers" and print the elements to the console//
            foreach (int n in numbers)
            {
                Console.WriteLine(n.ToString());
            }

        }
    }
}