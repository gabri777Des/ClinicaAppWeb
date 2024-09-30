using System;
using ClinicaAppWeb.Models;

namespace ClinicaAppWeb.Services;

public class DtFamiliareService
{
  private readonly HttpClient _httpClient;

   public DtFamiliareService(HttpClient httpClient){
    _httpClient = httpClient;
   }

   public async Task<List<DtFamiliare>> GetDtFamiliares(){
    return await _httpClient.GetFromJsonAsync<List<DtFamiliare>>("api/DtFamiliare");
   }

   public async Task<List<DtFamiliare>> GetDtFamiliareById(int id){
    return await _httpClient.GetFromJsonAsync<List<DtFamiliare>>($"api/DtFamiliare/{id}");
   }
   
   public async Task<DtFamiliare> CreateDtFamiliare(DtFamiliare DtFamiliare){
    var response = await _httpClient.PostAsJsonAsync("api/DtFamiliare", DtFamiliare);
    return await response.Content.ReadFromJsonAsync<DtFamiliare>();
   }

   public async Task UpdateDtFamiliare(DtFamiliare DtFamiliare){
    await _httpClient.PutAsJsonAsync($"api/DtFamiliare/{DtFamiliare.Id}", DtFamiliare);
   }

   public async Task DeleteDtFamiliare(int id){
    await _httpClient.DeleteAsync($"api/DtFamiliare/{id}");
   }
}
