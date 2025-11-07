using System.Collections.Generic;
using System.ServiceModel;

namespace DepartmentWCFService
{
    [ServiceContract]
    public interface IDepartment
    {

        [OperationContract]
        List<DepartmentEntity> GetDepartments();
        [OperationContract]
        DepartmentEntity GetDepartmentById(int id);
        [OperationContract]
        void AddDepartment(DepartmentEntity dept);
        [OperationContract]
        void UpdateDepartment(DepartmentEntity dept);
        [OperationContract]
        void DeleteDepartment(int id);
    }
}
