using System.Text;
using Newtonsoft.Json;
using ToDoListFront.Models;
using ToDoListFront.Models.DTOs;

namespace ToDoListFront.Repository;

public class ToDoRepository : IToDoRepository
{
    private readonly HttpClient _client;

    public ToDoRepository(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<ToDo>> GetAllToDo()
    {
        try
        {
            HttpResponseMessage httpResponseMessage = await
                _client.GetAsync("https://todo-blackbird-3.onrender.com/api/ToDo/GetAllToDos");

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseBody = await httpResponseMessage
                .Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
            
            return apiResponse?.Response ?? Enumerable.Empty<ToDo>();

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<ToDo> GetToDoById(string id)
    {
        try
        {
            HttpResponseMessage httpResponseMessage = await
                _client.GetAsync($"https://todo-blackbird-3.onrender.com/api/ToDo/GetToDoById/{id}");

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseBody = await httpResponseMessage
                .Content.ReadAsStringAsync();

            var apiResponse = JsonConvert.DeserializeObject<ApiResponseToDo>(responseBody);
            
            return apiResponse?.Response ?? null!;

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ApiResponseToDo> CreateToDo(string nombre, string descripcion)
    {
        try
        {
            ToDoRequest toDoRequest = new ToDoRequest
            {
                Name = nombre,
                Description = descripcion
            };

            string json = JsonConvert.SerializeObject(toDoRequest);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            
            HttpResponseMessage httpResponseMessage = await
                _client.PostAsync("https://todo-blackbird-3.onrender.com/api/ToDoCreate/CreateToDo", content);

            httpResponseMessage.EnsureSuccessStatusCode();

            string responseBody = await httpResponseMessage
                .Content.ReadAsStringAsync();
            
            var apiResponse = JsonConvert.DeserializeObject<ApiResponseToDo>
                (responseBody);

            return apiResponse;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ApiResponseString> SoftDelete(string id)
    {
        HttpResponseMessage httpResponseMessage = await
            _client.PutAsync($"https://todo-blackbird-3.onrender.com/api/ToDoUpdate/SoftDeleteToDo/{id}", null);

        httpResponseMessage.EnsureSuccessStatusCode();

        string responseBody = await httpResponseMessage
            .Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<ApiResponseString>
            (responseBody);

        return apiResponse;
    }
}