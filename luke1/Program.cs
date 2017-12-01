using System;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace luke1
{
    class Program
    {
        static void Main(string[] args)
        {
            var riddle = "aeteesasrsssstaesersrrsse";
            var canonicalizedRiddle = riddle.Canonicalize();

            using(var httpClient = new HttpClient())
            using(var sr = new StreamReader(httpClient.GetStreamAsync(@"https://s3-eu-west-1.amazonaws.com/julekalender-knowit-2017-vedlegg/wordlist.txt").Result))
            {
                while(!sr.EndOfStream)
                {
                    var suggestion = sr.ReadLine();
                    if(suggestion.Length < 9) continue;
                    if(suggestion.Length > 9) break;

                    if(suggestion.NGram(5).Canonicalize() == canonicalizedRiddle)
                    {
                        // this is a match!!!
                        Console.WriteLine($"{suggestion}\n{suggestion.NGram(5)}\n{riddle}\n");
                    }
                }
            }
        }
    }
}
