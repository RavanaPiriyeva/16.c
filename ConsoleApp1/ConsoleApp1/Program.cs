using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            

            List<Student> students = new List<Student>();
            string strNo;
            string answer = "";
            string fullname = "";
            bool check = true;
            int no;
            string examName = "";
            string strPoint = "";
            int examPoint;
           

            while (check)
            {

               
                Console.WriteLine("\n1.Telebe elave et\n" +
                    "2.Telebeye imtahan elave et\n" +
                    "3.Telebenin bir imtahan balına bax\n" +
                   "4.Telebenin bütün imtahanlarını göster\n" +
                   "5.Telebenin imtahan ortalamasını göster\n" +
                   "6.Telebeden imtahan sil\n0.Proqramı bitir\n");
               

                answer = Console.ReadLine();
                switch (answer)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("Ad ve soyad daxil et");
                            fullname = Console.ReadLine();
                        }
                        while (String.IsNullOrWhiteSpace(fullname) || !CheckWorsdAndLetters(fullname));
                        Student student = new Student();
                        student.FullName = fullname;
                        students.Add(student);

                        break;

                    case "2":
                        int count2 = 0;
                        bool check1 = true;
                        do
                        {
                            Console.WriteLine("Telbenin nomresini daxil edin");
                            strNo = Console.ReadLine();
                        }
                        while (!int.TryParse(strNo, out no));
                        do
                        {
                            Console.WriteLine("Telebe ucun imtahan adini daxil edin: ");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));

                        do
                        {

                            if (check1) {
                                Console.WriteLine("Telebenin imtahan balini daxil edin: ");
                                check1 = false;
                            }
                            else
                            {
                                
                                Console.WriteLine("Telebenin balini duzgun daxil eidn!!!!!");
                               
                            }
                            strPoint = Console.ReadLine();
                        } while (!int.TryParse(strPoint, out examPoint) || examPoint > 100 || examPoint < 0);
                      
                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                item.AddExam(examName, examPoint);
                            }
                            else
                            {
                                count2++;
                            }
                        }
                        if (count2 == students.Count)
                        {
                            Console.WriteLine("Bu nomreli telebe yoxdur!!!!");
                        }

                        break;
                    case "3":
                        int count3 = 0;
                        do
                        {
                            Console.WriteLine("Telbenin nomresini daxil edin");
                            strNo = Console.ReadLine();
                        }
                        while (!int.TryParse(strNo, out no));
                        do
                        {
                            Console.WriteLine("Telebe ucun imtahan adini daxil edin: ");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));
                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine(item.GetExamResult(examName));
                            }
                            else
                            {
                                count3++;
                            }
                        }
                        if (count3 == students.Count)
                        {
                            Console.WriteLine("Bu nomreli telebe yoxdur!!!!");
                        }

                        break;
                    case "4":
                        do
                        {
                            Console.WriteLine("Telbenin nomresini daxil edin");
                            strNo = Console.ReadLine();
                        }
                        while (!int.TryParse(strNo, out no));
                        int count4 = 0;
                        foreach (var item in students)
                        {
                            if (item.No == no)
                                foreach (var exam in item.Exams)
                                {
                                    Console.WriteLine(exam.Key + "      " + exam.Value);
                                }
                            else
                            {
                                count4++;
                            }

                        }
                        if (count4 == students.Count)
                        {
                            Console.WriteLine("Bu nomreli telebe yoxdur!!!!");
                        }


                        break;
                    case "5":
                        int count5 = 0;
                        do
                        {
                            Console.WriteLine("Telbenin nomresini daxil edin");
                            strNo = Console.ReadLine();
                        }
                        while (!int.TryParse(strNo, out no));
                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                Console.WriteLine(item.GetExamAvg());
                            }
                            else
                            {
                                count5++;
                            }

                        }
                        if (count5 == students.Count)
                        {
                            Console.WriteLine("Bu nomreli telebe yoxdur!!!!");
                        }

                        break;
                    case "6":
                        {
                            Console.WriteLine("Telbenin nomresini daxil edin");
                            strNo = Console.ReadLine();
                        }
                        while (!int.TryParse(strNo, out no)) ;
                        do
                        {
                            Console.WriteLine("Telebe ucun imtahan adini daxil edin: ");
                            examName = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(examName));
                        int count6 = 0;
                        foreach (var item in students)
                        {
                            if (item.No == no)
                            {
                                item.Exams.Remove(examName);

                            }
                           
                            
                            else
                            {
                                count6++;
                               
                            }
                        }
                        if(count6 == students.Count)
                        {
                            Console.WriteLine("Bu nomreli telebe yoxdur!!!!");
                        }

                        break;
                    case "0":
                        return;
                        break;
                    default:
                        Console.WriteLine("Duzun secim daxil edin!!!!!");
                        break;


                }
               
               
            }
            Console.ReadKey();
        }

        static bool CheckWorsdAndLetters(string str)
            {
            int count = 3;
                string[] str2 = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (str2.Length == 2)
                {

                    if (char.IsUpper(str2[0][0]) && char.IsUpper(str2[1][0]))
                    {
                    foreach(var item in str2)
                    {
                        for (int i = 1; i < item.Length; i++)
                        {
                            if (char.IsLower(item[i]))
                            {
                                count++;
                            }
                        }
                    }
                    if(count == str.Length)
                    {
                        return true;
                    }
                       

                    }
                    else
                    {
                        return false;
                    }
                }
            return false;

            }


            //Student student1 = new Student();
            //Student student2 = new Student();
            //Student student3 = new Student();
            //Student student4 = new Student();
            //students.Add(student1);
            //students.Add(student2);
            //students.Add(student3);
            //students.Add(student4);
            //student1.AddExam("riyziuyat", 50);
            //student1.AddExam("tarix", 50);
            //student1.AddExam("AZ DILI", 50);
            //foreach (var item in student2.Exams)
            //{
            //    Console.WriteLine(item);
            //}

        
    }
}
