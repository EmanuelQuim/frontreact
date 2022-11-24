using System;

namespace miprueba.Models
{
    public class Cliente
    {
        public int DPI { get; set; }
        public string NOMBRES { get; set; }
        public string APELLIDOS { get; set; }
        public int TELEFONO { get; set; }
        public string EMAIL { get; set; }
        public int ID_CONTADOR { get; set; }
        public string NOMBRE_TIPO_CONTADOR { get; set; }
        public string TIPO_TARIFA { get; set; }
        public string DIRECCION_DESTINO { get; set; }
        public string NOMBRE_MUNICIPIO { get; set; }
        public string NOMBRE_DEPARTAMENTO { get; set; }
    }
}