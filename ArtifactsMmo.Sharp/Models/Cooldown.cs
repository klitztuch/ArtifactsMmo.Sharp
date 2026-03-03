namespace ArtifactsMmo.Sharp.Models;

public class Cooldown
{
    public int TotalSeconds { get; set; }
    public int RemainingSeconds { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime Expiration { get; set; }
    public string Reason { get; set; }
}