using System.Data.Entity.ModelConfiguration;
using WebApiTDD.Domain.Models;

namespace WebApiTDD.AppContext.Mapping
{
    public class CollarboratorMap : EntityTypeConfiguration<Collarborator>
    {
        public CollarboratorMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Collarborators");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Manager_Id).HasColumnName("Manager_Id");
            this.Property(t => t.Department_Id).HasColumnName("Department_Id");

            // Relationships
            this.HasOptional(t => t.Department)
                .WithMany(t => t.Collarborators)
                .HasForeignKey(d => d.Department_Id);
            this.HasOptional(t => t.Manager)
                .WithMany(t => t.Collarborators)
                .HasForeignKey(d => d.Manager_Id);

        }
    }
}
