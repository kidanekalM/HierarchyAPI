using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace HierarchyAPI.Models.Config
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        //do camel case
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role_Table");
            builder.Property(r => r.Description).HasColumnType("text");
            builder.Property(r => r.Description).HasDefaultValue("Description is not set... ");
            builder.Property(r=>r.Name).IsRequired();
        }
    }
}
/*
 * 

1. **Model Configuration**:
   - `HasDbFunction()`: Configures a database function when targeting a relational database.
   - `HasDefaultSchema()`: Specifies the database schema.
   - `HasAnnotation()`: Adds or updates data annotation attributes on the entity.
   - `HasSequence()`: Configures a database sequence when targeting a relational database.

2. **Entity Configuration**:
   - `HasAlternateKey()`: Configures an alternate key in the EF model for the entity.
   - `HasIndex()`: Configures an index of specified properties.
   - `HasKey()`: Configures the property or list of properties as the primary key.
   - `HasMany()`: Configures the "Many" part of the relationship (one-to-many or many-to-many).
   - `HasOne()`: Configures the "One" part of the relationship (one-to-one or one-to-many).
   - `Ignore()`: Excludes a class or property from mapping to a table or column.
   - `OwnsOne()`: Configures a relationship where the target entity is owned by this entity.
   - `ToTable()`: Specifies the database table that the entity maps to.
   - HasColumnType()
   - HasColumnName()

3. **Property Configuration**:
   - `HasColumnName()`: Configures the corresponding column name in the database for the property.
   - `HasColumnType()`: Configures the data type of the corresponding column in the database.
   - `HasComputedColumnSql()`: Maps the property to a computed column in the database.
   - `HasDefaultValue()`: Sets the default value for the column.
   - `HasDefaultValueSql()`: Specifies a default value expression.
   - `HasField()`: Specifies the backing field for a property.

**Example**:
Suppose we have an `Author` entity with properties like `Id`, `Name`, and `BirthDate`. We can configure it using Fluent API like this:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Author>()
        .ToTable("Authors")
        .HasKey(a => a.Id)
        .Property(a => a.Name)
        .HasColumnName("AuthorName")
        .IsRequired()
        .HasMaxLength(100);

    // Other configurations...
}
```

In this example, we set the table name, primary key, column name, and other property-specific settings for the `Author` entity. Remember to override the `OnModelCreating` method in your `DbContext` class to apply these configurations.

For more details, you can refer to the [Entity Framework Core Fluent API documentation](https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx)¹. 😊

Source: Conversation with Copilot, 7/5/2024
(1) Fluent API in Entity Framework Core. https://www.entityframeworktutorial.net/efcore/fluent-api-in-entity-framework-core.aspx.
(2) Fluent API in Entity Framework Core - Dot Net Tutorials. https://dotnettutorials.net/lesson/fluent-api-in-entity-framework-core/.
(3) Entity Framework Core Fluent API - TekTutorialsHub. https://www.tektutorialshub.com/entity-framework-core/ef-core-fluent-api/.

 */