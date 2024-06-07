using System;
namespace Domain;
public class Pending: ModelBase

{
    public string Name { get; set; }
    public string DescriptionTask { get; set; }
    public DateTime DueDate { get; set; }
    public string AssignedTo { get; set; }
    public string Priority { get; set; }
    public string Category { get; set; }
    public string StateOfTask { get; set; }
    public int IdAccount { get; set; }
}