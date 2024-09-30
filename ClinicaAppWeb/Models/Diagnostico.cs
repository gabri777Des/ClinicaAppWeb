using System;

namespace ClinicaAppWeb.Models;

public class Diagnostico
{
   public int Id { get; set; }
    public string diagnostico { get; set; }
    public int IdExpediente { get; set; }
    public DateTime Fecha_diagnostico { get; set; }
}
