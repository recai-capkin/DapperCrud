using Dapper;
using DapperDeneme.Dto;
using DapperDeneme.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        IConfiguration _configuration;
        SqlQueryWord sqw = new SqlQueryWord();
        public FactoryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet("Get-All-Factory")]
        public async Task<IActionResult> GetFactory()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            //FactoryDto içerisine constructor kullanmadan bu şekil bir sorgu yazılabilir
            var factory = await connection.QueryAsync<FactoryDto>("SELECT FactoryId,FactoryName,BaseFactory FROM Factories");
            //FactoryDto içerisine constructor kullanarak bu şekil bir sorgu yazılabilir
            //var factory = await connection.QueryAsync<FactoryDto>("SELECT * FROM Factories");
            return Ok(factory);
        }
        [HttpGet("Get-By-Id-Factory")]
        public async Task<IActionResult> GetByIdFactory(int factoryId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            try
            {
                var factory = await connection.QueryFirstAsync<Factory>("Select * From Factories Where FactoryId = @Id", new { Id = factoryId });
                //FactoryDto factoryDto = new(factory.FactoryId, factory.FactoryNam, int.Parse(factory.BaseFactory));

                return Ok(factory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Register-Factory")]
        public async Task<IActionResult> GetByIdFactory(Factory factoryData)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("ConnectionString"));
            try
            {
                await connection.QueryAsync<Factory>("Insert INTO Factories(FactoryName,BaseFactory) VALUES(@Name,@Base)  ",
                    new { 
                        Name = factoryData.FactoryName,
                        Base = factoryData.BaseFactory
                    });
                //FactoryDto factoryDto = new(factory.FactoryId, factory.FactoryNam, int.Parse(factory.BaseFactory));

                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

