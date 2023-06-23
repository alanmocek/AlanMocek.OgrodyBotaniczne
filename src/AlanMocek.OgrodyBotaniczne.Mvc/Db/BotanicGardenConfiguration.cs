using AlanMocek.OgrodyBotaniczne.Mvc.Domain.BotanicGardenAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlanMocek.OgrodyBotaniczne.Mvc.Db
{
    public class BotanicGardenConfiguration : IEntityTypeConfiguration<BotanicGarden>
    {
        public void Configure(EntityTypeBuilder<BotanicGarden> builder)
        {
            builder.Property(x => x.Id);
            builder.Property(x => x.AllowedTripsPerDay);
            builder.Property(x => x.MinimumNumberOfPeople);
            builder.Property(x => x.NextTripNumber);
            builder.Property(x => x.NextZoneNumber);

            builder.OwnsMany(x => x.Trips, tripsBuilder =>
            {
                tripsBuilder.Property(trip => trip.Number);
                tripsBuilder.Property(trip => trip.NumberOfPeople);
                tripsBuilder.Property(trip => trip.Date);
                tripsBuilder.Property(trip => trip.Comment);

                tripsBuilder.OwnsMany(trip => trip.Zones, zoneBuilder =>
                {
                    zoneBuilder.Property(zone => zone.ZoneNumber);
                    zoneBuilder.Property(zone => zone.Comment);
                });
            });

            builder.OwnsMany(x => x.Zones, zoneBuilder =>
            {
                zoneBuilder.Property(x => x.Number);
                zoneBuilder.Property(x => x.Label);
                zoneBuilder.Property(x => x.PricePerPerson);
                zoneBuilder.Property(x => x.Discount);
            });

            builder.HasKey(x => x.Id);
        }
    }
}
