using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeDine.Domain.Bill.ValueObjects;
using HomeDine.Domain.Common.Models;
using HomeDine.Domain.Dinner.ValueObjects;
using HomeDine.Domain.Guest.ValueObjects;
using HomeDine.Domain.Host.ValueObjects;

namespace HomeDine.Domain.Bill
{
    public sealed class Bill : AggregateRoot<BillId>
    {
        public DinnerId DinnerId { get; private set; }
        public GuestId GuestId { get; private set; }
        public HostId HostId { get; private set; }
        public Price Price { get; private set; }

        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

        private Bill(
            BillId id,
            DinnerId dinnerId,
            GuestId guestId,
            HostId hostId,
            Price price,
            DateTime createdDateTime,
            DateTime updatedDateTime
        )
            : base(id)
        {
            DinnerId = dinnerId;
            GuestId = guestId;
            HostId = hostId;
            Price = price;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Bill Create(DinnerId dinnerId, GuestId guestId, HostId hostId, Price price)
        {
            ArgumentNullException.ThrowIfNull(dinnerId);
            ArgumentNullException.ThrowIfNull(guestId);
            ArgumentNullException.ThrowIfNull(hostId);
            ArgumentNullException.ThrowIfNull(price);

            return new Bill(
                BillId.CreateUnique(),
                dinnerId,
                guestId,
                hostId,
                price,
                DateTime.UtcNow,
                DateTime.UtcNow
            );
        }
    }
}
