using System.ComponentModel.DataAnnotations.Schema;

namespace Payasos.Core.Entities;

public class Organization
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    
    public int DefaultRoleId { get; set; }
    public ICollection<Role> Roles { get; set; }
}