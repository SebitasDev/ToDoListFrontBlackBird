using ToDoListFront.Models;

namespace ToDoListFront.Repository;

public interface IToDoRepository
{
    //GET
    Task<IEnumerable<ToDo>> GetAllToDo();
    Task<ToDo> GetToDoById(string id);
    
    //PUT
    Task<ApiResponseString> SoftDelete(string id);
    
    //CREATE
    Task<ApiResponseToDo> CreateToDo(string nombre, string descripcion);
}