using System;
using System.Collections.Generic;

namespace Infestation.Models.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        public InfestationDbContext _context { get; set; }
        public CountryRepository(InfestationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public void AddCountry(Country country)
        {
            throw new NotImplementedException();
        }

        public void RemoveCountry(int countryId)
        {
            throw new NotImplementedException();
        }
    }
}