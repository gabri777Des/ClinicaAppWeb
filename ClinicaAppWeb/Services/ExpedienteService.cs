using System;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class ExpedienteService
{
   private readonly HttpClient _httpClient;

   public ExpedienteService(HttpClient httpClient){
    _httpClient = httpClient;
   }

   public async Task<List<Expediente>> GetExpedientes(){
    return await _httpClient.GetFromJsonAsync<List<Expediente>>("api/Expediente");
   }

   public async Task<List<Expediente>> GetExpedienteById(int id){
    return await _httpClient.GetFromJsonAsync<List<Expediente>>($"api/Expediente/{id}");
   }
   
   public async Task<Expediente> CreateExpediente(Expediente Expediente){
    var response = await _httpClient.PostAsJsonAsync("api/Expediente", Expediente);
    return await response.Content.ReadFromJsonAsync<Expediente>();
   }

   public async Task UpdateExpediente(Expediente Expediente){
    await _httpClient.PutAsJsonAsync($"api/Expediente/{Expediente.Id}", Expediente);
   }

   public async Task DeleteExpediente(int id){
    await _httpClient.DeleteAsync($"api/Expediente/{id}");
   }
}
