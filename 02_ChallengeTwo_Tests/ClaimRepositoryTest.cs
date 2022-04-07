using System.Collections.Generic;
using Xunit;
public class ClaimRepositoryTest
{
    [Fact]
    public void ViewAllClaims()
    {
        Queue<Claim> expectedClaimsList = new Queue<Claim>();
        expectedClaimsList.Enqueue(new Claim("Brian"));
        expectedClaimsList.Enqueue(new Claim("Brett"));

        ClaimRepository repository = new ClaimRepository();
        Assert.Equal(expectedClaimsList, repository.ViewAllClaims());
    }
}