using System;
using System.Reflection;
using Example01.Models;

Type entityType = typeof(Entity);

//
// First, we reed the name of the class:
//
Console.WriteLine($"Class: {entityType.Name}");

// 
// Information about properties can be read by accessing the PropertyInfo instances for each property
//
foreach (PropertyInfo prop in entityType.GetProperties())
{
    Console.Write($"({prop.PropertyType}, {prop.Name}) ");
}
Console.WriteLine();