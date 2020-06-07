using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroDisco.Entidades
{
    public class Discos
    {
        [Key]
        public int IdDisco { get; set; }
        public string Nombre { get; set; }
        public int CantidadCanciones { get; set; }
        public DateTime FechaLanzamiento { get; set; } = DateTime.Now;
        public string Artista { get; set; }

    }
}
