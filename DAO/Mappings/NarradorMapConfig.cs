using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAO.Mappings
{
    [Table("NARRADORES")]
    internal class NarradorMapConfig : IEntityTypeConfiguration<Narrador>
    {
        public void Configure(EntityTypeBuilder<Narrador> builder)
        {
            builder.Property(c => c.Nome).IsUnicode(false).IsRequired().HasMaxLength(50);
        }
    }
}
