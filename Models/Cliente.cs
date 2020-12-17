using System.Collections;

namespace TestConsoleTrabajo.Models
{
    class Cliente
    {
        public string nombres { get; set; }

        public string apellidos { get; set; }

        public string direccion { get; set; }

        public ArrayList telefono { get; set; }

        public string fechaIngreso { get; set; }

        public string antiguedad { get; set; }

        public string categoriaCliente { get; set; }

        public Ventas ventas { get; set; }
    }
}


