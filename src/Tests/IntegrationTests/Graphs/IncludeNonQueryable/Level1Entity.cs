using System;

public class Level1Entity
{
    public Guid Id { get; set; } = XunitLogging.Context.NextGuid();
    public Guid Level2EntityId { get; set; }
    public IncludeNonQueryableA IncludeNonQueryableA { get; set; } = null!;
}