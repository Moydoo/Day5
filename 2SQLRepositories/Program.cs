using _2SQLRepositories;

PersonsRepository personsRepository = new PersonsRepository();

Person[] people = personsRepository.GetPersons();

Person newPerson = new Person()
{
    FirstName = "Jan",
    LastName = "Kowalski"

};

personsRepository.CreatePerson(newPerson);

//foreach (var p in people)
//{
//    Console.WriteLine($"Farst name is {p.FirstName} and last name is {p.LastName}");
//}

