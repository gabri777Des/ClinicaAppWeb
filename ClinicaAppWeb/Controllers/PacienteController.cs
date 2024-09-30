using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly PacienteService _pacienteSerevice;
        public PacienteController(PacienteService pacienteService){
            _pacienteSerevice = pacienteService;
        }

        public async Task<ActionResult> Index(){
            var pacientes = await _pacienteSerevice.GetPacientes();
            return View(pacientes);
        }
        public async Task<ActionResult> Details(int id ){
            var Paciente = await _pacienteSerevice.GetPacienteById(id);
            return View(Paciente);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Paciente paciente){
            await _pacienteSerevice.CreatePaciente(paciente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var Paciente = await _pacienteSerevice.GetPacienteById(id);
            return View(Paciente);
        }
        public async Task<ActionResult> Delete(int id){
            var paciente = await _pacienteSerevice.GetPacienteById(id);
            return View(paciente);
        }

        public async Task<ActionResult> Delete(int id, Paciente paciente){
            await _pacienteSerevice.DeletePaciente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
