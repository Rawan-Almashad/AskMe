using AskMeProgram.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace AskMeProgram.Configuration
{
    public class QuestionConfiguration:IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id)
            .ValueGeneratedOnAdd(); 
            builder.Property(x=>x.QuestionBody).HasMaxLength(200);
            builder.Property(x => x.QuestionAnswer).HasMaxLength(200);
            builder.Property(x => x.ToId).IsRequired();
            builder.HasOne(x => x.User).WithMany(x=>x.questions).HasForeignKey(x=>x.UserId);
        }
    }
}
