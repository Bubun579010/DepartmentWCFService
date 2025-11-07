using System.Collections.Generic;

namespace DepartmentWCFService
{
    public class DepartmentService : IDepartment
    {
        DepartmentData data = new DepartmentData();
        public List<DepartmentEntity> GetDepartments()
        {
            return data.GetAllDepartments();
        }

        public DepartmentEntity GetDepartmentById(int id)
        {
            return data.GetDepartmentById(id);
        }

        public void AddDepartment(DepartmentEntity dept)
        {
            data.AddDepartment(dept);
        }
        
        public void UpdateDepartment(DepartmentEntity dept)
        {
            data.UpdateDepartment(dept);
        }

        public void DeleteDepartment(int id)
        {
            data.DeleteDepartment(id);
        }
    }
}
