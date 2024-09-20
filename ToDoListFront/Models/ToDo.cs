namespace ToDoListFront.Models;

public class ToDo
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Date_Create { get; set; }
    public string? Date_Finish { get; set; }
    public required string Status { get; set; }
    public bool IsActive { get; set; }

    public bool FunctionCheckStatus()
    {
        if (Status == "Activo")
        {
            return false;
        }
        else
        {
             return true;
        }
    }
}