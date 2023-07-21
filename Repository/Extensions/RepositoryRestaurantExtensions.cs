using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryRestaurantExtensions
    {
        public static IQueryable<Restaurant> Search(this IQueryable<Restaurant> restaurants, string searchTerm)
        {
            if
                (string.IsNullOrWhiteSpace(searchTerm))
                return
                    restaurants;
            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return
                restaurants.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
