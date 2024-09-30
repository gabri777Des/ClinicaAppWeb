using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : Controller
    {
        private readonly DiagnosticoService _DiagnosticoSerevice;

        public DiagnosticoController(DiagnosticoService DiagnosticoService){
            _DiagnosticoSerevice = DiagnosticoService;
        }

        public async Task<ActionResult> Index(){
            var Diagnosticos = await _DiagnosticoSerevice.GetDiagnosticos();
            return View(Diagnosticos);
        }
        public async Task<ActionResult> Details(int id ){
            var Diagnostico = await _DiagnosticoSerevice.GetDiagnosticoById(id);
            return View(Diagnostico);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Diagnostico Diagnostico){
            await _DiagnosticoSerevice.CreateDiagnostico(Diagnostico);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var Diagnostico = await _DiagnosticoSerevice.GetDiagnosticoById(id);
            return View(Diagnostico);
        }
        public async Task<ActionResult> Delete(int id){
            var Diagnostico = await _DiagnosticoSerevice.GetDiagnosticoById(id);
            return View(Diagnostico);
        }

        public async Task<ActionResult> Delete(int id, Diagnostico Diagnostico){
            await _DiagnosticoSerevice.DeleteDiagnostico(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
