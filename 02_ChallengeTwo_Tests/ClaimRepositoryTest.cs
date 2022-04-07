using System.Collections.Generic;
using Xunit;
public class ClaimRepositoryTest
{
    [Fact]
    public void ViewAllClaims()
    {
        Queue<Claim> expectedClaimsList = new Queue<Claim>();

        ClaimRepository repository = new ClaimRepository();
        Assert.Equal(expectedClaimsList, repository.ViewAllClaims());
    }
}