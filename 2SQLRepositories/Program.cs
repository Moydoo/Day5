using _2SQLRepositories;

PersonsRepository personsRepository = new PersonsRepository();

Person[] people = personsRepository.GetPersons();

foreach (var p in people)
{
    Console.WriteLine($"Farst name is {p.FirstName} and last name is {p.LastName}");
}