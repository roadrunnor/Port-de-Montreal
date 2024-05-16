namespace PortAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using PortAPI.Data;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly PortDbContext _context;

        public ReportsController(PortDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetMonthlyReport(int mois, int annee)
        {
            var connection = _context.Database.GetDbConnection();
            var command = connection.CreateCommand();
            command.CommandText = "GenererRapportMensuel";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Mois", mois));
            command.Parameters.Add(new SqlParameter("@Annee", annee));

            await connection.OpenAsync();

            var result = new List<object>();
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    result.Add(new
                    {
                        Type = reader.GetString(0),
                        NomNavire = reader.GetString(1),
                        DateHeure = reader.GetDateTime(2),
                        Port = reader.GetString(3),
                        TerminalOuQuai = reader.GetString(4)
                    });
                }
            }

            await connection.CloseAsync();
            return result;
        }
    }

}
