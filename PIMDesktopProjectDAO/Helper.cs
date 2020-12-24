using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDAO
{
    public class Helper
    {
        /*
         HELPER CODE
         */
        public static string Code(int char_count)
        {
            string code = "";
            Random rdn = new Random();
            HashSet<string> text = new HashSet<string>();

            var list = new RandomSequence[]
            {
                new RandomSequence("abcdefghijklmnopqrstuvxywz"),
                new RandomSequence("ABCDEFGHIJKLMNOPQRSTUVXYWZ"),
                new RandomSequence("0123456789")
            };

            //while (true)
            //{
            //    for (int l = 0; l < 10; l++)
            //    {
            //        code += list[rdn.Next(0, list.Length)].SelectOne();
            //    }
            //    if (text.Contains(code))
            //    {
            //        Console.WriteLine("Contain");
            //        break;
            //    }
            //    text.Add(code);
            //    Console.WriteLine($"{code} / {count++}");
            //    code = "";
            //    //Console.ReadKey();
            //}

            for (int l = 0; l < char_count; l++)
            {
                code += list[rdn.Next(0, list.Length)].SelectOne();
            }

            return code;
        }

        public class RandomSequence
        {
            private string Sequence { get; set; }
            readonly Random Rdn = new Random();
            public RandomSequence(string value)
            {
                Sequence = value;
            }

            public char SelectOne()
            {
                return Sequence[Rdn.Next(0, Sequence.Length)];
            }
        }
    }
}
