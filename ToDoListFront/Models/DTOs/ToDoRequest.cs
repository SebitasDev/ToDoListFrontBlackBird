namespace ToDoListFront.Models.DTOs;

public class ToDoRequest
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}