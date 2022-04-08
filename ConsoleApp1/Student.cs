using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        public int No { get; set; }
        public string FullName { get; set; }
        public Dictionary<string, double> Exams = new Dictionary<string, double>();
        List<Student> Students = new List<Student>();
        public void AddExam(string examName, int point)
        {
            if (!string.IsNullOrEmpty(examName))
            {
                Exams.Add(examName, point);
            }
            else
            {
                throw new Exception("examName -null olmasin");
            }

        }
        public double GetExamResult(string examName)
        {
            if (!string.IsNullOrEmpty(examName))
            {
                if (Exams.ContainsKey(examName))
                {
                    return Exams[examName];
                }
                throw new Exception("imtahan legv olunub");
            }
            else
            {
                throw new Exception("name null ola bilmez");
            }
        }
        public double GetExamAvg()
        {
            double sum = 0;
            foreach (var item in Exams)
            {
               sum += item.Value;
            }
             return sum / Exams.Count;
        }
    }
}

