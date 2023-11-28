namespace Lopez_PriorityQueue
{
    internal class Program
    {
        static bool DoExit = false;
        static PriorityQueue<Patient, int> ERQueue = new PriorityQueue<Patient, int>();
        static void Main(string[] args)
        {
            using (StreamReader? reader = new StreamReader(@$"{Directory.GetCurrentDirectory()}\Patients-1.csv"))
            {
                string contents = reader.ReadToEnd();
                string[] lines = contents.Split(Environment.NewLine);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == 0)
                        continue;

                    string line = lines[i];

                    if (string.IsNullOrEmpty(line.Trim()))
                        continue;

                    string[] values = line.Split(',');

                    string firstName = values[0];
                    string lastName = values[1];
                    DateTime birthDate = DateTime.Parse(values[2]);
                    int priority = int.Parse(values[3]);

                    Patient patient = new Patient(firstName, lastName, birthDate, priority);

                    ERQueue.Enqueue(patient, patient.PriorityLevel);
                }
            }

            while (!DoExit)
            {

                Console.WriteLine($"A. Add Patient {Environment.NewLine}P.Process Current Patient {Environment.NewLine}L. List All in Queue {Environment.NewLine}Q. Exit");
                string result = Console.ReadLine();
                switch (result)
                {
                    case "A":
                        Console.WriteLine("What is the patients first name to add?");
                        string firstNameToAdd = Console.ReadLine().Trim();
                        Console.WriteLine("What is the patients last name to add?");
                        string lasttNameToAdd = Console.ReadLine().Trim();
                        Console.WriteLine("What is the patients birthdate?");
                        DateTime birthdateToAdd = DateTime.Parse(Console.ReadLine().Trim());
                        Console.WriteLine("What is the priority level?");
                        int priorityLevel = int.Parse(Console.ReadLine().Trim());

                        Patient patient = new Patient(lasttNameToAdd, firstNameToAdd, birthdateToAdd, priorityLevel);
                        ERQueue.Enqueue(patient, patient.PriorityLevel);
                        break;
                    case "P":
                        // remove current patient
                        if (ERQueue.Count > 0)
                        {
                            ERQueue.Dequeue();
                            Console.WriteLine("removed patient");
                        }
                        else
                        {
                            Console.WriteLine("No more patients in Queue.");
                        }

                        break;
                    case "L":
                        // list all in queue
                        List<Patient> patients = ERQueue.UnorderedItems.Select(p => p.Element).OrderBy(p => p.PriorityLevel).ToList();
                        foreach (Patient p in patients)
                        {
                            Console.WriteLine($"{p}");
                        }
                        break;
                    case "Q":
                        DoExit = true;
                        break;
                }
            }
        }
    }
}