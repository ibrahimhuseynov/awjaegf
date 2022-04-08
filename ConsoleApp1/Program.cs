using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            bool isActive = true;
            while (isActive)
            {
                Console.WriteLine("Menu :");
                Console.WriteLine("1. Tələbə əlavə et");
                Console.WriteLine("2. Tələbəyə imtahan əlavə et");
                Console.WriteLine("3. Tələbənin bir imtahan balına bax");
                Console.WriteLine("4. Tələbənin bütün imtahanlarını göstər");
                Console.WriteLine("5. Tələbənin imtahan ortalamasını göstər");
                Console.WriteLine("6. Tələbədən imtahan sil");
                Console.WriteLine("0.Proqramı bitir");
                string search = Console.ReadLine();
                Student searchStudent;
                string examName;
                int no;
                switch (search)
                {
                    case "1":
                        Console.WriteLine("Name :");
                        string fullName = Console.ReadLine();
                        Student student1 = new Student()
                        {
                            FullName = fullName,
                        };
                        students.Add(student1);
                        break;
                    case "2":
                        no = enterint("No :","reqem dail edin");
                        examName = StringInput("Exams Name :");
                        double point = enterdouble("Point :","reqem daxil edin");
                        searchStudent = students.Find(std => std.No == no);
                        if (searchStudent != null)
                            searchStudent.AddExam(examName);
                        break;
                    case "3":
                        no = enterint("Student Nomresini Daxil Edin :", "Student Nomresinni Duzgun Daxil Edin :");
                        examName = StringInput("Exam Name :");
                        searchStudent = students.Find(std => std.No == no);
                        if (searchStudent != null)
                        {
                            Console.WriteLine($"{no} - telebenin {examName} -adli imtahan neticesi :");
                            Console.WriteLine(searchStudent.GetExamResult(examName));
                        }

                        break;
                    case "4":
                        no = enterint("Student Nomresini Daxil Edin :", "Student Nomresini Duzgun Daxil Edin :");
                        searchStudent = students.Find(std => std.No == no);
                        if (searchStudent != null)
                        {
                            Console.WriteLine($"{no} -exsams and exsams ballari:");
                            foreach (var item in searchStudent.Exams)
                            {
                                Console.WriteLine(item.Key + " ----- " + item.Value);
                            }
                        }

                        break;
                    case "5":
                        no = enterint("Student No Daxil Edin :", "Student No Duzgun Daxil Edin :");
                        searchStudent = students.Find(std => std.No == no);
                        if (searchStudent != null)
                        {
                            Console.WriteLine($"{no} -nomreli telebenin imtahanlardan ortalama bali :");
                            Console.WriteLine(searchStudent.GetExamAvg());
                        }

                        break;
                    case "6":
                        no = enterint("No :", "reqem daxil edin :");
                        examName = StringInput("Exam Name :");
                        searchStudent = students.Find(std => std.No == no);
                        if (searchStudent != null)
                        {
                            if (searchStudent.Exams.ContainsKey(examName))
                            {
                                searchStudent.Exams.Remove(examName);
                                Console.WriteLine(no+"       "+examName);
                            }
                        }

                        break;
                    case "0":
                        isActive = false;
                        break;
                    default:
                        Console.WriteLine("dont corrrect");
                        break;
                }
            }
        }
        static int enterint(string txt1, string txt2)
        {
            Console.WriteLine(txt1);
            string entertxt = Console.ReadLine();
            int enter;
           
            while (!int.TryParse(entertxt, out enter))
            {
                Console.WriteLine(txt2);
                entertxt = Console.ReadLine();
            }
            int.TryParse(entertxt, out enter);
            return enter;
        }
        static double enterdouble(string txt1, string txt2)
        {
            Console.WriteLine(txt1);
            string entertxt = Console.ReadLine();
            double enterdouble;
            while (!double.TryParse(entertxt, out enterdouble))
            {
                Console.WriteLine(txt2);
                entertxt = Console.ReadLine();
            }
            double.TryParse(entertxt, out enterdouble);
            return enterdouble;
        }
        static string StringInput(string message)
        {
            Console.WriteLine(message);
            string inputStr = Console.ReadLine();
            return inputStr;
        }
    }
}
