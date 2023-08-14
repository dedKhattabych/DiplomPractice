using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Diagnostics;

namespace DiplomPractice
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                StartEncode();
            }
            if (args.Length > 0)
            {
                StartDecode(args);
            }
        }

        public static void StartEncode()
        {
            var value = string.Empty;
            while (value.Length < 2)
            {
                Console.WriteLine("Enter the text you want to encode...");
                value = Console.ReadLine();
            }
            HuffmanTree tree = new HuffmanTree();
            var result = tree.HuffmanCodeEncode(value);

            string path = "Encode Message.txt";

            if (File.Exists(path)) File.Delete(path);
            File.AppendAllText(path, result);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "notepad.exe";
            startInfo.Arguments = path;
            Process.Start(startInfo);
        }

        public static void StartDecode(string[] args)
        {
            try
            {
                var value = File.ReadAllText(args.FirstOrDefault());

                HuffmanTree tree = new HuffmanTree();
                var result = tree.HuffmanCodeDecode(value);
                Console.WriteLine(result);
                string path = "Decode Message.txt";

                if (File.Exists(path)) File.Delete(path);
                File.AppendAllText(path, result);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "notepad.exe";
                startInfo.Arguments = path;
                Process.Start(startInfo);

                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.Read();
                throw;
            }

        }
    }
}
