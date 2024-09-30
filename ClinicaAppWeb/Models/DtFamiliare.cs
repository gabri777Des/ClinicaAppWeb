using System;

namespace ClinicaAppWeb.Models;

public class DtFamiliare
{
   public int Id{get; set;} 
   public string Nombre {get; set;} 
  public string Relacion_paciente {get; set;}
   public int Telefono {get; set;}
   public string Email {get; set;}
   public int IdPaciente {get; set;}
}
