# DDOS-NO-WAR-ASP-NET

This project was created to combat Putin's gangster regime in the Russian Federation. Anyone can download the release version or create a build of the project for themselves, thereby helping the world to stop Putin's imperial ambitions in the war against Ukraine. 
The list of the site includes all the important sites for the infrastructure of the Russian Federation, as well as the lying media. #NOWAR


This version is written in ASP.NET Core 3.1 to support Linux and Mac OS.

Since I don't have a Mac OS below I am providing information for building the build for Mac OS:

https://youtu.be/pat0Yqpwx3E

https://docs.microsoft.com/en-us/dotnet/core/tutorials/with-visual-studio-mac

Also if you need a build for Linux build information:

https://youtu.be/TL5eJtXWP10

https://youtu.be/lR2Vfp2d2kY

https://docs.microsoft.com/en-us/dotnet/core/install/linux-ubuntu

# HOW TO DOWNLOAD BUILDS 

The finished version of the build is in the Release builds
You can download the finished version by going to the releases section and downloading the ZIP archive. 

![image](https://user-images.githubusercontent.com/93394175/155883369-a18722ca-d164-40a0-b715-3673861b9574.png)

![image](https://user-images.githubusercontent.com/93394175/155883432-48c8bcff-ba5d-4723-9425-a40bf2fe5dfb.png)

Next, unpack the archive and use the instructions to run it on your operating system attached above.


# HOW TO USE PROXY

I recently added the ability to use proxies. 
The proxies are in the file "proxy.txt", I provided 40k proxy servers which were obtained through my ProxyGrabber (https://github.com/H4CK3ROFF/ProxyGrabber).

These proxies may be out of date and may not work, therefore it is better to use your own private proxies, or update often Proxy but newer ones.
You can get proxies through my ProxyGrabber (https://github.com/H4CK3ROFF/ProxyGrabber) or any other site or grabber at your discretion.


# HIGH LOAD AND CRASHES

Due to the fact that I received questions about the load on the RAM and CPU, I will answer here in this message. 
A multi-threaded DDOS attack is quite a resource-intensive task, using more threads will put more load on your CPU. 
RAM in turn is not controlled in C#, all variables created inside the program are cleared by JIT compiler C# itself at runtime, I can't control DRAM consumption in any way. Maximum peaked RAM consumption in my tests was 500 mb, on average it did not exceed 300 mb. It depends solely on your system and the garbage collector which is responsible for DRAM cleaning.

As were statements about the crashes, I have a few hours of such crashes have not been detected, on this I added a system of logging and automatic restart when Exception. If you will have crashes in the folder with the program you will have a file "program.log" in the presence of such can contact me by throwing this file, I will look at what may be the problem. 

