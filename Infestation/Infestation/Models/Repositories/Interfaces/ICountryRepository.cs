using System.Collections.Generic;

namespace Infestation.Models.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetAllCountries();

        void AddCountry(Country country);

        void RemoveCountry(int countryId);
    }
}