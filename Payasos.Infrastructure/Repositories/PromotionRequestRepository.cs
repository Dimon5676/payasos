using Microsoft.EntityFrameworkCore;
using Payasos.Core.Entities;
using Payasos.Core.Repositories;

namespace Payasos.Infrastructure.Repositories;

public class PromotionRequestRepository : IPromotionRequestRepository
{
    private readonly AppDbContext _context;

    public PromotionRequestRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public void AddPromotionRequest(PromotionRequest request)
    {
        _context.PromotionRequests.Add(request);
        _context.SaveChanges();
    }

    public ICollection<PromotionRequest> GetRequests()
    {
        return _context.PromotionRequests
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .Include(e => e.RoleWanted)
            .ToList();
    }

    public PromotionRequest GetRequestById(int id)
    {
        return _context.PromotionRequests
            .Include(e => e.User)
            .ThenInclude(e => e.Role)
            .Include(e => e.HardSkillsExpert)
            .Include(e => e.SoftSkillsExpert)
            .Include(e => e.EnglishExpert)
            .FirstOrDefault(e => e.Id == id);
    }
}