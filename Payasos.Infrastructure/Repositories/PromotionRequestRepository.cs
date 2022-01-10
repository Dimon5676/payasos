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
            .AsSplitQuery()
            .Include(e => e.RoleWanted)
            .AsSplitQuery()
            .Where(e => e.IsClosed == false)
            .ToList();
    }

    public PromotionRequest GetRequestById(int id)
    {
        return _context.PromotionRequests
            .Include(e => e.User)
                .ThenInclude(e => e.Role)
            .AsSplitQuery()
            .Include(e => e.HardSkillsExpert)
            .AsSplitQuery()
            .Include(e => e.SoftSkillsExpert)
            .AsSplitQuery()
            .Include(e => e.EnglishExpert)
            .AsSplitQuery()
            .Include(e => e.RoleWanted)
            .FirstOrDefault(e => e.Id == id);
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }
}