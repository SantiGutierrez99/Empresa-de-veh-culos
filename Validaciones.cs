using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestObligatorioP2.Clases;

namespace TestObligatorioP2.Clases
{
    public class Validaciones
    {
        public static bool ValidarCedula(string cedula)
        {
            // Puedes agregar lógica de validación específica para la cédula si es necesario
            // En este ejemplo, simplemente verifica si la cadena no está vacía
            return !string.IsNullOrEmpty(cedula);
        }

        public static bool ValidarMatricula(string matricula)
        {
            // Puedes agregar lógica de validación específica para la matrícula si es necesario
            // En este ejemplo, simplemente verifica si la cadena no está vacía
            return !string.IsNullOrEmpty(matricula);
        }

        public static bool ValidarFecha(string fecha, out DateTime fechaValidada)
        {
            fechaValidada = DateTime.MinValue;

            try
            {
                fechaValidada = DateTime.Parse(fecha);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool ValidarPrecio(string precio, out int precioValidado)
        {
            precioValidado = 0;

            try
            {
                precioValidado = Convert.ToInt32(precio);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}

