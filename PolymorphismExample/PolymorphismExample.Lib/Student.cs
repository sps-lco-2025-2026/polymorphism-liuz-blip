namespace PolymorphismExample.Lib;



public class Student : Person
{
    public string SchoolYear { get; set; }


    public Student(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, string schoolYear = null)
    : base(firstName, lastName, emailAddress, dateOfBirth)
    {
        if (schoolYear != null)
        {
            SchoolYear = schoolYear;
        }
        else
        {
            int age = CalcAge(dateOfBirth);
            if (age < 7) { SchoolYear = "Reception"; }
            if (age > 18) { SchoolYear = "University"; }
            else { SchoolYear = "Year" + Convert.ToString(age - 5); }
        }
    }


    public override string GetScreenName()
    {
        return $"{FirstName.ToLower()} {LastName.ToLower()} {DateOfBirth:yyyy} {SchoolYear.ToLower()}";
    }

}