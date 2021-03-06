public class Claim
{
    public Claim (){}
    public Claim (ClaimType claimType, string claimDescription, decimal claimAmount, DateTime dateOfIncident, DateTime dateOfClaim)
    {
        ClaimType = claimType;
        ClaimDescription = claimDescription;
        ClaimAmount = claimAmount;
        DateOfIncident = dateOfIncident;
        DateOfClaim = dateOfClaim;
    }

    public int ID { get; set; }
    public ClaimType ClaimType { get; set; }
    public string ClaimDescription { get; set; }
    public decimal ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid 
    { 
        get
        {
            // return (DateOfClaim.Day - DateOfIncident.Day)<30;
            var span=DateOfClaim-DateOfIncident;
            return span.TotalDays<30;
        }
    }
}
