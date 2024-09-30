using ClinicaAppWeb.Models;
using ClinicaAppWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaAppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DtFamiliareController : Controller
    {
        private readonly DtFamiliareService _DtFamiliareSerevice;

        public DtFamiliareController(DtFamiliareService DtFamiliareService){
            _DtFamiliareSerevice = DtFamiliareService;
        }

        public async Task<ActionResult> Index(){
            var DtFamiliares = await _DtFamiliareSerevice.GetDtFamiliares();
            return View(DtFamiliares);
        }
        public async Task<ActionResult> Details(int id ){
            var DtFamiliare = await _DtFamiliareSerevice.GetDtFamiliareById(id);
            return View(DtFamiliare);
        }
        public ActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DtFamiliare DtFamiliare){
            await _DtFamiliareSerevice.CreateDtFamiliare(DtFamiliare);
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Edit(int id){
            var DtFamiliare = await _DtFamiliareSerevice.GetDtFamiliareById(id);
            return View(DtFamiliare);
        }
        public async Task<ActionResult> Delete(int id){
            var DtFamiliare = await _DtFamiliareSerevice.GetDtFamiliareById(id);
            return View(DtFamiliare);
        }

        public async Task<ActionResult> Delete(int id, DtFamiliare DtFamiliare){
            await _DtFamiliareSerevice.DeleteDtFamiliare(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
