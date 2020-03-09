using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAO.Mappings
{
    [Table("COMPETIDORES")]
    internal class CompetidorMapConfig : IEntityTypeConfiguration<Competidor>
    {
        public void Configure(EntityTypeBuilder<Competidor> builder)
        {
            builder.Property(c => c.Nome).HasMaxLength(50).IsRequired().IsUnicode(false);

            builder.Property(c => c.Escolaridade).IsRequired().IsUnicode(false).HasMaxLength(1);
        }
    }
}
