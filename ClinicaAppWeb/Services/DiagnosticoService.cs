using System;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class DiagnosticoService
{
  private readonly HttpClient _httpClient;

   public DiagnosticoService(HttpClient httpClient){
    _httpClient = httpClient;
   }

   public async Task<List<Diagnostico>> GetDiagnosticos(){
    return await _httpClient.GetFromJsonAsync<List<Diagnostico>>("api/Diagnostico");
   }

   public async Task<List<Diagnostico>> GetDiagnosticoById(int id){
    return await _httpClient.GetFromJsonAsync<List<Diagnostico>>($"api/Diagnostico/{id}");
   }
   
   public async Task<Diagnostico> CreateDiagnostico(Diagnostico Diagnostico){
    var response = await _httpClient.PostAsJsonAsync("api/Diagnostico", Diagnostico);
    return await response.Content.ReadFromJsonAsync<Diagnostico>();
   }

   public async Task UpdateDiagnostico(Diagnostico Diagnostico){
    await _httpClient.PutAsJsonAsync($"api/Diagnostico/{Diagnostico.Id}", Diagnostico);
   }

   public async Task DeleteDiagnostico(int id){
    await _httpClient.DeleteAsync($"api/Diagnostico/{id}");
   }
}
