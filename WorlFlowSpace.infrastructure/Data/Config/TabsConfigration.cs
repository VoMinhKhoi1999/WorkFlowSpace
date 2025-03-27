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
    class TabsConfigration : IEntityTypeConfiguration<Tabs>
    {
        public void Configure(EntityTypeBuilder<Tabs> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.CreateBy).HasColumnType("int");
            builder.Property(x => x.CreateAt).HasColumnType("DateTime");
            builder.Property(x => x.ModifiDate).HasColumnType("DateTime");

            //builder.HasData(
            //    new Tabs { Id = 1
            //        , Name = "Các chức năng quản lý"
            //        , CreateBy = 1
            //        , CreateAt = new DateTime(2025, 3, 25)
            //        , GroupId = 1 },
            //    new Tabs { Id = 3
            //        , Name = "Quản lý dữ liệu"
            //        , CreateBy = 1
            //        , CreateAt = new DateTime(2025, 3, 25)
            //        , GroupId = 1 },
            //    new Tabs { Id = 2
            //        , Name = "Sự kiện lễ hội"
            //        , CreateBy = 1
            //        , CreateAt = new DateTime(2025, 3, 25)
            //        , GroupId = 2 },
            //    new Tabs { Id = 4
            //        , Name = "Chuẩn bị lễ hội"
            //        , CreateBy = 1
            //        , CreateAt = new DateTime(2025, 3, 25)
            //        , GroupId = 2 },
            //    new Tabs { Id = 5
            //        , Name = "Dựng lễ hội"
            //        , CreateBy = 1
            //        , CreateAt = new DateTime(2025, 3, 25)
            //        , GroupId = 2 }
            //);
        }
    }
}
