namespace ProyectoBugsManager.Models;

public class Error
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public Proyecto Proyecto { get; set; }

    public int UserId { get; set; }
    public Usuario User { get; set; }

    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
}
