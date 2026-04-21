namespace MvcMovie.Models;
public class Student
{
    public int StudentID { get; set; }
    public string? FullName { get; set; }

    public int FacultyID { get; set; }
    public Faculty? Faculty { get; set; }
}