namespace DAL.Entities.Models
{
    public enum TournamentStatus
    {
        Scheduled = 1,   // Tournament is planned but not started
        Ongoing = 2,     // Currently running
        Completed = 3,   // Finished
        Cancelled = 4    // Cancelled for some reason
    }
}
