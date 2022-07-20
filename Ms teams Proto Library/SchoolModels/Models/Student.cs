public class Student : Person, IAttendee, IStudent
{
    public Student() { }
    public Student(string name, string email, IDBconnection db, ILocalConnection local)
    {
        Name = name;
        Email = email;
        Db = db;
        Excel = local;
    }
    public List<Batch> GetInfo()
    {
        return new List<Batch>();
    }
}