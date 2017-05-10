using NPoco;
using System;

namespace Model
{
    public class Empleado
    {
        public int id { get; set; }
        [Reference(
            ReferenceType.OneToOne,
            ColumnName = "Profesion_id",
            ReferenceMemberName = "id")
        ]
        public Profesion Profesion { get; set; }
        public int Profesion_id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public int Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public decimal Sueldo { get; set; }
    }
}
