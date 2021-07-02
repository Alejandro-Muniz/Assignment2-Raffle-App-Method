using System;
using System.Collections.Generic;

class MainClass
{
  //1. GetUserInput
  static string GetUserInput()
  {
    string guestName;
    Console.Write("Enter your guest's name: ");
    guestName = Console.ReadLine();
    return guestName; //12 GOTO 27 method 2
  }

  //2.  GetUserInfo 
  static Dictionary<int, string> GetUserInfo()
  {
    Dictionary<int, string> guests = new Dictionary<int, string>();
    int raffleNumber;
    string guestName;
    string otherGuests;
    do //min=1000 and max=9999, this loop will break if guests >= 9000
    {
      do //this do...while loop will continue unitl guestName is not empty
      {
        guestName = GetUserInput(); // 26 GOTO 6 method 1
      } while (guestName == "");
      guestName = guestName.ToLower();
      do  //this do...while loop will continue until raffleNumber is not in dict
      {
        raffleNumber = GenerateRandomNumber(); // 31 GOTO 42 method 3
      } while (guests.ContainsKey(raffleNumber));
      AddGuestsInRaffle(raffleNumber, guestName); // 33 GOTO 49 method 4   
      guests.Add(raffleNumber, guestName);
      Console.WriteLine("\n");
      Console.Write("Are there more guests to add to the raffle? (Y/N): ");
      otherGuests = Console.ReadLine().ToUpper();
    } while (otherGuests != "N"); // 38 GOTO 99 Main
    return guests;     
  }

  //3. GenerateRandomNumber
  static int GenerateRandomNumber()
  {
    int min = 1000;
    int max = 9999;
    Random r = new Random();
    int raffleNumber = r.Next(min, max);
    return raffleNumber; // 49 GOTO 34 method 2
  }

  //4. AddGuestsInRaffle 
  //(the guest, and raffle number need to be added to what Dictionary?)
  static void AddGuestsInRaffle(int raffleNumber, string guestName)
  {
    Console.WriteLine($"You are in the raffle {guestName}. Your raffle number is {raffleNumber}"); // 56 GOTO 34 module 2  //guests.Add(raffleNumber, guestName); 
  }  

  //5. PrintGuestsName
  static void PrintGuestsName(Dictionary<int, string> guests)
  {
    foreach (KeyValuePair<int,string> kvp in guests) Console.WriteLine(kvp);
  } //63 GOTO 100 Main

  //6.  GetRaffleNumber //select winning number
  static string GetRaffleNumber(Dictionary<int, string> guests)
  {
      int raffleNumber;
      int min = 1000;
      int max = 9999;
      Console.WriteLine("...and now to randomly select the winner!:");
    do  //this do...while loop will continue until raffleNumber matches a dict key
    {
      Random r = new Random();
      raffleNumber = r.Next(min, max);
    } while (!guests.ContainsKey(raffleNumber));
    string winner = guests[raffleNumber].ToUpper();
    Console.WriteLine($"The winning raffle ticket number is {raffleNumber} !");
    return winner; // 79 GOTO 86 mehtod 7
  } 
 
  //7. PrintWinner
  static void PrintWinner(Dictionary<int, string> guests) // called from Main
  {
    string winner = GetRaffleNumber(guests); // 85 GOTO 65 method 6
    Console.WriteLine($"Congratulations {winner}!!!"); //86 GOTO 101 Main 
  }

  //********************************************************************
  //********************************************************************

  public static void Main (string[] args) 
  {
    Dictionary<int, string> guests = new Dictionary<int, string>();  //which methods need the dictionary?
    //method 2 --> method 1 --> method 2 --> method3 --> method 2 --> method 4 --> method 2 --> method 5 --> method 7 --> method 6 --> method 7 --> winner
    // S T A R T    H E R E  96
    Console.WriteLine("Welcome to the Party!!");
    guests = GetUserInfo(); //98 GOTO 15 method 2 --> m1-return --> m3-return --> m4-return
    PrintGuestsName(guests);//99 GOTO 59 method 5
    PrintWinner(guests);    //100 GOTO 82 method 7 --> m6-return
    // E N D    H E R E  101
  }
}






/*
using System;
using System.Collections.Generic;

class MainClass 
{
  public static void Main (string[] args) 
  {
    Dictionary<int, string> guests = new Dictionary<int, string>();
    string guestName;
    int min = 1000;
    int max = 9999;
    Random r = new Random();
    int raffleNumber = r.Next(min, max);
    string otherGuests = "Y";
    string winner = "no one yet";    

    Console.WriteLine ("Welcome to thye Party!!");

    do
    {
      do //this do...while loop will continue unitl guestName is not empty
      {
        Console.Write("Enter your guest's name: ");
        guestName = Console.ReadLine();
      } while (guestName == "");
      guestName = guestName.ToLower();
      do  //this do...while loop will continue until raffleNumber is not in dict
      {
        raffleNumber = r.Next(min, max);
      } while (guests.ContainsKey(raffleNumber));
      guests.Add(raffleNumber, guestName);    
      //
      Console.WriteLine(raffleNumber +" "+ guestName);
      Console.Write("Are there more guests to add to the raffle? (Y/N): ");
      otherGuests = Console.ReadLine().ToUpper();        
    }
    while (otherGuests != "N");  //min=1000 and max=9999, this loop will break if guests >= 9000
    Console.WriteLine("Here is a list of all our guests and their raffle ticket numbers:");
    foreach (KeyValuePair<int,string> kvp in guests) Console.WriteLine(kvp);
    Console.WriteLine("...and now to randomly select the winner!:");
    do  //this do...while loop will continue until raffleNumber matches a dict key
    {
      raffleNumber = r.Next(min, max);
    } while (!guests.ContainsKey(raffleNumber));
    winner = guests[raffleNumber].ToUpper();
    Console.WriteLine($"Congratulations {winner}!!!"); 
  }
}
*/
//LESSONS LEARNED:
// do not scracifice straightforward easy to follow logic for D.R.Y. lines of code
// it's better to be clear than clever i.e. do not obfusating your programs with fancy code
// if your program's logic is hard to follow, it will be hard to troubleshoot and hard to edit
// do not write a scavenger hunt
// I need A LOT more practice.  Breaking up the program into methods should not have been this hard.