using Payasos.Core.Entities;

namespace Payasos.Core.ViewModels;

public class RequestsViewModel
{
    public ICollection<PromotionRequest> Requests { get; set; }
}