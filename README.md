# Exercise

The company ACME offers their employees the flexibility to work the hours they want. But due to some external circumstances they need to know what employees have been at the office within the same time frame

The goal of this exercise is to output a table containing pairs of employees and how often they have coincided in the office.

Input: the name of an employee and the schedule they worked, indicating the time and hours. This should be a .txt file with at least five sets of data. You can include the data from our examples below:

Example 1:

INPUT  
RENE=MO10:00-12:00,TU10:00-12:00,TH01:00-03:00,SA14:00-18:00,SU20:00- 21:00  
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00  
ANDRES=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

  
OUTPUT:  
ASTRID-RENE: 2  
ASTRID-ANDRES: 3  
RENE-ANDRES: 2

Example 2:

INPUT:  
RENE=MO10:15-12:00,TU10:00-12:00,TH13:00-13:15,SA14:00-18:00,SU20:00-21:00  
ASTRID=MO10:00-12:00,TH12:00-14:00,SU20:00-21:00

OUTPUT:  
RENE-ASTRID: 3


# Solution

To solve the exercise proposed C# .NET 6 has been used, below are explained some of requirements to run the console application and implemented solution.

## Requirements

To run the console app on any OS(windows, linux, mac) is necesary have installed .NET 6 sdk, available in https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Architecture

To solve the proposed exercise MVC architecture pattern has been used, after analizing the input format, we can observe that two entities exists Employee on Schedule, and these entities are part of Model layer, the business logic is separated in Controller layer, and finally the console execution program is the View layer.
Also, dependecy injection and some data structures as been used.

## Metodology

To solve the proposed exercise, the next steps were used:
- Reading txt file with input data
- Mapping data extracted from txt into models Employee and Schedule
- Comparing schedules to get coincidences
- Set a dictionary with coincidences founded

# Instructions

To execute the console app .NET 6 SDK should be installed first.
The code has the following estructure:
- acme.exercise
    - acme.exercise
        - Model
        - Controller
        - Utils
        - acme.exercise.csproj
        - Program.cs
        - input_file.txt
    - acme.exercise.sln
    
The console app needs to be executed from terminal, we need to be located in the directory where **acme.exercise.csproj** reside, once we are located in this directory, we could execute the following command:
**dotnet run "input_file.txt"**
the argument "input_file.txt" is a reference for text file containing the data that are going to be processed, in this argument we can pass a full path of txt file, or if the file exists at the same directory we can pass only the name with the file extension