using System;

public class Level3Entity
{
    public Guid Id { get; set; } = XunitLogging.Context.NextGuid();
    public string? Property { get; set; }
    public Guid Level2EntityId { get; set; }
    public Level2Entity Level2Entity { get; set; } = null!;
}