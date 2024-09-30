using System;

namespace ClinicaAppWeb.Models;

public class Enfermedad
{
    public int Id { get; set; }
    public string Nombre_enfermedad { get; set; }
    public string Descripcion { get; set; }
    public int IdExpediente { get; set; }
}
