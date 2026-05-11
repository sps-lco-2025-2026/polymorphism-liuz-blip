namespace PolymorphismExample.Lib;



public class Teacher : Person
{
    public string Subject { get; set; }


    public Teacher(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, string subject)
    : base(firstName, lastName, emailAddress, dateOfBirth)
    {
        Subject = subject;
    }


    public override string GetScreenName()
    {
        return $"{FirstName.ToLower()} {LastName.ToLower()} {DateOfBirth:yyyy} {Subject.ToLower()}";
    }

}