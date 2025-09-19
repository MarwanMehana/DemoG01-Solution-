using DemoG01.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DemoG01.DataAccess.Data.Configurations
{
    internal class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
        public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(D => D.CreatedOn).HasDefaultValueSql("GetDate()");
        builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("GetDate()");
    }
    }
}
