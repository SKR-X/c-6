using System;

namespace ConsoleApp1
{
    struct sportsman
    {
        public string fam;
        public string famprep;
        public string com;
        public double try1;
        public double result;
        static int amount;
        public sportsman(string famin, string comin, string famprepin, double try1in)
        {
            fam = famin;
            com = comin;
            try1 = try1in;
            famprep = famprepin;
            result = try1in;
            sportsman.count();
        }

        public static int count()
        {
            return amount++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            sportsman[] sp = new sportsman[3];

            sportsman sp1 = new sportsman("Family1", "Team1", "prep1", 0.12);
            sportsman sp2 = new sportsman("Family2", "Team2", "prep2", 5);
            sportsman sp3 = new sportsman("Family3", "Team3", "prep3", 2);
            Console.WriteLine($"ВСЕГО: {sportsman.count()}");

            sp[0] = sp1;
            sp[1] = sp2;
            sp[2] = sp3;

            for (int i = 0; i < sp.Length - 1; i++)
            {
                for (int j = i; j < sp.Length; j++)
                {
                    if (sp[i].result < sp[j].result)
                    {
                        sportsman temp = sp[i];
                        sp[i] = sp[j];
                        sp[j] = temp;
                    }
                }
            }

            for (int i = 0; i < sp.Length; i++)
            {
                Console.WriteLine($"ФАМИЛИЯ: {sp[i].fam} ОБЩЕСТВО: {sp[i].com} РЕЗУЛЬТАТ: {sp[i].try1} ПРЕПОДАВАТЕЛЬ: {sp[i].famprep} ИНФОРМАЦИЯ:" + (sp[i].result>=2 ? "Выполнил." : "Не выполнил."));
            }
        }
    }
}
