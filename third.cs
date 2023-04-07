//last 
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace _6th_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            FM stream = new FM();
            stream.MakeStats();
        }


        struct QuestionAnswer
        {
            public string Answer;
            public int Count;
        }

        struct FM
        {
            public void MakeStats()
            {

                QuestionAnswer pointAnswer;

                List<QuestionAnswer>[] uniqueLists = new List<QuestionAnswer>[3];
                

                using (FileStream stream = new FileStream("file.txt", FileMode.Open))
                {
                    StreamReader streamReader = new StreamReader(stream);
                    int questionNumber = 1;
                    int c = 0;
                    while (!streamReader.EndOfStream)
                    {
                        string currentLine = streamReader.ReadLine();
                        string[] answers = currentLine.Split(',');

                        List<QuestionAnswer> uniqueList = new List<QuestionAnswer>();
                        int j;

                        for (int i = 0; i < answers.Length; i++)
                        {
                            j = 0;
                            while(j<uniqueList.Count)
                            {
                                if (uniqueList[j].Answer == answers[i])
                                {
                                    pointAnswer = uniqueList[j];
                                    pointAnswer.Count++;

                                    uniqueList[j] = pointAnswer;
                                    break;
                                }
                                j++;
                            }
                            if (j == uniqueList.Count)
                                uniqueList.Add(new QuestionAnswer { Answer = answers[i], Count = 1 });
                        }

                        int maxIndex = 0;
                        int startIndex = 0;
                        for (int i = 0; i < 5; i++)
                        {
                            for (j = startIndex + 1; j < uniqueList.Count; j++)
                            {
                                if (uniqueList[j].Count > uniqueList[maxIndex].Count)
                                    maxIndex = j;
                            }
                            pointAnswer = uniqueList[startIndex];
                            uniqueList[startIndex] = uniqueList[maxIndex];
                            uniqueList[maxIndex] = pointAnswer;

                            
                            startIndex++;
                            maxIndex = startIndex;
                        }

                        uniqueLists[c] = uniqueList;
                        c++;

                        questionNumber++;
                    }

                }


                for (int i = 0; i < uniqueLists.Length; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        pointAnswer = uniqueLists[i][j];
                        Console.Write($"{pointAnswer.Answer} ({Math.Round(pointAnswer.Count * 100d / uniqueLists[i].Count, 1)}%)");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
