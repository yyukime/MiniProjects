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

    public Rennschnecke(int maxSpeed, string snail, string race)// need to call constructor
    {
        Snail = snail;
        Race = race;
        MaxSpeed = maxSpeed;
        
    }

    void Kriechen()
    {
        Random randomDistance = new();
        int randomDistanceInt = randomDistance.Next(MaxSpeed);       

    }
    
    public override string ToString()
    {
        string SnailData = ($"Snailname: {Snail}, SnailRace: {Race}, SnailSpeed: {MaxSpeed}");
        return SnailData;
    }
    
    static void Main(string[] args)
    {
        Rennschnecke Schnecke1 = new Rennschnecke(10, "george", "nacktschnecke");
        Console.WriteLine();
        Console.WriteLine(Schnecke1);
    }
}

















