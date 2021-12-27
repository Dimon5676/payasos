using Microsoft.EntityFrameworkCore;
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

    public Organization GetOrganisationByCode(string code)
    {
        return _context.Organizations
            .Include(o => o.Roles)
            .FirstOrDefault(o => o.Code == code);
    }

    public Organization GetOrganisationByName(string name)
    {
        return _context.Organizations
            .Include(o => o.Roles)
            .FirstOrDefault(o => o.Name == name);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}