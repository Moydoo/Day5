using _03SQLExericise.Models;

VolleyballDatabaseContext db = new VolleyballDatabaseContext();

Person[] people = db.Persons.ToArray();

foreach (Person person in people)
{
    Console.WriteLine(person.FirstName + " " +person.LastName);
}
