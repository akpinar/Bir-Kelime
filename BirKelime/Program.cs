using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Bir_kelime_proje_ödevi
{
    class Program
    {
        public static List<string> read_file(List<string> word_list)
        {
            string file_path = @"C:\Users\sena\OneDrive\Masaüstü\Sozluk\sozluk.txt";
            FileStream fs = new FileStream(file_path, FileMode.Open, FileAccess.Read);
            StreamReader sw = new StreamReader(fs);

            string word = sw.ReadLine();           
            while (word != null)         
            {
                word_list.Add(word);          
                word = sw.ReadLine();
            }
            sw.Close();
            fs.Close();

            return word_list;
        }

        public static List<char> getLetters(List<char> character)
        {
            Random rnd = new Random();
            char[] alphabet = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'i', 'ı', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };          
            int random_number;

            while (true)           
            {
                Console.WriteLine("Harfler random atılsın mı?(e/h)");
                char c = Convert.ToChar(Console.ReadLine());
                if (c == 'e')         
                {
                    for (int j = 0; j < 8; j++)
                    {
                        random_number = rnd.Next(0, 29);          
                        character.Add(alphabet[random_number]);            //Alınan rastgele sayı ile dizinin o indexteki elemanını karakter isimli listeye ekliyor.
                    }
                    break;
                }
                if (c == 'h')         
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("{0}. harfi giriniz=", i + 1);
                        character.Add(Convert.ToChar(Console.ReadLine()));
                    }
                    break;
                }
                else           
                {
                    Console.WriteLine("Hatalı GİRİŞ!!");
                }
            }

            for (int k = 0; k < 8; k++)         
            {
                Console.Write(character[k] + " ");
            }
            Console.WriteLine();

            return character;
        }

        public static bool control(List<char> character, string item, List<char> count, bool bool_control)
        {
            List<char> read_word_letter = new List<char>(item.ToCharArray());         
            for (int i = 7; i >= 0; i--)
            {
                for (int j = read_word_letter.Count - 1; j >= 0; j--)
                {
                    int control_letter = string.Compare(Convert.ToString(character[i]), Convert.ToString(read_word_letter[j]));        
                    if (control_letter == 0)         
                    {
                        read_word_letter.Remove(read_word_letter[j]);
                        count.Add('*');
                        break;
                    }
                }
            }
            if (item.Length == count.Count || item.Length == count.Count + 1)          
            {
                Console.WriteLine(item);
                bool_control = true;
            }
            count.Clear();
            return bool_control;
        }

        public static int Point(string item, int point)
        {
            switch (item.Length)            //item isimli değişkenin içerisindeki kelimenin uzunluğuna göre puanı belirliyor.
            {
                case 9:
                    point = 15;
                    break;

                case 8:
                    point = 11;
                    break;

                case 7:
                    point = 9;
                    break;

                case 6:
                    point = 7;
                    break;

                case 5:
                    point = 5;
                    break;

                case 4:
                    point = 4;
                    break;

                case 3:
                    point = 3;
                    break;
            }
            return point;
        }

        static void Main(string[] args)
        {
            List<string> word_list = new List<string>();
            List<char> character = new List<char>();
            List<char> count = new List<char>();
            bool bool_control = false;
            int point = 0;
            //Gerekli değişkenler oluşturuldu.

            read_file(word_list);
            getLetters(character);

            for (int n = 9; n >= 3; n--)           
            {
                foreach (string item in word_list)        
                {
                    if (item.Length == n)          
                    {
                        bool_control = control(character, item, count, bool_control);
                    }
                    if (bool_control)           
                    {
                        point = Point(item, point);
                        break;
                    }
                }
                if (bool_control)           
                    break;
            }
            Console.WriteLine("Puanınız= {0}", point);
            Console.ReadLine();
        }
    }
}