namespace Payasos.Core.Entities;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Code { get; set; } = null!;
    public IEnumerable<Role> Roles { get; set; } = null!;
}