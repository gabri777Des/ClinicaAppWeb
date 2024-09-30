using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinaController : Controller
    {
        private readonly MedicinaService _MedicinaSerevice;

        public MedicinaController(MedicinaService MedicinaService){
            _MedicinaSerevice = MedicinaService;
        }

        public async Task<ActionResult> Index(){
            var Medicinas = await _MedicinaSerevice.GetMedicinas();
            return View(Medicinas);
        }
        public async Task<ActionResult> Details(int id ){
            var Medicina = await _MedicinaSerevice.GetMedicinaById(id);
            return View(Medicina);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Medicina Medicina){
            await _MedicinaSerevice.CreateMedicina(Medicina);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var Medicina = await _MedicinaSerevice.GetMedicinaById(id);
            return View(Medicina);
        }
        public async Task<ActionResult> Delete(int id){
            var Medicina = await _MedicinaSerevice.GetMedicinaById(id);
            return View(Medicina);
        }

        public async Task<ActionResult> Delete(int id, Medicina Medicina){
            await _MedicinaSerevice.DeleteMedicina(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
