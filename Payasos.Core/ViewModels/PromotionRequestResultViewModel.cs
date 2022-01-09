using Payasos.Core.Entities;

namespace Payasos.Core.ViewModels;

public class PromotionRequestResultViewModel : PromotionRequestViewModel
{
    public bool HardSkillPass { get; set; }
    
    public bool SoftSkillPass { get; set; }
    
    public bool EnglishPass { get; set; }
    
    public AppUser User { get; set; }
}