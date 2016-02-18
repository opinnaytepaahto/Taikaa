using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taikaa
{
    class Program
    {
        private static string taikaa = "taika on tosi kivaa";

        static void Main(string[] args)
        {
            Byte[] bytes = GetBytes(taikaa);
            int[] ints = bytes.Select(x => (int)x).ToArray();

            Console.WriteLine("Before encrypting: ");
            foreach (int i in ints)
            {
                Console.Write(i);
            }
            Console.WriteLine("");

            List<int> finalInts = new List<int>();

            foreach (int i in ints)
            {
                int newInt = i << 129837;
                finalInts.Add(newInt);
            }

            Console.WriteLine("After encrypting: ");
            foreach (int i in finalInts)
            {
                Console.Write(i);
            }
            Console.WriteLine("");

            List<int> decrypted = new List<int>();

            foreach (int i in finalInts)
            {
                int newInt = i >> 129837;
                decrypted.Add(newInt);
            }

            Console.WriteLine("After decrypting: ");
            foreach (int i in decrypted)
            {
                Console.Write(i);
            }
            Console.WriteLine("");

            byte[] result = new byte[decrypted.ToArray().Length * sizeof(int)];
            Buffer.BlockCopy(decrypted.ToArray(), 0, result, 0, result.Length);

            string seppo = GetString(result);

            Console.WriteLine("Final string: " + seppo);

            Console.ReadLine();
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
