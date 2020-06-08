using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp131
{
    class Program
    {
        struct Student

        {
            public string stud_name;
            public string stud_surname;
            public string stud_patronomic;
            public string stud_rating;
            public string stud_stipend;
        }

        static Student[] ReadData(string file_Name)
        {
            int count = File.ReadAllLines(file_Name).Length;
            Student[] stud = new Student[count];
            string[] readText = File.ReadAllLines(file_Name);
            char[] student;

            int j = 0;
            int c = 0;
        
            foreach (string str in readText)
            {
                student = str.ToCharArray();
                for (int i = 0; i < str.Length; i++)
                {
                    if (student[i] == ' ')
                    {
                        continue;
                    }
                    else
                    {
                        for (; i < student.Length; i++)
                        {
                            if (student[i] == ' ')
                            {
                                break;
                            }
                            if (j == 0)
                            {
                                stud[c].stud_surname += student[i];
                            }
                            else if (j == 1)
                            {
                                stud[c].stud_name += student[i];
                            }
                            else if (j == 2)
                            {
                                stud[c].stud_patronomic += student[i];
                            }
                            else if (j >= 5 && j <= 7)
                            {
                                stud[c].stud_rating += student[i];
                            }
                            else if (j == 8)
                            {
                                stud[c].stud_stipend += student[i];
                            }
                        }
                    }
                    j++;
                }
                j = 0;
                c++;
            }
            return stud;
        }
        static void runMenu(Student[] stud)
        {            
            double count = 0;
            for (int i = 0; i < stud.Length; i++)
            {              
                int sstipend = Convert.ToInt32(stud[i].stud_stipend);
                count = count + sstipend;
            }
            Console.WriteLine("Середня стипендiя:");
            double seredne=count/11;
            Console.WriteLine(seredne);
            Console.WriteLine("");
            Console.WriteLine("Студенти: ");
            for (int j = 0; j < stud.Length; j++)
            {
                int sstipend = Convert.ToInt32(stud[j].stud_stipend);
                if (sstipend!=0 && sstipend < seredne*0.8)
                {
                    Console.WriteLine(stud[j].stud_surname + " " + stud[j].stud_name + " " + stud[j].stud_patronomic + " " + stud[j].stud_stipend);
                }
            }
            }
        static void Main(string[] args)
        {
            string s = @"\";
            Console.WriteLine("Знайти середню величину стипендiї i винести прiзвища, iмена i по батьковi студентiв, чия стипендiя менша середньої бiльш нiж на 20 % (середнє рахувати лише по тим, хто отримує стипендiю; виводити лише тих, хто отримує, але меншу за вказану величину).");
            Console.WriteLine("");
            Console.Write("Введiть шлях до текстового файлу (.txt) який потрібно перевірити (Приклад: C:{0}Database.txt): ", s);
            string way = Convert.ToString(Console.ReadLine());
            Console.WriteLine("");
            Student[] studs = ReadData(@way);
            runMenu(studs);
            Console.ReadKey();
        }
    }
}