using Dominio.Actores;
using Dominio.Genericos;
using Dominio.Paises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Personas
{
    public class Persona<TID> : EntidadGenerica<TID>
        where TID : IIdGenerico
    {
        public string Nombre { get; private set; } = string.Empty;
        public string Apellido { get; private set; } = string.Empty;
        public IdPais IdPais { get; private set; } = default!;


        public Persona()
        {
        }

        public Persona(TID id, string nombre, string apellido, IdPais idPais)
            : base(id)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            IdPais = idPais ?? throw new ArgumentNullException(nameof(idPais));
        }

        public void Actualizar(string nombre, string apellido, IdPais idPais)
        {
            Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
            Apellido = apellido ?? throw new ArgumentNullException(nameof(apellido));
            IdPais = idPais ?? throw new ArgumentNullException(nameof(idPais));
            FechaDeActualizacion = DateTime.Now;
        }
    }
}
