using System;

namespace ClinicaAppWeb.Models;

public class Expediente
{
   public int Id{get; set;} 
   public string Numero_Expediente {get; set;} 
   public int IdPaciente {get; set;}
   public DateTime Fecha_creacion { get; set; }
}
