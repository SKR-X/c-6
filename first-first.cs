using System;

namespace ConsoleApp1
{
    struct sportsman {
        public string fam;
        public string com;
        public double try1;
        public double try2;
        public double result;
        public sportsman(string famin, string comin, double try1in, double try2in)
        {
            fam = famin;
            com = comin;
            try1 = try1in;
            try2 = try2in;
            result = try1in + try2in;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            sportsman[] sp = new sportsman[3];

            sportsman sp1 = new sportsman("Family1","Team1",0.2,0.12);
            sportsman sp2 = new sportsman("Family2", "Team2", 1.2, 5);
            sportsman sp3 = new sportsman("Family3", "Team3", 1, 2);

            sp[0] = new sportsman("Family1", "Team1", 0.2, 0.12);
            sp[1] = sp2;
            sp[2] = sp3;

            for (int i = 0; i < sp.Length-1; i++)
            {
                for (int j = i; j < sp.Length; j++)
                {
                    if(sp[i].result < sp[j].result)
                    {
                        sportsman temp = sp[i];
                        sp[i] = sp[j];
                        sp[j] = temp;
                    }
                }
            }

            for (int i = 0; i < sp.Length; i++)
            {
                Console.WriteLine($"ФАМИЛИЯ: {sp[i].fam} ОБЩЕСТВО: {sp[i].com} РЕЗУЛЬТАТ_1: {sp[i].try1} РЕЗУЛЬТАТ_2: {sp[i].try2}");
            }
        }
    }
}
