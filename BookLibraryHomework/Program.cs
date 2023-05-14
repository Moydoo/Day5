using BookLibraryHomework;

LibRepo libRepo = new LibRepo();


while (true)
{
    Console.WriteLine("\n##### CHOOSE WHAT YOU WANT TO WORK WITH #####");
    Console.WriteLine("[1] Books");
    Console.WriteLine("[2] Borrowers");
    Console.WriteLine("[0] Exit");
    Console.Write("Enter your choice: ");

    int choice = int.Parse(Console.ReadLine());

    if (choice == 0)
    {
        break;
    }

    switch (choice)
    {
        case 1:
            libRepo.HandleBooks();
            break;

        case 2:
            libRepo.HandleBorrowers();
            break;

        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}







