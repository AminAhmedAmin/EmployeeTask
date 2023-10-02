using AutoMapper;
using employeeTask.DTO;
using employeeTask.Models;
using employeeTask.Services.Contract;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Schema;

namespace employeeTask.Services.implementation
{
    public class Employeeservice : IEmployeeservice
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public Employeeservice(AppDbContext context ,IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }



        public async Task<List<EmployeeDTO>> Readall(int page = 1, int pageSize = 5)
        {



            var employees = await _context.Employees
               .OrderBy(e => e.Id)
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var employeeDTOs = _mapper.Map<List<EmployeeDTO>>(employees);

            return employeeDTOs;
        }




        public async Task<EmployeeDTO> Readbyid(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return new EmployeeDTO();
            }

            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);

            return employeeDTO;


        }
     



        public async Task<int> create( AddEmployeeDTO employeeDTO)
        {

            try
            {

                Employee employee = new Employee
                {
                    Name = employeeDTO.Name,
                    Age = employeeDTO.Age,

                };
               
              if (employeeDTO.Addresses != null)
                {
                    List<Address> addresses = new List<Address>();
                    foreach (var item in employeeDTO.Addresses)
                    {
                        Address addres = new Address
                        {
                            Description = item
                        };
                        addresses.Add(addres);
                    };
                    employee.Addresses = addresses;
               }

                await _context.Employees.AddAsync(employee);
                var res = await _context.SaveChangesAsync();

                return res;
            }
            catch (Exception)
            {

                return -1;
            }
           
        }


        public async Task<int> Update(UpdateEmployeeDTO employeeDTO)
        {
           

          

            var existingEmployee = _context.Employees.Find(employeeDTO.Id);

            if (existingEmployee == null)
            {
                return -1;
            }

            existingEmployee.Name = employeeDTO.Name?? existingEmployee.Name;
            existingEmployee.Age = employeeDTO.Age;




            if (employeeDTO.Addresses != null)
            {
               
                List<Address> addresses = new List<Address>();
                foreach (var item in employeeDTO.Addresses)
                {
                    Address addres = new Address
                    {
                        Description = item
                    };
                    addresses.Add(addres);
                };
                _context.RemoveRange(existingEmployee.Addresses);
                existingEmployee.Addresses = addresses;
                _context.Employees.Update(existingEmployee);

            }


            return await _context.SaveChangesAsync();
        }





        public async Task<int> delete(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return  -1;
            }

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync();
        }




      
    }
}
