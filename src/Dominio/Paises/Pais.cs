using Dominio.Genericos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Paises
{
    public sealed class Pais : EntidadGenerica<IdPais>
    {
        public string Nombre { get; private set; } = string.Empty;

        public Pais()
        {
        }

        public Pais(IdPais id, string nombre) : base(id)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        public void Actualizar(string nombre)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
