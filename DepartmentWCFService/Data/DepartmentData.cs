using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DepartmentWCFService
{
    public class DepartmentData
    {
        string conStr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

        public List<DepartmentEntity> GetAllDepartments()
        {
            List<DepartmentEntity> depts = new List<DepartmentEntity>();

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand("SELECT ID, Name, Description, Status FROM Departments", con))
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    depts.Add(new DepartmentEntity
                    {
                        ID = (int)dr["ID"],
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Status = (bool)dr["Status"]
                    });
                }
            }

            return depts;
        }

        public DepartmentEntity GetDepartmentById(int id)
        {
            DepartmentEntity dept = null;

            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand("SELECT ID, Name, Description, Status FROM Departments WHERE ID = @ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dept = new DepartmentEntity
                    {
                        ID = (int)dr["ID"],
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString(),
                        Status = (bool)dr["Status"]
                    };
                }
            }

            return dept;
        }

        public void AddDepartment(DepartmentEntity dept)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(@"INSERT INTO Departments (Name, Description, Status, CreatedOn, ModifiedOn) VALUES (@Name, @Description, @Status, @CreatedOn, @ModifiedOn)", con))
            {
                cmd.Parameters.AddWithValue("@Name", dept.Name);
                cmd.Parameters.AddWithValue("@Description", dept.Description);
                cmd.Parameters.AddWithValue("@Status", dept.Status);
                cmd.Parameters.AddWithValue("@CreatedOn", DateTime.Now);
                cmd.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(DepartmentEntity dept)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand(@"UPDATE Departments SET Name=@Name, Description=@Description, Status=@Status, ModifiedOn=@ModifiedOn WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", dept.ID);
                cmd.Parameters.AddWithValue("@Name", dept.Name);
                cmd.Parameters.AddWithValue("@Description", dept.Description);
                cmd.Parameters.AddWithValue("@Status", dept.Status);
                cmd.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int id)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            using (SqlCommand cmd = new SqlCommand("UPDATE Departments SET  Status=0,ModifiedOn=@ModifiedOn WHERE ID=@ID", con))
            {
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ModifiedOn", DateTime.Now);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
