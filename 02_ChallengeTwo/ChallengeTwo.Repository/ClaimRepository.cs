public class ClaimRepository
{
    private readonly Queue<Claim> _cQueue = new Queue<Claim>();
    private int _count = 0;
    public Queue<Claim> ViewAllClaims()
    {
        return _cQueue;
    }
    public Claim PeekTopClaim()
    {
        if(_cQueue.Count > 0)
        {
            var claim = _cQueue.Peek();
            return claim;
        }
        else
        {
            return null;
        }
    }
    public bool AddNewClaimToQueue(Claim claim)
    {
        if(claim != null)
        {
            _count++;
            claim.ID = _count;
            _cQueue.Enqueue(claim);
            return true;
        }
        else
        {
            return false;
        }
    }
}
