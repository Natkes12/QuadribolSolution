using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAO.Mappings
{
    [Table("Usuarios")]
    internal class UsuarioMapConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(c => c.Nome).IsUnicode(false).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Senha).IsUnicode(false).IsRequired().HasMaxLength(15);

            builder.HasIndex(c => c.Email).IsUnique();
        }
    }
}
