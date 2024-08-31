
//logic:
// generate a number 
// turn user input into int
// check if input matches pre generated number

//program:
// provide basic text and request user input
// output result 
// maybe add a "play again?" button

using System.Security.Cryptography;


int[] RNGNumberRange = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, };

Random rng = new();
rng.Next(10);
Console.WriteLine(rng.Next());
