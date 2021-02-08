using Dapper;
using LearnAPI.Context;
using LearnAPI.Migrations;
using LearnAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace LearnAPI.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);
        DynamicParameters parameters = new DynamicParameters();
        public int Create(Department department)
        {
            var procedureName = "SP_Create_Department";
            parameters.Add("@Name", department.Name);
            var create = sqlConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return create;
        }

        public int Delete(int Id)
        {
            var procedureName = "SP_Delete_ByDepartmentId";
            var delete = sqlConnection.Execute(procedureName, new { Id}, commandType: CommandType.StoredProcedure);
            return delete;
        }

        public async Task<IEnumerable<Department>> Get()
        {
            var procedureGetAll = "SP_Retrieve_Department";
            var getDepartments = await sqlConnection.QueryAsync<Department>(procedureGetAll, commandType: CommandType.StoredProcedure);
            return getDepartments;
        }

        public async Task<Department> Get(int Id)
        {
            var procedureById = "SP_Retrieve_DepartmentId";
            var getById = await sqlConnection.QueryAsync<Department>(procedureById, new {Id}, commandType: CommandType.StoredProcedure);
            return getById.FirstOrDefault();
        }

        public int Update(int Id, Department department)
        {
            var procedureUpdate = "SP_Update_Department";
            var update = sqlConnection.Execute(procedureUpdate, new { Id, department.Name }, commandType: CommandType.StoredProcedure);
            return update;
        }
    }
}