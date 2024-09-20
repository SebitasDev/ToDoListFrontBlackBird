namespace ToDoListFront.Models;

public class ApiResponseString
{
    public bool? Status { get; set; }
    public required string Response { get; set; }
}