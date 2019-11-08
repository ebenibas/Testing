using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTestQuiz
{
    public interface IDataAccess
    {
        string GetEmplyeeSalary(int id);
        string GetTopThreeSalaries(int id);

    }
    public class DataAccess : IDataAccess
    {
        TestEntities db = new TestEntities();

        public string GetEmployeeSalary(int id)
        {
            var employee = db.Employees.Find(id);
            return employee.Salary.ToString();
        }

        public string GetEmplyeeSalary(int id)
        {
            throw new NotImplementedException();
        }

        public string GetTopThreeSalaries(int id)
        {
            throw new NotImplementedException();
        }



        public string GetTopThreeSalaries()

        {
            var employee = db.Employees.ToList();
            var em = employee.OrderByDescending(i => i.Salary).Take(3);
                return em.ToString();
        }
    }
    public class MoviesBusinessLogic
    {
        IDataAccess dta;
        public MoviesBusinessLogic(IDataAccess dta)
        {
            this.dta = dta;
        }
        public string GetEmployeeSalary(int id)
        {
            return dta.GetEmplyeeSalary(id);
        }

        public double AnnualBonus(int id)
        {
            var salary = dta.GetEmplyeeSalary(id);
            var bonus = Convert.ToDouble(1 / 100) ;
            double bonussalry = Convert.ToDouble(salary) + bonus;
            return bonussalry;
        }
        public string TopThreeEmployeeWithSalary(int Id)
        {
            return dta.GetTopThreeSalaries(Id);
        }
        public string AllInfo(int id)
        {
            var result = String.Format("The employees  with salaries {0}, with annual bonuses {1},with topthree employees salaries{2}"
                , GetEmployeeSalary(id), AnnualBonus(id), TopThreeEmployeeWithSalary(id));
            return result;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
       
        }
    }
}
