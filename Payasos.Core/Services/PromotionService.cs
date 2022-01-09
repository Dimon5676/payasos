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

    public PromotionRequest GetRequestById(int id)
    {
        return _promotionRequestRepository.GetRequestById(id);
    }
    
    public ICollection<PromotionRequest> GetRequests(ClaimsPrincipal claims)
    {
        var org = _organisationService.GetUserOrganisation(claims);
        return _promotionRequestRepository.GetRequests().Where(e => e.User.Organization == org).ToList();
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
                IsClosed = false,
                User = user
            });
    }

    public async Task AddMark(ClaimsPrincipal claims, bool passed, int requestId)
    {
        var req = _promotionRequestRepository.GetRequestById(requestId);
        var user = await _userManager.GetUserAsync(claims);
        if (req.HardSkillsExpert == user) req.HardSkillPass = passed;
        if (req.SoftSkillsExpert == user) req.SoftSkillPass = passed;
        if (req.EnglishExpert == user) req.EnglishPass = passed;
        if (req.EnglishPass && req.HardSkillPass && req.SoftSkillPass)
        {
            req.User.Role = req.RoleWanted;
            req.IsClosed = true;
        }
        await _promotionRequestRepository.SaveChanges();
    }
    
    public async Task CloseRequest(ClaimsPrincipal claims, int requestId)
    {
        var req = _promotionRequestRepository.GetRequestById(requestId);
        var user = await _userManager.GetUserAsync(claims);
        if (!user.IsAdmin) return;

        req.IsClosed = true;
        
        await _promotionRequestRepository.SaveChanges();
    }
}