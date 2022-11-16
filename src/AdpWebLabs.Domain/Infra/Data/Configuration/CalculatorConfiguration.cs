using AdpWebLabs.Domain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdpWebLabs.Domain.Infra.Data.Configuration
{
    public class CalculatorConfiguration : IEntityTypeConfiguration<Calculator>
    {
        public void Configure(EntityTypeBuilder<Calculator> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
