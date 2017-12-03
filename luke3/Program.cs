using System;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;

namespace luke3
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "/Users/arjan/Downloads/forslag-til-bilde+-+Henrik+Nårstad.png";

            var img = Image.Load(filename);
            var bytes = img.SavePixelData();
            var redBytes = new byte[bytes.Length/4];
            for (int i = 0; i < redBytes.Length; i++)
            {
                redBytes[i] = bytes[i*4];
            }

            var lsbBytes = new byte[redBytes.Length/8];
            for (int i = 0; i < lsbBytes.Length; i++)
            {
                byte t = 0;
                for (int j = 0; j < 8; j++)
                {
                    t |= (byte)((redBytes[i * 8 + j] & 1) << j);
                }
                lsbBytes[i] = t;
            }

            using(var stream = new MemoryStream(lsbBytes))
            using(var sr = new StreamReader(stream))
            {
                System.Console.WriteLine(sr.ReadLine());
            }

            Console.WriteLine("\nDone!");
        }
    }
}
