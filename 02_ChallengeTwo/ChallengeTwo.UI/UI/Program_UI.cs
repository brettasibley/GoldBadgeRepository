using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Program_UI
{
    private readonly ClaimRepository _cRepo = new ClaimRepository();
    public void Run()
    {
        SeedData();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to Komodo Claims Department");
            System.Console.WriteLine("Please make a selection\n"+
            "1. View All Claims\n"+
            "2. Take Care of Next Claim\n"+
            "3. Enter a New Claim\n"+
            "4. Close Application\n");

            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    ViewAllClaims();
                    break;
                case "2":
                    TakeCareOfNextClaim();
                    break;
                case "3":
                    EnterNewClaim();
                    break;
                case "4":
                    isRunning = CloseApplication();
                    break;
                default:
                    System.Console.WriteLine("Invalid Selection");
                    PressAnyKeyToContinue();
                    break;
            }
            isRunning = false;
        }
    }

    private void PressAnyKeyToContinue()
    {
        System.Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private bool CloseApplication()
    {
        Console.Clear();
        PressAnyKeyToContinue();
        return false;
    }

    private void EnterNewClaim()
    {
        throw new NotImplementedException();
    }

    private void TakeCareOfNextClaim()
    {
        throw new NotImplementedException();
    }

    private void ViewAllClaims()
    {
        Console.Clear();

        Queue<Claim> claimsInDb = _cRepo.ViewAllClaims();
        DisplayClaimHeader();
        DisplayClaimRow(claimsInDb.Peek());
    }

    private void DisplayClaimInfo(Claim claim)
    {
        System.Console.WriteLine($"Claim ID: {claim.ID}\n"+
        $"Claim Type: {claim.ClaimType}\n"+
        $"Description: {claim.ClaimDescription}\n"+
        $"Amount: {claim.ClaimAmount}\n"+
        $"Date of Incident: {claim.DateOfIncident}\n"+
        $"Date of Claim: {claim.DateOfClaim}\n"+
        $"Is the claim valid?: {claim.IsValid}\n"+
        "-------------------------------------------------\n");
    }

    private void DisplayClaimRow(Claim claim)
    {
        // System.Console.WriteLine($"{claim.ID}"+
        // $" {claim.ClaimType}"+
        // $" {claim.ClaimDescription}"+
        // $" {claim.ClaimAmount}"+
        // $" {claim.DateOfIncident}"+
        // $" {claim.DateOfClaim}"+
        // $" {claim.IsValid}");
        object[] stringer = {claim.ID,claim.ClaimType,claim.ClaimDescription,claim.ClaimAmount,claim.DateOfIncident,claim.DateOfClaim,claim.IsValid};
        string joined = string.Join("\t", stringer);
        System.Console.WriteLine(joined);
    }

    private void DisplayClaimHeader()
    {
        // System.Console.WriteLine("ClaimID Type Description Amount DateOfAccident DateOfClaim IsValid");
        string[] stringer = {"Claim ID","Type","Description","Amount","Date of Accident","Date of Claim","Is Valid"};
        string joined = string.Join("\t", stringer);
        System.Console.WriteLine(joined);
    }

    private void SeedData()
    {
        var carClaim = new Claim(ClaimType.Car,"Car accident",100m,new DateTime(2022,4,6),new DateTime(2022,4,7),true);
        var houseClaim = new Claim(ClaimType.Home,"House fire",500m,new DateTime(2022,3,31),new DateTime(2022,4,1),true);

        _cRepo.AddNewClaimToQueue(carClaim);
    }
}