using System.Text.RegularExpressions;
using Humanizer;
using Microsoft.EntityFrameworkCore;

namespace SmartFlow_Platform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void UseSnakeCaseNamingConvention(this ModelBuilder builder)
    {
        foreach (var entity in builder.Model.GetEntityTypes())
        {
            // Set table names to snake_case and pluralized
            var tableName = entity.GetTableName();
            if (!string.IsNullOrEmpty(tableName))
                entity.SetTableName(tableName.ToPlural().ToSnakeCase());

            // Set column names to snake_case
            foreach (var property in entity.GetProperties())
            {
                var columnName = property.GetColumnName();
                if (!string.IsNullOrEmpty(columnName))
                    property.SetColumnName(columnName.ToSnakeCase());
            }

            // Set key names to snake_case
            foreach (var key in entity.GetKeys())
            {
                var keyName = key.GetName();
                if (!string.IsNullOrEmpty(keyName))
                    key.SetName(keyName.ToSnakeCase());
            }

            // Set foreign key constraint names to snake_case
            foreach (var foreignKey in entity.GetForeignKeys())
            {
                var foreignKeyName = foreignKey.GetConstraintName();
                if (!string.IsNullOrEmpty(foreignKeyName))
                    foreignKey.SetConstraintName(foreignKeyName.ToSnakeCase());
            }

            // Set index names to snake_case
            foreach (var index in entity.GetIndexes())
            {
                var indexDatabaseName = index.GetDatabaseName();
                if (!string.IsNullOrEmpty(indexDatabaseName))
                    index.SetDatabaseName(indexDatabaseName.ToSnakeCase());
            }
        }
    }
}
