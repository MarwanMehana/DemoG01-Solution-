using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoG01.DataAccess.Data.Configurations
{
    internal interface IBaseEntityConfigurations<TEntity>
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}