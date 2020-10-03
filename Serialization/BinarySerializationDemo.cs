using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    [Serializable]
    class Student
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int RollNo { get; set; }
        public override string ToString()
        {
            return string.Format($"Name: {Name}\nAddress: {Address}\nRoll No: {RollNo}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Serialize or Deserialize? (s/d): ");
            string choice = Console.ReadLine();
            if (choice == "s")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Student s = new Student { Name = "Shruti", Address = "Kolkata", RollNo = 162 };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Student s = bf.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            Console.WriteLine(s.Address);
            Console.WriteLine(s.RollNo);
            fs.Close();
        }
    }
}
