using Example02.Models;

var type = typeof(Entity);

//
// We can create an instance of the known class type
//
Entity? instance = Activator.CreateInstance(type) as Entity;
Console.WriteLine(instance);

//
// We can dinamically set the value of the certain property, given the instance
//
var nameProp = typeof(Entity).GetProperty("Name");
nameProp.SetValue(instance, "new value");
Console.WriteLine(instance);

//
// What if the class has no default constructor?
// CreateInstance method also accepts object[] params after the class type parameter 
// 
var animalType = typeof(Animal);

var crow = Activator.CreateInstance(animalType, "Corvus capensis", "Aves");
Console.WriteLine(crow);

