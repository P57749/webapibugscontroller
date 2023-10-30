
namespace ProyectoBugsManager.Models;



public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public ICollection<Error> Errores { get; set; }
}