namespace Payasos.Core.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Organization Organization { get; set; } = null!;
}