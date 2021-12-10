using Payasos.Core.Entities;

namespace Payasos.Core.Repositories;

public interface IOrganisationRepository
{
    Organization AddOrganisation(Organization organization);
}