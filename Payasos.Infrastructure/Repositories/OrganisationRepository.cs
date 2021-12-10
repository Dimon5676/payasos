using Payasos.Core.Entities;
using Payasos.Core.Repositories;

namespace Payasos.Infrastructure.Repositories;

public class OrganisationRepository : IOrganisationRepository
{
    private readonly AppDbContext _context;

    public OrganisationRepository(AppDbContext context)
    {
        _context = context;
    }
    public Organization AddOrganisation(Organization organization)
    {
        var res = _context.Organizations.Add(organization); 
        _context.SaveChanges();
        return res.Entity;
    }
}