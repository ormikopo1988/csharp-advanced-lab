# 1st step:
# Open a command or powershell prompt and make sure you have the .NET Core SDK installed. 
# This can be easily checked by opening a terminal window and typing the below command.
# You should see the version of the SDK installed. 
# If not, you’ll want to download the .NET Core SDK at https://dotnet.microsoft.com/download. 

dotnet --version

# 2nd step (optional):
# To discover other commands available, you can just type either of the following commands:

dotnet

# or 

dotnet --help

# 3rd step:
# The first we will do is to create a solution. 
# A solution is something we use to keep track of all related projects. 
# We will take the following steps:
#  - Create a directory for our solution
#  - Invoke the command generating a solution
# Let's create a directory and then go to this directory by typing:

mkdir NetCoreCliLab

cd NetCoreCliLab

# 4th step:
# Next, let's create a solution. We do this with the following command:

dotnet new sln

# 5th step:
# Next up we will generate a library. 
# Now a library is not an executable program but more a set of files we include in other projects.
# To create a library we will need to type the following in the terminal:

dotnet new classlib -o MyWebApp.DataStore

# Above we can see that our general command is dotnet new, 
# followed by the type, which in this case is classlib, 
# then we use the flag -o and the last argument is the name of the project.
# It doesn't do much but it's valid C# code.

# 6th step:
# Let's add our library to the solution:

dotnet sln add MyWebApp.DataStore/MyWebApp.DataStore.csproj

# 7th step: 
# Ok, we need to add some code to our library project. We will do the following:
#  - Download a NuGet package from a NuGet repository
#  - Reference our NuGet package in our library code
#  - Build our code
# For this part, we will grab a specific library called Newtonsoft.Json by typing:

dotnet add MyWebApp.DataStore package Newtonsoft.Json

# 8th step:
# Sometimes you might be working on an existing project or you might have grabbed the latest changes. 
# Regardless of which, you might be missing some packages that your project or solution needs 
# to run properly. At that point, you can run the below command.
# This will grab the packages specified as package references in your projects csproj file.

dotnet restore

# 9th step:
# Update our library code
# In your library project, rename the file Class1.cs to Thing.cs and add the following code to it:

// Thing.cs

using static Newtonsoft.Json.JsonConvert;

namespace MyWebApp.DataStore
{
  public class Thing
  {
    public int Get(int left, int right) =>
        DeserializeObject<int>($"{left + right}");
  }
}

# 10th step: 
# Next up we need to compile our code. 
# This will, if successful, generate a so-called .dll file. 
# This is the format used by .NET for libraries and stands for dynamic link library.
# So let's compile our code with the command:

dotnet build

# 11th step:
# Create a test project by running the following command:

dotnet new xunit -o MyWebApp.DataStore.Tests

# 12th step: 
# Let's add our project to the solution file as well:

dotnet sln add MyWebApp.DataStore.Tests/MyWebApp.DataStore.Tests.csproj

# 13th step:
# The idea here is to test functionality found in our project called MyWebApp.DataStore. 
# For this to be possible we need to add a reference to library in our 
# MyWebApp.DataStore.Tests project, like so:

dotnet add MyWebApp.DataStore.Tests/MyWebApp.DataStore.Tests.csproj reference MyWebApp.DataStore/MyWebApp.DataStore.csproj

# 14th step:
# Open UnitTest1.cs, rename to LibraryTests.cs and put the following code in it:

using Xunit;

namespace MyWebApp.DataStore.Tests
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing()
        {
            Assert.Equal(42, new Thing().Get(19, 23));
        }
    }
}

# 15th step:
# We are now ready to run our test and inspect the outcome.
# To run the tests, type

dotnet test MyWebApp.DataStore.Tests/MyWebApp.DataStore.Tests.csproj

# 16th step:
# Next thing we are going to do is to create a Console App. 
# We want to show the whole idea of creating a reusable library that we can drop in anywhere, 
# from test projects to console to web app projects:

dotnet new console -o MyConsole

# 17th step:
# Let's add this project to the solution file

dotnet sln add MyConsole/MyConsole.csproj

# 18th step:
# Adding and using our library project
# Next order of business is to start using our library project and make it part of our 
# MyConsole project. So we add the dependency like so:

dotnet add MyConsole/MyConsole.csproj reference MyWebApp.DataStore/MyWebApp.DataStore.csproj

#19th step: 
# Next up we need to change the code of our Program.cs

using MyWebApp.DataStore;
using System;

namespace MyConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"The answer is {new Thing().Get(19, 23)}");
        }
    }
}

# 20th step:
# Let's run the app next

dotnet run -p MyConsole/MyConsole.csproj

# 21st step:
# Now lets create a web app project

dotnet new webapi -o MyWebApp.Client

# 22nd step:
# Again add it to our solution

dotnet sln add MyWebApp.Client/MyWebApp.Client.csproj

# 23rd step:
# Add the library as a project reference

dotnet add MyWebApp.Client/MyWebApp.Client.csproj reference MyWebApp.DataStore/MyWebApp.DataStore.csproj

#24th step:
# Rename WeatherForecastController.cs file to ValuesController.cs
# and open it and paste the following code:

using System;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.DataStore;

namespace MyWebApp.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public int Get()
        {
            var rng = new Random();
            return new Thing().Get(rng.Next(20, 55), rng.Next(20, 55));
        }
    }
}

# 25th step:
# Run the web app by typing the below command.
# As you can see, we do have to specify the -p flag to get the dotnet run command 
# to properly target the correct project. 
# We could have also navigated directly to the project folder. 
# In that case, we wouldn’t need to specify the project and just used dotnet run.

dotnet run -p .\MyWebApp.Client\MyWebApp.Client.csproj

# 26th step:
# Open a browser and navigate to:

https://localhost:5001/values

# 27th step:
# Suppose we’ve developed our application and it’s now time to publish. 
# We can easily do this straight from the command line via the below command.
# This will publish the website out in release mode 
# to a build folder in the root of your solution. 
# You could also specify an absolute path to a folder (such as one that IIS watches).

dotnet publish .\MyWebApp.Client\MyWebApp.Client.csproj -o ..\build -c Release