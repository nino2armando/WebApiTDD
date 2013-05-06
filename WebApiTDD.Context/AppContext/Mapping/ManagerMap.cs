using System.Data.Entity.ModelConfiguration;
using WebApiTDD.Domain.Models;

namespace WebApiTDD.Context.AppContext.Mapping
{
    public class ManagerMap : EntityTypeConfiguration<Manager>
    {
        public ManagerMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Managers");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Department_Id).HasColumnName("Department_Id");

            // Relationships
            this.HasOptional(t => t.Department)
                .WithMany(t => t.Managers)
                .HasForeignKey(d => d.Department_Id);

        }
    }
}
