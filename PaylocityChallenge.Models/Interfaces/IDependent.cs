namespace PaylocityChallenge.Models
{
    public interface IDependent
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}