namespace Gestor_de_Tareas.Model
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string State { get; set; }
    }
}
