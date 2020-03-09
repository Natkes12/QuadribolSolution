using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAO.Mappings
{
    [Table("JOGOS")]
    internal class JogoMapConfig : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.Property(c => c.DataJogo).IsUnicode(false).IsRequired();
        }
    }
}
