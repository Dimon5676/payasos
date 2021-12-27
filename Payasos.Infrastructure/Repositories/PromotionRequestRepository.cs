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
}