using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnfermedadController : Controller
    {
        private readonly EnfermedadService _EnfermedadSerevice;

        public EnfermedadController(EnfermedadService EnfermedadService){
            _EnfermedadSerevice = EnfermedadService;
        }

        public async Task<ActionResult> Index(){
            var Enfermedads = await _EnfermedadSerevice.GetEnfermedads();
            return View(Enfermedads);
        }
        public async Task<ActionResult> Details(int id ){
            var Enfermedad = await _EnfermedadSerevice.GetEnfermedadById(id);
            return View(Enfermedad);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Enfermedad Enfermedad){
            await _EnfermedadSerevice.CreateEnfermedad(Enfermedad);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var Enfermedad = await _EnfermedadSerevice.GetEnfermedadById(id);
            return View(Enfermedad);
        }
        public async Task<ActionResult> Delete(int id){
            var Enfermedad = await _EnfermedadSerevice.GetEnfermedadById(id);
            return View(Enfermedad);
        }

        public async Task<ActionResult> Delete(int id, Enfermedad Enfermedad){
            await _EnfermedadSerevice.DeleteEnfermedad(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
