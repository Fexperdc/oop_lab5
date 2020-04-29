using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleClassConsole {
    class Worker {

        private String name;
        private int year;
        private int month;
        private Company workPlace;

        public Worker() {}

        public Worker(Worker worker) {
            SetName(worker.GetName());
            SetYear(worker.GetYear());
            SetMonth(worker.GetMonth());
            SetWorkPlace(worker.GetWorkPlace());
        }

        public Worker(String name) {
            SetName(name);
        }

        public Worker(String name, int year, int month, Company workPlace) {
            SetName(name);
            SetYear(year);
            SetMonth(month);
            SetWorkPlace(workPlace);
        }

        public int GetWorkExperience() {
            int totalYears = DateTime.Now.Year - year;
            int totalMonths = (totalYears * 12) + DateTime.Now.Month - month;

            return totalMonths;
        }

        public float TotalMoney() {
            if(workPlace != null) {
                return GetWorkExperience() * workPlace.GetSalary();
            }

            return 0;
        }

        public int CompareToSalary(Worker worker, bool smaller) {
            if (smaller) {
                return (int)GetWorkPlace().GetSalary() - (int)worker.GetWorkPlace().GetSalary();
            } else {
                return (int)worker.GetWorkPlace().GetSalary() - (int)GetWorkPlace().GetSalary();
            }
        }

        public int CompareToExp(Worker worker) {
            return GetWorkExperience() - worker.GetWorkExperience();
        }

        public void SetName(String name) {
            this.name = name;
        }

        public String GetName() {
            return name;
        }

        public void SetYear(int year) {
            this.year = year;
        }

        public int GetYear() {
            return year;
        }

        public void SetMonth(int month) {
            this.month = month;
        }

        public int GetMonth() {
            return month;
        }

        public void SetWorkPlace(Company company) {
            workPlace = company;
        }

        public Company GetWorkPlace() {
            return workPlace;
        }
    }
}
