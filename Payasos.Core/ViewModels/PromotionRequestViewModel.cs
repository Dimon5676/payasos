using Payasos.Core.Entities;

namespace Payasos.Core.ViewModels;

public class PromotionRequestViewModel
{
    public AppUser HardSkillsExpert { get; set; }
    public AppUser SoftSkillsExpert { get; set; }
    public AppUser EnglishExpert { get; set; }
    public ICollection<AppUser> Users { get; set; }
    public DateTime InterviewDate { get; set; }
    public Role RoleWanted { get; set; }
    public ICollection<Role> Roles { get; set; }
}