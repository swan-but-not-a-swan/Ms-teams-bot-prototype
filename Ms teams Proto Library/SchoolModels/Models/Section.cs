public class Section
{
    public int ID { get; set; }
    public char Name { get; set; }
    public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    public List<Student> Students { get; set; } = new List<Student>();
    public List<Period> Periods { get; set; } = new List<Period>();
}
