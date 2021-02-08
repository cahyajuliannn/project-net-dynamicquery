using Dapper;
using LearnAPI.Models;
using LearnAPI.ViewModel;
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
    public class DivisionRepository : IDivisionRepository
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString);
        DynamicParameters parameters = new DynamicParameters();
        public int Create(Division division)
        {
            var procedureName = "SP_Create_Division";
            parameters.Add("@Name", division.Name);
            parameters.Add("@DepartmenId", division.DepartmenId);
            var create = sqlConnection.Execute(procedureName, parameters, commandType: CommandType.StoredProcedure);
            return create;
        }
        public async Task<IEnumerable<DivisionVM>> Get()
        {
            var procedureGetAll = "SP_Retrieve_Divisions";
            var getDivisions = await sqlConnection.QueryAsync<DivisionVM>(procedureGetAll, commandType: CommandType.StoredProcedure);
            return getDivisions;
        }
        public async Task<DivisionVM> Get(int Id)
        {
            var procedureById = "SP_Retrieve_DivisionById";
            var getDivisionById = await sqlConnection.QueryAsync<DivisionVM>(procedureById, new {Id}, commandType: CommandType.StoredProcedure);
            return getDivisionById.FirstOrDefault();
        }
        public int Update(int Id, DivisionVM divisionVM)
        {
            var procedureUpdate = "SP_Update_Division";
            var update = sqlConnection.Execute(procedureUpdate, new { Id, divisionVM.Name }, commandType: CommandType.StoredProcedure);
            return update;
        }
        public int Delete(int id)
        {
            var procedureDelete = "SP_Delete_ByDivisionId";
            var delete = sqlConnection.Execute(procedureDelete, new { id }, commandType: CommandType.StoredProcedure);
            return delete;
        }
    }
}