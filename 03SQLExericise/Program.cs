using _03SQLExericise.Models;
using Microsoft.Data.SqlClient;


VolleyballDatabaseContext db = new VolleyballDatabaseContext();
Person[] people = db.Persons.ToArray();

//foreach (Person p in people)
//{
//    Console.WriteLine(p.FirstName + " " + p.LastName);
//}


//ORM - map database into objects in our C# app

// EntityFramework - it allows us to create this mapping (but there are other alternatives:)
//2) LINQ-To-SQL (Obsolate)
//3) Hibernate



Person person = new Person()
{
    FirstName = "Gimme",
    LastName = "Rimmi"
};


try
{
    db.Persons.Add(person);
    db.SaveChanges();
    Console.WriteLine("Created successfully");
}

catch (SqlException)
{
    Console.WriteLine("No no no");
}


//UPDATE

//Person toBeEddited = db.Persons.FirstOrDefault(x => x.Id == 7);
//toBeEddited.FirstName = "editedName";
//db.SaveChanges();


//Deliting


///it is a good practice to use using
using (VolleyballDatabaseContext db2 = new VolleyballDatabaseContext())
{
    Person toBeDeleted = db2.Persons.FirstOrDefault(x => x.Id == 7);
    db2.Persons.Remove(toBeDeleted);
    db2.SaveChanges();
}



