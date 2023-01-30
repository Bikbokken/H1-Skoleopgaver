Console.WriteLine("Hvad er din fødselsdag dd/MM/yyyy");
DateTime birthday = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
DateTime now = DateTime.Now;

TimeSpan dif = now - birthday;
int years = (int) Math.Floor(dif.TotalDays / 365.2425);

int days = (int) Math.Floor((now - birthday.AddYears(years)).TotalDays);

Console.WriteLine("Du er: " + years + " år og " + days + " dage gammel.");



