public abstract class Person
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime? JoinTime { get; set; } = null;
    public DateTime? LeaveTime { get; set; } = null;
    public TimeSpan? Duration { get; set; } = null;
    public string Status { get; set; }
    public IDBconnection Db { get; set; }
    public ILocalConnection Excel { get; set; }

}