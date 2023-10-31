using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;




namespace ProyectoBugsManager.Models;

public class Error
{
    //[Key]
    public int ErrorId { get; set; }

    //[Required]
    public string Description { get; set; }

    //[Required]
    public int ProyectoId { get; set; }

    //[Required]
    public int UserId { get; set; }

    //[Required]
    public DateTime Date { get; set; }

    // Relaciones con otros modelos
    public Proyecto Proyecto { get; set; }
    public Usuario User { get; set; }
}
