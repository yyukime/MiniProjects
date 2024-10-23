using System;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Bank;


namespace BankUI;

public class Program
{

    public static void Main()
    {
        User? activeUser = Authentication.Authenticate();
        if (activeUser == null) return;



    }








}
