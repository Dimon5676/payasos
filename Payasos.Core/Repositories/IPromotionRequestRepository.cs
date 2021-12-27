using Payasos.Core.Entities;

namespace Payasos.Core.Repositories;

public interface IPromotionRequestRepository
{
    public void AddPromotionRequest(PromotionRequest request);
    public ICollection<PromotionRequest> GetRequests();
    public PromotionRequest GetRequestById(int id);
}