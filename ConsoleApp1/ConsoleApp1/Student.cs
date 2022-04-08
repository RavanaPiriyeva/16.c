using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Student
    {
        public Student()
        {
            _no++;
            No = _no;
        }
        static int _no;
        public int No { get; }
        public string FullName;
        public Dictionary<string, int> Exams = new Dictionary<string, int>();
        public void AddExam(string name , int point)
        {
            Exams.Add(name, point);
        }

        public int GetExamResult(string examName)
        {
            int count = 0;  
            foreach (var exam in Exams)
            {
                if (exam.Key == examName)
                {
                    return exam.Value;
                }
                else
                {
                    count++;
                }
            }
            if (count == Exams.Count)
            {
                Console.WriteLine("Bu adda ders yoxdur!!!");
            }
            return 0;
        }
        public double GetExamAvg()
        {
            double sum = 0;
            int count = 0;
            foreach(var exam in Exams)
            {
                sum+=exam.Value;
                count++;
            }
            double avg = sum / count;
            return avg;

        }
 //        - GetExamResult() - examName dəyəri qəbul edib həmin exam-in balını qaytarır
 //- GetExamAvg() - tələbənin bütün imtahanlarının ortalamasını qaytarır

    }
}
