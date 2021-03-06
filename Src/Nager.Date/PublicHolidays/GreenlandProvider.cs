using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Greenland
    /// </summary>
    public class GreenlandProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// GreenlandProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public GreenlandProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.GL;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Epiphany", "Epiphany", countryCode));
            items.Add(this._catholicProvider.MaundyThursday("Maundy Thursday", year, countryCode));
            items.Add(this._catholicProvider.GoodFriday("Vendredi saint", year, countryCode));
            items.Add(this._catholicProvider.EasterSunday("Easter Sunday", year, countryCode));
            items.Add(this._catholicProvider.EasterMonday("Lundi de Pâques", year, countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(26), "Store Bededag", "Store Bededag", countryCode));
            items.Add(this._catholicProvider.AscensionDay("Ascension Day", year, countryCode));
            items.Add(this._catholicProvider.WhitMonday("Whit Monday", year, countryCode));
            items.Add(new PublicHoliday(year, 6, 21, "Ullortuneq", "Ullortuneq", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "St. Stephen's Day", "St. Stephen's Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 31, "New Year's Eve", "New Year's Eve", countryCode));

            return items.OrderBy(o => o.Date);
        }

        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Greenland",
            };
        }
    }
}
