using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace SimpleClassConsole {
    class Program {

        public static Worker[] global_workers;

        static void Main(string[] args) {
            pseudo_cmd_realize(Console.ReadLine());
        }

        public static void pseudo_cmd_realize(String cmd) {
            try {
                switch (cmd) {
                    case "gw_c":
                        int size = 0;
                        size = int.Parse(Console.ReadLine());
                        Console.WriteLine("Global workers created");
                        global_workers = new Worker[size];
                        break;
                    case "print_workers":
                        PrintWorkers(global_workers);
                        break;
                    case "gw_i":
                        Console.WriteLine("Length: " + global_workers.Length);
                        break;
                    case "create_workers":
                        global_workers = ReadWorkersArray();
                        break;
                    case "sort_exp":
                        SortWorkerByWorkExperience(global_workers);
                        break;
                    case "workers_info":
                        Worker bigger;
                        Worker smaller;
                        GetWorkersInfo(global_workers, out bigger, out smaller);
                        WriteDefault("Bigger salary worker: ");
                        PrintWorker(bigger);
                        WriteDefault("Smaller salary worker: ");
                        PrintWorker(smaller);
                        break;
                    case "sort_salary":
                        SortWorkerBySalary(global_workers);
                        break;
                }
            }catch(Exception) {
                WriteError("ERROR!");
            }
            pseudo_cmd_realize(Console.ReadLine());
        }

        public static Worker[] ReadWorkersArray() {
            int n = ConsoleGetInt("Enter worker count: ");
            int count = 0;
            Worker[] workers = new Worker[n];

            String name;
            int year = -1;
            int month = -1;

            
            while(count < n) {
                String companyName;
                String position;
                float salary;
                name = ConsoleGetLine("Enter Worker name: ");
                year = ConsoleGetInt("Enter Worker year: ");
                month = ConsoleGetInt("Enter Worker month: ");

                companyName = ConsoleGetLine("Enter Company name: ");
                position = ConsoleGetLine("Enter position: ");
                salary = ConsoleGetFloat("Enter salary: ");
                workers[count] = new Worker(name, year, month, new Company(companyName, position, salary));
                count++;
            }

            return workers;
        }

        public static void WriteError(String msg) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void WriteDefault(String msg) {
            if(!msg.Equals(""))
                Console.WriteLine(msg);
        }

        public static int ConsoleGetInt(String msg) {
            int value = 0;
            while(true)
                try {
                    value = int.Parse(ConsoleGetLine(msg));
                    break;
                }catch(Exception) {
                    WriteError("TRY AGAIN");
                }

            return value;
        }

        public static float ConsoleGetFloat(String msg) {
            float value = 0;
            while(true)
                try {
                    value = float.Parse(ConsoleGetLine(msg));
                    break;
                } catch (Exception) {
                    WriteError("TRY AGAIN");
                }

            return value;
        }

        public static String ConsoleGetLine(String msg) {
            if (!msg.Equals(""))
                Console.WriteLine(msg);

            return Console.ReadLine();
        }

        public static void PrintWorker(Worker worker) {
            Console.WriteLine("Name: " + worker.GetName() + "Year: "+ worker.GetYear() + "Month: " + worker.GetMonth());
        }

        public static void PrintWorkers(Worker[] workers) {
            foreach(Worker worker in workers) {
                PrintWorker(worker);
            }
        }

        public static void GetWorkersInfo(Worker[] workers, out Worker biggerSalary, out Worker smallerSalary) {
            Array.Sort(workers, new SalaryCompare(false));
            biggerSalary = workers[0];

            Array.Sort(workers, new SalaryCompare(true));
            smallerSalary = workers[0];
        }

        public static void SortWorkerBySalary(Worker[] workers) {
            Array.Sort(workers, new SalaryCompare(false));
        }

        public static void SortWorkerByWorkExperience(Worker[] workers) {
            Array.Sort(workers, new ExpCompare());
        }

        public class SalaryCompare : IComparer<Worker> {

            bool smaller = true;

            public SalaryCompare(bool smaller) {
                this.smaller = smaller;
            }

            public int Compare([AllowNull] Worker x, [AllowNull] Worker y) {
                return x.CompareToSalary(y, smaller);
                throw new NotImplementedException();
            }
        }

        public class ExpCompare : IComparer<Worker> {

            public int Compare([AllowNull] Worker x, [AllowNull] Worker y) {
                return x.CompareToExp(y);
                throw new NotImplementedException();
            }
        }
    }
}
