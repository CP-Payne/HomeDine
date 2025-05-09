using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Menu.ValueObjects;

namespace HomeDine.Domain.Menu.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; }
        public string Description { get; }

        private MenuItem(MenuItemId id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
