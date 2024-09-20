namespace ToDoListFront.Models;

public class ApiResponse
{
    public bool? Status { get; set; }
    public IEnumerable<ToDo>? Response { get; set; }
}