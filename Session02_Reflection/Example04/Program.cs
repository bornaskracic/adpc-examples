using System.Linq.Expressions;
using Example04.Models;

//
// Representing filter lambda as an Expression can be useful if we want to parse it using Visitor pattern
//
Expression<Func<Student, bool>> func = (x => x.Name == "needle" && x.Age > 20);
var sql = SqlBuilder<Student>.Where(func);
Console.WriteLine(sql);
