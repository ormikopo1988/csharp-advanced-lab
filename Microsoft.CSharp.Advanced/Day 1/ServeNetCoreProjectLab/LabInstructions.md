# Prerequisites

1. .NET Core SDK installed on the development machine.
2. Windows machine configured with the Web Server (IIS) server role. 

If your machine does not have the .NET Core SDK installed get it from here

https://dotnet.microsoft.com/download/dotnet-core/thank-you/sdk-3.1.401-windows-x64-installer

If your machine isn't configured to host websites with IIS, follow the guidance below (IIS configuration section).

# IIS configuration

Enable the IIS Management Console and World Wide Web Services.

1. Navigate to Control Panel > Programs > Programs and Features > Turn Windows features on or off (left side of the screen).

2. Open the Internet Information Services node. Open the Web Management Tools node.

3. Check the box for IIS Management Console.

4. Check the box for World Wide Web Services.

5. Accept the default features for World Wide Web Services or customize the IIS features

# Install the .NET Core Hosting Bundle

Install the .NET Core Hosting Bundle on the hosting system. 
The bundle installs the .NET Core Runtime, .NET Core Library, and the ASP.NET Core Module. 
The module allows ASP.NET Core apps to run behind IIS.

Download the installer using the following link:

https://dotnet.microsoft.com/permalink/dotnetcore-current-windows-runtime-bundle-installer

# Create the IIS site

1. On your development machine, browse to C:\temp folder and create a folder to contain the app's published folders and files. 
Name the folder iisnetcorepublishlab.
In a following step, the folder's path is provided to IIS as the physical path to the app.
(C:\temp\iisnetcorepublishlab)

2. In IIS Manager, open the server's node in the Connections panel. 
Right-click the Sites folder. Select Add Website from the contextual menu.

3. Provide a Site name and set the Physical path to the app's deployment folder that you created. 
Provide the Binding configuration and create the website by selecting OK.
Sitename: iisnetcorepublishlab
Physical Path: C:\temp\iisnetcorepublishlab
Host name: www.iisnetcorepublishlab.com

4. Under the server's node, select Application Pools.

5. Right-click the site's app pool and select Basic Settings from the contextual menu.

6. In the Edit Application Pool window, set the .NET CLR version to No Managed Code:

ASP.NET Core runs in a separate process and manages the runtime. 
ASP.NET Core doesn't rely on loading the desktop CLR (.NET CLR). 
The Core Common Language Runtime (CoreCLR) for .NET Core is booted to host the app in the worker process. 
Setting the .NET CLR version to No Managed Code is optional but recommended.

# Create a web app project

1. Navigate to C:\temp

2. Open a Command Prompt / Powershell Window 

3. Run dotnet new webapp -o aspnetcoreapp

4. cd aspnetcoreapp
dotnet watch run

5. Open Pages/Index.cshtml and change the contents of the <p> tag and save the page as follows

"p" Hello, world! The time on the server is @DateTime.Now "/p"

6. Ctrl + C to stop the app 

# Publish and deploy the app

Publish an app means to produce a compiled app that can be hosted by a server. 
Deploy an app means to move the published app to a hosting system. 
The publish step is handled by the .NET Core SDK, while the deployment step can be handled by a variety of approaches. 
This lab adopts the folder deployment approach, where:

The app is published to a folder.
The folder's contents are moved to the IIS site's folder (the Physical path to the site in IIS Manager).

1. Make sure you are still in the C:\temp\aspnetcoreapp folder

2. Run dotnet publish --configuration Release --no-self-contained --output "C:\temp\iisnetcorepublishlab"

3. Open your hosts file in: C:\Windows\System32\drivers\etc

4. Put this line at the end: 127.0.0.1 www.iisnetcorepublishlab.com

5. Open a browser and navigate to www.iisnetcorepublishlab.com