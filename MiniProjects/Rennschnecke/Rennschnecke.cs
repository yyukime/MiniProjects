using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Security.Cryptography;
using Microsoft.VisualBasic.FileIO;
using System.Xml.Schema;

namespace Rennschnecken;

class Rennschnecke
{
    string Name;
    string Race;
    int MaxSpeed;
    int DistancePassed;

    Rennschnecke(string ConName, string ConRace, int ConMaxSpeed, int ConDistancePassed)
    {
        Name = ConName;
        Race = ConRace;
        MaxSpeed = ConMaxSpeed;
        DistancePassed = ConDistancePassed;
    }

    int krieche(int speed) // maybe use void method 
    {
        Random random = new();
        int kriecheInt = random.Next(speed);
        return kriecheInt;

    }

    public override string ToString()
    {
        
         return $"Name: {Name}, Race: {Race}, Snail max-speed: {MaxSpeed}, Total distance passed: {DistancePassed}";
    }

    static void Main(string[] args)
    {
        Rennschnecke Schnecke1 = new("Jeremy", "Nacktschnecke", 200, 0);
        Console.WriteLine(Schnecke1.ToString());
    }
}

class Rennen
{
    string NameOfRace;
    int AmountOfParticipants = 3;
    List<Rennschnecke> Participants;
    int DistanceToRace;

    bool AddSchnecke(Rennschnecke SchneckeToAdd)
    {
        if (Participants.Contains(SchneckeToAdd)) return false;
        Participants.Add(SchneckeToAdd);
        return true;
    }

    
}











