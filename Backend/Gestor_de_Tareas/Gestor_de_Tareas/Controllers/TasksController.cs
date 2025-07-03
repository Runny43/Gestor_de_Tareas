using Gestor_de_Tareas.DatabaseHelper;
using Gestor_de_Tareas.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gestor_de_Tareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)

        {

            _context = context;

        }
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<List<Tareas>> Get()
        {
            List<Tareas> tasksList= new List<Tareas>();
            tasksList= await _context.Tareas.ToListAsync();
            return tasksList;

        }
        
        // GET api/<TaskController>/5
        [HttpGet("{title}")]
        public IQueryable<Tareas> Get(string title)
        {
            var tareasLista= from x in _context.Tareas where x.Title == title select x;
            return tareasLista;
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] Tareas tarea)
        {
            tarea.Id = 0; //Id en 0 ya que la base de datos la ingresa de manera auto incrementable
            _context.Tareas.Add(tarea);
            _context.SaveChanges();

            return Ok();
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public void Put(string title, [FromBody] Tareas tarea)
        { 
            
            var fila= from x in _context.Tareas where x.Title == title select x;

            
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{title}")]
        public async void Delete(string title)
        {
            var tareasLista = from x in _context.Tareas where x.Title == title select x;

            var value = tareasLista.ExecuteDelete();
            //using (SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-G0MO3BT;Initial Catalog=Tasks_Database;Integrated Security=True"))
            //{
            //    conexion.Open();
            //    string eliminar= "Delete from [Tasks_Database].[dbo].[Tareas] WHERE Title=" + title;
            //    SqlCommand cmd = new SqlCommand(eliminar, conexion);
            //    int filasAfectadas = cmd.ExecuteNonQuery();
            //}
        }
    }
}
