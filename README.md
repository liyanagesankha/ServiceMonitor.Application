# ServiceMonitor.Application
Service Monitoring Application using .Net Core.

## Technology Stack/ Frameworks/ Tools
* .NET Core 3.1
* Quartz framework to create long running schedule jobs. (NUuGet packages).
* MSTest for unit testing.
* Observable design pattern to change schedules frequency. (when user update requested service list.)
* Visual Studio 2019

## Solution Architecture Diagram
![Architecture Diagram](https://github.com/liyanagesankha/ServiceMonitor.Application/blob/master/Images/ArchitectureDiagram.png?raw=true)

## Project Code Structure
![Code Structure](https://github.com/liyanagesankha/ServiceMonitor.Application/blob/master/Images/CodeStructure.png?raw=true)

## To Run the Application
* First build the solution,
* Set the “ServiceMonitor.Application” as startup project.
* Run the application by clicking execute button in VS.

## To Improve the Application: 
* It’s better to come up with SignalR included Web frontend. 
* Also Email functionality for server down time notifications… etc.
