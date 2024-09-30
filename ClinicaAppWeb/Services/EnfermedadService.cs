using System;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class EnfermedadService
{
  private readonly HttpClient _httpClient;

   public EnfermedadService(HttpClient httpClient){
    _httpClient = httpClient;
   }

   public async Task<List<Enfermedad>> GetEnfermedads(){
    return await _httpClient.GetFromJsonAsync<List<Enfermedad>>("api/Enfermedad");
   }

   public async Task<List<Enfermedad>> GetEnfermedadById(int id){
    return await _httpClient.GetFromJsonAsync<List<Enfermedad>>($"api/Enfermedad/{id}");
   }
   
   public async Task<Enfermedad> CreateEnfermedad(Enfermedad Enfermedad){
    var response = await _httpClient.PostAsJsonAsync("api/Enfermedad", Enfermedad);
    return await response.Content.ReadFromJsonAsync<Enfermedad>();
   }

   public async Task UpdateEnfermedad(Enfermedad Enfermedad){
    await _httpClient.PutAsJsonAsync($"api/Enfermedad/{Enfermedad.Id}", Enfermedad);
   }

   public async Task DeleteEnfermedad(int id){
    await _httpClient.DeleteAsync($"api/Enfermedad/{id}");
   }
}
