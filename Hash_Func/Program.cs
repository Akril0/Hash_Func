using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Hash_Func
{
    class Program
    {
        const string PATH1 = @"../../../hashREsult.txt";
        const string PATH2 = @"../../../MD5Hash.txt";
        static byte[] key = Encoding.Default.GetBytes("ByteHash");
        public static string hash(byte[] input)
        {
            StringBuilder sb = new StringBuilder();
            for (int i=0; i < input.Length; i++)
            {
                sb.Append((char)(input[i] ^ key[i % key.Length]));
            }
            return sb.ToString();
        }
        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
{
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Which hash: \n" +
                    "1-Xor\n" +
                    "2-MD5");
                int action = Int32.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Input Password: ");
                            string inputPass = Console.ReadLine();

                            string cipher = hash(Encoding.Default.GetBytes(inputPass));
                            using (StreamWriter fstream = new StreamWriter(PATH1, true))
                            {
                                fstream.WriteLine(inputPass+" : "+ cipher);
                                Console.WriteLine("Текст записан в файл");
                                fstream.Close();
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Input Password: ");
                            string inputPass = Console.ReadLine();

                            string cipher = CalculateMD5Hash(inputPass);
                            using (StreamWriter fstream = new StreamWriter(PATH2, true))
                            {
                                fstream.WriteLine(inputPass + " : " + cipher);
                                Console.WriteLine("Текст записан в файл");
                                fstream.Close();
                            }
                            break;
                        }
                }

            }
      
        }
    }
}
