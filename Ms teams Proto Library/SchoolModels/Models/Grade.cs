public class Grade
{
    public int ID { get; set; }
    public string Name { get; set; }
    public List<Section> Sections { get; set; } = new List<Section>();
}