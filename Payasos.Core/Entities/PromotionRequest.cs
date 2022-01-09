namespace Payasos.Core.Entities;

public class PromotionRequest
{
    public int Id { get; set; }
    public AppUser User { get; set; }
    
    public Role RoleWanted { get; set; }
    public AppUser HardSkillsExpert { get; set; }
    public AppUser SoftSkillsExpert { get; set; }
    public AppUser EnglishExpert { get; set; }
    public bool HardSkillPass { get; set; }
    public bool SoftSkillPass { get; set; }
    public bool EnglishPass { get; set; }
    
    public bool IsClosed { get; set; }
    public DateTime InterviewDate { get; set; }
}