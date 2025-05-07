using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Bill.ValueObjects;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Dinner.Entities;
using HomeDine.Domain.Dinner.Enums;
using HomeDine.Domain.Dinner.ValueObjects;
using HomeDine.Domain.Host.ValueObjects;
using HomeDine.Domain.Menu.ValueObjects;

namespace HomeDine.Domain.Dinner
{
    public class Dinner : AggregateRoot<DinnerId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public DateTime StartedDateTime { get; private set; }
        public DateTime EndedDateTime { get; private set; }

        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; private set; }
        public int MaxGuests { get; private set; }
        public Price Price { get; private set; }

        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string? ImageUrl { get; private set; } // Nullable

        public Location Location { get; private set; }

        private readonly List<Reservation> _reservations = new();
        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Dinner(
            DinnerId id,
            HostId hostId,
            MenuId menuId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isPublic,
            int maxGuests,
            Price price,
            Location location,
            string? imageUrl
        )
            : base(id)
        {
            HostId = hostId;
            MenuId = menuId;
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            Location = location;
            ImageUrl = imageUrl;
            Status = DinnerStatus.Upcoming; // Initial status
        }

        public static Dinner Create(
            HostId hostId,
            MenuId menuId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isPublic,
            int maxGuests,
            Price price,
            Location location,
            string? imageUrl
        )
        {
            // --- Validations ---
            ArgumentNullException.ThrowIfNull(hostId);
            ArgumentNullException.ThrowIfNull(menuId);
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Dinner name cannot be empty.", nameof(name));
            if (startDateTime >= endDateTime)
                throw new ArgumentException(
                    "Start date time must be before end date time.",
                    nameof(startDateTime)
                );
            if (maxGuests < 1)
                throw new ArgumentOutOfRangeException(
                    nameof(maxGuests),
                    "Max guests must be at least 1."
                );
            ArgumentNullException.ThrowIfNull(price);
            ArgumentNullException.ThrowIfNull(location);

            var dinnerId = DinnerId.CreateUnique();
            var now = DateTime.UtcNow;

            var dinner = new Dinner(
                dinnerId,
                hostId,
                menuId,
                name,
                description,
                startDateTime,
                endDateTime,
                isPublic,
                maxGuests,
                price,
                location,
                imageUrl
            )
            {
                CreatedDateTime = now,
                UpdatedDateTime = now,
            };

            return dinner;
        }
    }
}
