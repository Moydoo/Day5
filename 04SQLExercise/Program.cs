using _04SQLExercise;

using (var db = new AppDbContext())
{
    Coach newCoach = new Coach()
    {
        Name = "Alain Robert",
        DateOfEmployee = new DateTime(2000, 02, 2),
        ExperienceDescription = "Very experienced",
        Height = 180.34
    };

    db.Add(newCoach);
    db.SaveChanges();
}