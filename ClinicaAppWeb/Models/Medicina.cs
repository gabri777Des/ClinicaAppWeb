using System;

namespace ClinicaAppWeb.Models;

public class Medicina
{
    public int Id { get; set; }
    public int Expediente_Id { get; set; }
    public string? Nombre_Medicina { get; set; }
    public string? Dosis { get; set; }
    public DateTime Fecha_Prescripcion { get; set; }
}
