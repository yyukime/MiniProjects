using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;

namespace Rennschnecken;

class Rennschnecke
{
    public string Snail;
    public string Race;
    public int MaxSpeed;
    // die Schnecke soll wissen welche Strecke sie zurückgelegt hat

    public Rennschnecke() // need to call constructor
    {
        Snail = "George";
        Race = "Black";
        MaxSpeed = 10;
        
    }

    void Kriechen()
    {
        Random randomDistance = new();
        int randomDistanceInt = randomDistance.Next(MaxSpeed);
        

    }
    
    public String toString()
    {
        string SnailData = Snail, Race, MaxSpeed;
        return SnailData;
    }
    static void Main(string[] args)
    {
        Rennschnecke Schnecke1 = new Rennschnecke();
        Console.WriteLine($"Snailname: {Schnecke1.Snail}, SnailRace: {Schnecke1.Race}, SnailSpeed: {Schnecke1.MaxSpeed}");
    }

    

}

class Rennen : Rennschnecke
{
    public string NameRennen = "- Rennen der schnellsten Schnecken -";
    public int AmountOfParticipants; // constructor
    ArrayList ParticiPantArray = []; 
    public int DistanceToPass;

     Rennen()
    {
        AmountOfParticipants = 5;
        DistanceToPass = 1500;
        
    }
    

    void addRennschnecken(Rennschnecke Schnecke1)
    {
        ParticiPantArray.Add(Schnecke1); // or like above?
    }

    public string toString()
    {
        string RennenData = NameRennen, AmountOfParticipants, ParticiPantArray, DistanceToPass;
        return RennenData;
    }

   
}








 





