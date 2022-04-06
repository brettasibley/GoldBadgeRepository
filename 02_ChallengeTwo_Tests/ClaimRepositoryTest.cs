using System.Collections.Generic;
using Xunit;
public class ClaimRepositoryTest
{
    [Fact]
    public void ViewAllClaimsTest()
    {
        List<Claim> expectedClaimsList = new List<Claim>();
        expectedClaimsList.Add(new Claim("Brian"));
        expectedClaimsList.Add(new Claim("Brett"));

        ClaimRepository repository = new ClaimRepository();
        Assert.Equal(expectedClaimsList, repository.ViewAllClaims());
    }
}