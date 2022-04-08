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
            System.Console.WriteLine("Please make a selection\n" +
            "1. View All Claims\n" +
            "2. Take Care of Next Claim\n" +
            "3. Enter a New Claim\n" +
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
        Console.Clear();
        var newClaim = new Claim();
        System.Console.WriteLine("=== New Claim Form ===\n");

        System.Console.WriteLine("Please select a Claim Type:\n"+
        "1. Car\n"+
        "2. Home\n"+
        "3. Theft\n");

        System.Console.WriteLine("Please enter a description of the claim:");
        newClaim.ClaimDescription = Console.ReadLine();

        System.Console.WriteLine("Please enter a claim amount:");
        newClaim.ClaimAmount = decimal.Parse(Console.ReadLine());

        System.Console.WriteLine("Please enter the date of the incident:");
        newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());

        System.Console.WriteLine("Please enter the date of the claim:");
        newClaim.DateOfClaim = DateTime.Parse(Console.ReadLine());

        System.Console.WriteLine("Is this claim valid?:");
        var userInput = Console.ReadLine();
        if(userInput == "Y".ToLower())
        {
            newClaim.IsValid = true;
        }
        else
        {
            newClaim.IsValid = false;
        }

        bool isSuccessful = _cRepo.AddNewClaimToQueue(newClaim);
        if(isSuccessful)
        {
            System.Console.WriteLine("New claim was added to the queue");
        }
        else
        {
            System.Console.WriteLine("Claim failed to be added to the queue");
        }
        
        PressAnyKeyToContinue();
    }

    private void TakeCareOfNextClaim()
    {
        Console.Clear();
        System.Console.WriteLine("Here are the details for the next claim to be handled:");
        if (_cRepo.ViewAllClaims().Count > 0)
        {
            var nextClaim = _cRepo.PeekTopClaim();
            DisplayClaimInfo(nextClaim);
            System.Console.WriteLine("Would you like to process this claim? Y/N?");
            var userInput = Console.ReadLine();
            if (userInput == "Y".ToLower())
            {
                if (_cRepo.PullOffTopOfQueue())
                {
                    Console.Clear();
                    System.Console.WriteLine("SUCCESS");
                }
                else
                {
                    Console.Clear();
                    System.Console.WriteLine("FAILURE");
                }
            }
        }
        else
        {
            System.Console.WriteLine("There no more claims left to be handled");
        }

        PressAnyKeyToContinue();
    }

    private void ViewAllClaims()
    {
        Console.Clear();

        Queue<Claim> claimsInDb = _cRepo.ViewAllClaims();

        if (claimsInDb.Count > 0)
        {
            foreach (Claim claim in claimsInDb)
            {
                DisplayClaimInfo(claim);
            }
        }
        else
        {
            System.Console.WriteLine("There are no claims");
        }
    }

    private void DisplayClaimInfo(Claim claim)
    {
        System.Console.WriteLine($"Claim ID: {claim.ID}\n" +
        $"Claim Type: {claim.ClaimType}\n" +
        $"Description: {claim.ClaimDescription}\n" +
        $"Amount: {claim.ClaimAmount}\n" +
        $"Date of Incident: {claim.DateOfIncident}\n" +
        $"Date of Claim: {claim.DateOfClaim}\n" +
        $"Claim valid?: {claim.IsValid}\n" +
        "-------------------------------------------------\n");
    }

    private void SeedData()
    {
        var carClaim = new Claim(ClaimType.Car, "Car accident", 100m, new DateTime(2022, 4, 6), new DateTime(2022, 4, 7), true);
        var houseClaim = new Claim(ClaimType.Home, "House fire", 500m, new DateTime(2022, 3, 31), new DateTime(2022, 4, 1), true);

        _cRepo.AddNewClaimToQueue(carClaim);
        _cRepo.AddNewClaimToQueue(houseClaim);
    }
}