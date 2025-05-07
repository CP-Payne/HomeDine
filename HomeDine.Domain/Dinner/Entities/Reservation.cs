using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Bill.ValueObjects;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Dinner.Enums;
using HomeDine.Domain.Dinner.ValueObjects;
using HomeDine.Domain.Guest.ValueObjects;

namespace HomeDine.Domain.Dinner.Entities
{
    public class Reservation : Entity<ReservationId>
    {
        public int GuestCount { get; private set; }
        public ReservationStatus Status { get; private set; }

        public GuestId GuestId { get; private set; }
        public BillId? BillId { get; private set; }

        public DateTime? ArrivalDateTime { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Reservation(ReservationId id, GuestId guestId, int guestCount)
            : base(id)
        {
            GuestId = guestId;
            GuestCount = guestCount; // Should be >= 1
            Status = ReservationStatus.PendingGuestConfirmation; // Default initial status
        }

        internal static Reservation CreateNew(GuestId guestId, int guestCount)
        {
            ArgumentNullException.ThrowIfNull(guestId);
            if (guestCount < 1)
                throw new ArgumentOutOfRangeException(
                    nameof(guestCount),
                    "Guest count must be at least 1."
                );

            var reservationId = ReservationId.CreateUnique();
            var now = DateTime.UtcNow;

            return new Reservation(reservationId, guestId, guestCount)
            {
                CreatedDateTime = now,
                UpdatedDateTime = now,
            };
        }
    }
}
