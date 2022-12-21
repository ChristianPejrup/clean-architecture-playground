using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Infrastructure.Sql
{
    internal class AccountMap : IEntityTypeConfiguration<Domain.Account>
    {
        public void Configure(EntityTypeBuilder<Domain.Account> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
