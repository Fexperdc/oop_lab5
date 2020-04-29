using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleClassConsole {
    class Company {
        private String name;
        private String position;
        private float salary;

        public Company() {}

        public Company(String name) {
            SetName(name);
        }

        public Company(String name, String position, float salary) {
            SetName(name);
            SetPosition(position);
            SetSalary(salary);
        }

        public Company(Company company) {
            SetName(company.GetName());
            SetPosition(company.GetPosition());
            SetSalary(company.GetSalary());
        }

        public void SetName(String name) {
            this.name = name;
        }

        public String GetName() {
            return name;
        }

        public void SetPosition(String position) {
            this.position = position;
        }

        public String GetPosition() {
            return position;
        }

        public void SetSalary(float salary) {
            this.salary = salary;
        }

        public float GetSalary() {
            return salary;
        }
    }
}
