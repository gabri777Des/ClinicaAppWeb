using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : Controller
    {
        private readonly ExpedienteService _ExpedienteSerevice;

        public ExpedienteController(ExpedienteService ExpedienteService){
            _ExpedienteSerevice = ExpedienteService;
        }

        public async Task<ActionResult> Index(){
            var expedientes = await _ExpedienteSerevice.GetExpedientes();
            return View(expedientes);
        }
        public async Task<ActionResult> Details(int id ){
            var expediente = await _ExpedienteSerevice.GetExpedienteById(id);
            return View(expediente);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Expediente expediente){
            await _ExpedienteSerevice.CreateExpediente(expediente);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var expediente = await _ExpedienteSerevice.GetExpedienteById(id);
            return View(expediente);
        }
        public async Task<ActionResult> Delete(int id){
            var expediente = await _ExpedienteSerevice.GetExpedienteById(id);
            return View(expediente);
        }

        public async Task<ActionResult> Delete(int id, Expediente expediente){
            await _ExpedienteSerevice.DeleteExpediente(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
