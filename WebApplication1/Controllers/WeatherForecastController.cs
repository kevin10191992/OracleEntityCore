using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ModelContext _context;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ModelContext context, ILogger<WeatherForecastController> logger)
        {
            _context = context;
            _logger = logger;
        }




        [HttpGet]

        public IEnumerable<VariablesOtorgamiento> Get()
        {
            var r = _context.VariablesOtorgamientos.ToList();
            return r;
        }

        [HttpGet]
        [Route("GetSingle")]

        public async Task<JObject> GetSingle()
        {
            var r = _context.VariablesOtorgamientos.FirstOrDefault();



            int nro = await _context.VariablesOtorgamientos.Where(a => a.SqParticipante == 1 && a.SqSolicitud == 1).CountAsync();


            var res = new
            {
                Codigo = "01",
                Descripcion = "Exito",
                Data = nro,
                Data2 = r
            };

            return (JObject.FromObject(res));
        }
    }
}