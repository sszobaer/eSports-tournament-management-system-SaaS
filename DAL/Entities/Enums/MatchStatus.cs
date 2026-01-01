namespace DAL.Entities.Models
{
    public enum MatchStatus
    {
        Pending = 1,     // Match not yet played
        InProgress = 2,  // Match currently happening
        Completed = 3,   // Match finished
        Cancelled = 4    // Match cancelled
    }
}
