using AskMeProgram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AskMeProgram.Configuration
{
    public  class UserConfiguration : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); 
            builder.Property(p => p.Name).HasMaxLength(50);
            builder.Property(p=>p.Email).HasMaxLength(100);
            builder.Property(p=>p.Password).HasMaxLength(100);  

        }
    }
}
