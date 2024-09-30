using System;
using System.Net.Http.Json;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class PacienteService
{
   private readonly HttpClient _httpClient;
   public PacienteService(HttpClient httpClient){
    _httpClient = httpClient;
   }
   public async Task<List<Paciente>> GetPacientes(){
    return await _httpClient.GetFromJsonAsync<List<Paciente>>("api/Paciente");
   }
   public async Task<List<Paciente>> GetPacienteById(int id){
    return await _httpClient.GetFromJsonAsync<List<Paciente>>($"api/Paciente/{id}");
   }
   public async Task<Paciente> CreatePaciente(Paciente Paciente){
    var response = await _httpClient.PostAsJsonAsync("api/Paciente", Paciente);
    return await response.Content.ReadFromJsonAsync<Paciente>();
   }
   public async Task UpdatePaciente(Paciente Paciente){
    await _httpClient.PutAsJsonAsync($"api/Paciente/{Paciente.Id}", Paciente);
   }
   public async Task DeletePaciente(int id){
    await _httpClient.DeleteAsync($"api/Paciente/{id}");
   }
}
