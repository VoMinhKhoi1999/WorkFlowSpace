using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Entities;

namespace WorkFlowSpace.infrastructure.Data.Config
{
    public class GroupsConfigration : IEntityTypeConfiguration<Groups>
    {
        public void Configure(EntityTypeBuilder<Groups> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.CreateBy).HasColumnType("int");
            builder.Property(x => x.CreateAt).HasColumnType("DateTime");

            //builder.HasData(
            //    new Groups { Id = 1, Name = "Dự án", CreateBy = 1, CreateAt = new DateTime(2025, 3, 25) },
            //    new Groups { Id = 2, Name = "Sự kiện", CreateBy = 1, CreateAt = new DateTime(2025, 3, 25) }
            //    );
        }
    }
}
