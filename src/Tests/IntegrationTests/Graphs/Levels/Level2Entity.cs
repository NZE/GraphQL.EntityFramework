﻿using System;

public class Level2Entity
{
    public Guid Id { get; set; } = XunitLogging.Context.NextGuid();
    public Guid Level1EntityId { get; set; }
    public Level1Entity Level1Entity { get; set; } = null!;
}