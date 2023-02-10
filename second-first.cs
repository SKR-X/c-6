using System;

namespace ConsoleApp1
{
    struct student
    {
        public string fam;
        public int[] marks;
        public double result;
        public student(string famin, int[] markin)
        {
            fam = famin;
            marks = markin;
            int all = 0;
            for (int i = 0; i < marks.Length; i++)
            {
                all += marks[i];
            }
            result = (double)all / marks.Length;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            student[] sp = new student[3];

            sp[0] = new student("Family1", new int[] { 5, 5, 5, 5 });
            sp[1] = new student("Family2", new int[] { 4, 4, 4, 4 });
            sp[2] = new student("Family3", new int[] { 3, 3, 3, 3 });

            for (int i = 0; i < sp.Length - 1; i++)
            {
                for (int j = i; j < sp.Length; j++)
                {
                    if (sp[i].result < sp[j].result)
                    {
                        student temp = sp[i];
                        sp[i] = sp[j];
                        sp[j] = temp;
                    }
                }
            }

            for (int i = 0; i < sp.Length; i++)
            {
                Console.WriteLine($"ФАМИЛИЯ: {sp[i].fam} РЕЗУЛЬТАТ: {sp[i].result}");
            }
        }
    }
}
