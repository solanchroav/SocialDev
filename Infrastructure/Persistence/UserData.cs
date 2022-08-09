using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class UserData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.HasData(
            //    new User
            //    {
            //        Id = 1,
            //        Name = "John",
            //        Subject = "Maths"
            //    },

            //    new User
            //    {
            //        Id = 2,
            //        Name = "Femi",
            //        Subject = "English"
            //    });
        }
    }
}
