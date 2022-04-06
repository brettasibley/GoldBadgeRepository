public class ClaimRepository
{
    private readonly List<Claim> _claimDatabase = new List<Claim>();
    private int _count;
    public List<Claim> ViewAllClaims()
    {
        return _claimDatabase;
    }

    public Claim PeekTopMostClaim()
    {
        return _claimDatabase.Last();
    }

    public void DealWithTopMostClaim()
    {
        _claimDatabase.RemoveAt(_claimDatabase.Count-1);
    }

    public bool AddNewClaim(Claim claim)
    {
        if(claim != null)
        {
            _count++;
            claim.ID = _count;
            _claimDatabase.Add(claim);
            return true;
        }
        else
        {
            return false;
        }
    }
}
