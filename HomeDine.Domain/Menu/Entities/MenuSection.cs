using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Menu.ValueObjects;

namespace HomeDine.Domain.Menu.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();

        public string Name { get; }
        public string Description { get; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId id, string name, string description)
            : base(id)
        {
            Name = name;
            Description = description;
        }

        public static MenuSection Create(string name, string description)
        {
            return new(MenuSectionId.CreateUnique(), name, description);
        }
    }
}
