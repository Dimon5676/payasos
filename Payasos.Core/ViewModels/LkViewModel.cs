namespace Payasos.Core.ViewModels;

public class LkViewModel
{
    public string OrgName { get; set; }
    public string InviteCode { get; set; }
    public IEnumerable<UserViewModel> Users { get; set; }
}