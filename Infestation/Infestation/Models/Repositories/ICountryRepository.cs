using System.Collections.Generic;

namespace Infestation.Models.Repositories
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        void RemoveCountry(int countryId);

        void AddCountry(Country country);
    }
}