using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;
using Payasos.Core.ViewModels;

namespace Payasos.Core.Services;

public class PromotionService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly OrganisationService _organisationService;
    private readonly IPromotionRequestRepository _promotionRequestRepository;

    public PromotionService(
        UserManager<AppUser> userManager,
        OrganisationService organisationService,
        IPromotionRequestRepository promotionRequestRepository)
    {
        _userManager = userManager;
        _organisationService = organisationService;
        _promotionRequestRepository = promotionRequestRepository;
    }

    public ICollection<AppUser> GetUserFromOrganisation(ClaimsPrincipal claims)
    {
        var org = _organisationService.GetUserOrganisation(claims);
        return _userManager.Users
            .Include(e => e.Organization)
            .Where(e => e.Organization.Id == org.Id).ToList();
    }

    public async Task AddRequest(PromotionRequestViewModel viewModel, ClaimsPrincipal claims)
    {
        var user = await _userManager.GetUserAsync(claims);
        var org = _organisationService.GetUserOrganisation(claims);
        _promotionRequestRepository.AddPromotionRequest(
            new PromotionRequest
            {
                HardSkillsExpert = _userManager.Users.FirstOrDefault(u => u.Id == viewModel.HardSkillsExpert.Id),
                SoftSkillsExpert = _userManager.Users.FirstOrDefault(u => u.Id == viewModel.SoftSkillsExpert.Id),
                EnglishExpert = _userManager.Users.FirstOrDefault(u => u.Id == viewModel.EnglishExpert.Id),
                InterviewDate = viewModel.InterviewDate,
                RoleWanted = org.Roles.FirstOrDefault(r => r.Id == viewModel.RoleWanted.Id),
                HardSkillPass = false,
                SoftSkillPass = false,
                EnglishPass = false,
                User = user
            });
    }
}