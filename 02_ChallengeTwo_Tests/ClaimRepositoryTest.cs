using System;
using System.Collections.Generic;
using Xunit;
public class ClaimRepositoryTest
{
    [Fact]
    public void ViewAllClaims_ShouldReturnEqual()
    {
        Queue<Claim> expectedClaimsList = new Queue<Claim>();

        ClaimRepository repository = new ClaimRepository();
        Assert.Equal(expectedClaimsList, repository.ViewAllClaims());
    }

    [Fact]
    public void PeekTopClaim_ShouldReturnSameValues()
    {
        // AAA Setup
        // Arrange
        ClaimRepository repository = new ClaimRepository();
        // add some claims
        var carClaim = new Claim(ClaimType.Car, "Car accident", 100m, new DateTime(2022, 4, 6), new DateTime(2022, 4, 7));
        var houseClaim = new Claim(ClaimType.Home, "House fire", 500m, new DateTime(2022, 3, 31), new DateTime(2022, 4, 1));

        repository.AddNewClaimToQueue(carClaim);
        repository.AddNewClaimToQueue(houseClaim);

        // Act
        var expected = repository.PeekTopClaim();
        var actual = carClaim;

        // Assert
        Assert.Equal(expected, actual);
    }
}