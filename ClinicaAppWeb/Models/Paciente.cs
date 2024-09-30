using System;

namespace ClinicaAppWeb.Models;

public class Paciente
{
   public int Id {get ; set;}
    public string Nombre {get; set;}
   public string Apellido {get; set;} 
   public DateTime Fecha_nacimiento {get; set;}
   public string Telefono {get; set;}
   public string Email {get; set;} 
}
