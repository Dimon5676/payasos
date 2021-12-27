using Payasos.Core.Entities;

namespace Payasos.Core.Repositories;

public interface IPromotionRequestRepository
{
    public void AddPromotionRequest(PromotionRequest request);
}