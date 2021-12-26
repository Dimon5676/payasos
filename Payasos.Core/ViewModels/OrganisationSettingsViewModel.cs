namespace Payasos.Core.ViewModels;

public class OrganisationSettingsViewModel
{
    public string OrgName { get; set; }
    public string InviteCode { get; set; }
    public IEnumerable<string> Roles { get; set; }
}