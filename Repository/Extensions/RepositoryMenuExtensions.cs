using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Extensions
{
    public static class RepositoryMenuExtensions
    {
        public static IQueryable<MenuItem> Search(this IQueryable<MenuItem> menuItems, string searchTerm)
        { 
            if
                (string.IsNullOrWhiteSpace(searchTerm))
                return
                    menuItems;
            var lowerCaseTerm = searchTerm.Trim().ToLower(); 

            return 
                menuItems.Where(e => e.Name.ToLower().Contains(lowerCaseTerm));
        }
    }
}
