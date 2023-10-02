using employeeTask.DTO;

namespace employeeTask.Services.Contract
{
    public interface IEmployeeservice
    {
        Task<List<EmployeeDTO>> Readall(int page = 1, int pageSize = 2);
        Task<int> create(AddEmployeeDTO model);

        Task<EmployeeDTO> Readbyid(int id);
         Task<int> Update(UpdateEmployeeDTO employeeDTO);

        Task<int> delete(int id);
    }
}
