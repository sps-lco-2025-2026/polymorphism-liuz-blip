using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolymorphismExample.Lib;
using System;
using System.Collections.Generic;

namespace PolymorphismExample.Tests;

[TestClass]
public class PersonSystemTests
{
    [TestMethod]
    public void Test_Person_IsBirthday_Logic()
    {
        var birthdayPerson = new Person("Test", "User", DateTime.Today);
        Assert.IsTrue(birthdayPerson.isBirthday, "Should be true when DOB is today's date.");
    }


    [TestMethod]
    public void Test_Student_AutomaticYearCalculation()
    {
        DateTime dob = DateTime.Today.AddYears(-12);
        var student = new Student("Bob", "Jones", "bob@school.com", dob);
        Assert.AreEqual("Year7", student.SchoolYear);
    }

    
    [TestMethod]
    public void Test_Polymorphic_ScreenNames()
    {
        DateTime dob = new DateTime(2000, 1, 1);
        List<Person> people = new List<Person>
        {
            new Person("John", "Doe", dob),
            new Student("Jane", "Smith", "jane@email.com", dob, "Year10"),
            new Teacher("Alpha", "Beta", "a@b.com", dob, "Maths")
        };
        string personName = people[0].GetScreenName();
        string studentName = people[1].GetScreenName();
        string teacherName = people[2].GetScreenName();

        Assert.AreEqual("john doe 2000", personName);
        Assert.IsTrue(studentName.Contains("year10"), "Student screen name should include the year group.");
        Assert.IsTrue(teacherName.Contains("maths"), "Teacher screen name should include the subject.");
    }

    [TestMethod]
    public void Test_Age_Validation_Logic()
    {
        var child = new Person("Kid", "User", DateTime.Today.AddYears(-10));
        var adult = new Person("Adult", "User", DateTime.Today.AddYears(-25));

        Assert.IsFalse(child.isAdult, "A 10-year-old should not be an adult.");
        Assert.IsTrue(adult.isAdult, "A 25-year-old should be an adult.");
    }
}