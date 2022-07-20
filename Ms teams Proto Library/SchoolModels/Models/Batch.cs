public class Batch
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Grade> Grades { get; set; } = new List<Grade>();
}
