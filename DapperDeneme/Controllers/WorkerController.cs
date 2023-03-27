using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using DapperDeneme.Dto;
using System.Data.SqlClient;

namespace DapperDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IConfiguration _configuration;
        public WorkerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("Get-All-Worker-With-Detail")]
        public async Task<IActionResult> GetWorkers()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            
            var workers = await connection.QueryAsync<WorkersDto>(
                "SELECT WorkerName,WorkerSurname,Factories.FactoryName as WorkerFactoryName,Positions.PositionName as WorkerPositionName FROM Workers " +
                "INNER JOIN Factories ON Workers.WorkerFactoryId=Factories.FactoryId "+
                "INNER JOIN Positions ON Workers.WorkerPositionId=Positions.PositionId");
            return Ok(workers);
        }
    }
}
