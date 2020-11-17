﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM_Demo.Models
{
    public class EmployeeService
    {
        private static List<EmployeeDTO> ObjEmployeesList;

        public EmployeeService()
        {
            ObjEmployeesList = new List<EmployeeDTO>()
            {
                new EmployeeDTO { Id=1, Name="John", Age=25},
                new EmployeeDTO { Id=2, Name="Marry", Age=24},
                new EmployeeDTO { Id=3, Name="Tom", Age=23}
            };
        }

        public List<EmployeeDTO> GetAll()
        {
            return ObjEmployeesList;
        }

        public bool Add(EmployeeDTO objNewEmployee)
        {
            if (objNewEmployee.Age < 21 || objNewEmployee.Age > 58)
                throw new ArgumentException("Invalid age limit for employee");

            ObjEmployeesList.Add(objNewEmployee);
            return true;
        }

        public bool Update(EmployeeDTO objEmployeeToUpdate)
        {
            bool isUpdated = false;

            foreach (var employee in ObjEmployeesList)
            {
                if (employee.Id == objEmployeeToUpdate.Id)
                {
                    employee.Name = objEmployeeToUpdate.Name;
                    employee.Age = objEmployeeToUpdate.Age;
                    isUpdated = true;
                    break;
                }
            }

            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;

            var employeeToDelete = ObjEmployeesList.FirstOrDefault(e => e.Id == id);

            if (employeeToDelete != null)
            {
                ObjEmployeesList.Remove(employeeToDelete);
                isDeleted = true;
            }

            return isDeleted;
        }

        public EmployeeDTO Search(int id)
        {
            return ObjEmployeesList.FirstOrDefault(e => e.Id == id);
        }
    }
}
