using System;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class MedicinaService
{
    private readonly HttpClient _httpClient;

   public MedicinaService(HttpClient httpClient){
    _httpClient = httpClient;
   }

   public async Task<List<Medicina>> GetMedicinas(){
    return await _httpClient.GetFromJsonAsync<List<Medicina>>("api/Medicina");
   }

   public async Task<List<Medicina>> GetMedicinaById(int id){
    return await _httpClient.GetFromJsonAsync<List<Medicina>>($"api/Medicina/{id}");
   }
   
   public async Task<Medicina> CreateMedicina(Medicina medicina){
    var response = await _httpClient.PostAsJsonAsync("api/Medicina", medicina);
    return await response.Content.ReadFromJsonAsync<Medicina>();
   }

   public async Task UpdateMedicina(Medicina medicina){
    await _httpClient.PutAsJsonAsync($"api/Medicina/{medicina.Id}", medicina);
   }

   public async Task DeleteMedicina(int id){
    await _httpClient.DeleteAsync($"api/Medicina/{id}");
   }
}
