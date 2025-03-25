using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowSpace.Core.Entities;

namespace WorkFlowSpace.infrastructure.Data.Config
{
    public class TasksConfigration : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.AssignedTo).HasColumnType("int");
            builder.Property(x => x.BeginDate).HasColumnType("DateTime");
            builder.Property(x => x.EndDate).HasColumnType("DateTime");
            builder.Property(x => x.Status).HasColumnType("int");

            //builder.HasData(
            //    new Tasks { Id = 1
            //        , Title = "Test 1"
            //        , Description = "Description 1"
            //        , AssignedTo = 2
            //        , BeginDate = new DateTime(2025, 3, 25)
            //        , EndDate = new DateTime(2025, 3, 25).AddDays(3)
            //        , Status = 2
            //        , TabId = 1},
            //    new Tasks { Id = 2
            //        , Title = "Test 2"
            //        , Description = "Description 2"
            //        , AssignedTo = 2
            //        , BeginDate = new DateTime(2025, 3, 25)
            //        , EndDate = new DateTime(2025, 3, 25).AddDays(3)
            //        , Status = 1
            //        , TabId = 3},
            //    new Tasks { Id = 3
            //        , Title = "Test 3"
            //        , Description = "Description 3"
            //        , AssignedTo = 2
            //        , BeginDate = new DateTime(2025, 3, 25)
            //        , EndDate = new DateTime(2025, 3, 25).AddDays(3)
            //        , Status = 1
            //        , TabId = 1}
            //);
        }
    }
}
