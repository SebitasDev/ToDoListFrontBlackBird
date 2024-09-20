namespace ToDoListFront.Models;

public class ApiResponseToDo
{
    public bool? Status { get; set; }
    
    public ToDo Response { get; set; }
}