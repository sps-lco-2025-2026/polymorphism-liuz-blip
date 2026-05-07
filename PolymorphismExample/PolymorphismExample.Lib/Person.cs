namespace PolymorphismExample.Lib;



public class Person
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public DateTime DateOfBirth { get; set; }


    public Person(string firstName, string lastName, string emailAddress, DateTime dateOfBirth)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
    }


    public Person(string firstName, string lastName, DateTime dateOfBirth)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
    }


    protected int CalcAge(DateTime dateOfBirth)
    {
        DateTime today = DateTime.Today;
        int age = today.Year - dateOfBirth.Year;
        if (dateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }

    public bool isValid => CalcAge(DateOfBirth) >= 0;
    public bool isAdult => CalcAge(DateOfBirth) >= 18;
    public bool isBirthday => DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day == DateOfBirth.Day;
    public string ChineseSign => GetChineseSign();
    public string ScreenName => GetScreenName();

    public string GetChineseSign()
    {
        List<string> signs = new List<string>() { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        int year = DateOfBirth.Year;
        return signs[year % 12];
    }

    public virtual string GetScreenName()
    {
        return $"{FirstName.ToLower()} {LastName.ToLower()} {DateOfBirth:yyyy}";
    }
}
