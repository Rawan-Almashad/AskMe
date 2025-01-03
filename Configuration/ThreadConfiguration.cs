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
    public  class ThreadConfiguration: IEntityTypeConfiguration<Threadd>
    {
        public void Configure(EntityTypeBuilder<Threadd> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
            builder.Property(x => x.ThreadBody).HasMaxLength(200);
            builder.Property(x => x.ThreadAnswer).HasMaxLength(200);
            builder.HasOne(x => x.Question).WithMany(x => x.threads).HasForeignKey(x => x.QuistionId);
        }
    }
}
