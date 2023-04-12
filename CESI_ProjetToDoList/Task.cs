using System.ComponentModel.DataAnnotations;

namespace CESI_ProjetToDoList
{
    public class Task
    {
        [Key] // Attribut pour indiquer que Id est la clé primaire
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool IsCompleted { get; set; }
    }
}
