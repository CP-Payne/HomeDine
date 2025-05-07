using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Dinner.ValueObjects;
using HomeDine.Domain.Host.ValueObjects;
using HomeDine.Domain.Menu.Entities;
using HomeDine.Domain.Menu.ValueObjects;

namespace HomeDine.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public string Name { get; }
        public string Description { get; }
        public float AverageRating { get; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();

        public HostId HostId { get; }

        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Menu(
            MenuId id,
            HostId hostId,
            string name,
            string description,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Menu Create(HostId hostId, string name, string description)
        {
            var now = DateTime.UtcNow;

            return new Menu(MenuId.CreateUnique(), hostId, name, description, now, now);
        }
    }
}
