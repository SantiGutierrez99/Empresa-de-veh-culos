using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestObligatorioP2.Clases
{
    public abstract class BaseDeDatos
    {
        public static List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        public static List<Usuario> listaUsuarios = new List<Usuario>();
        public static List<Cliente> listaClientes = new List<Cliente>();
        public static List<Venta> listaVentas = new List<Venta>();
        public static List<Alquiler> listaAlquileres = new List<Alquiler>();
        public static Usuario usuarioLogeado;


        public static void CargarDatosIniciales()
        {
            Usuario usuario = new Usuario();
            usuario.setNombreUsuario("Admin");
            usuario.setContrasena("Admin");
            usuario.setVerAlquileres(true);
            usuario.setVerVentas(true);
            usuario.setVerClientes(true);
            usuario.setVerUsuarios(true);
            usuario.setVerVehiculos(true);

            listaUsuarios.Add(usuario);


            Cliente cliente = new Cliente { Apellido = "Nuñez", Cedula = "4586658-0", Direccion = "dr Edye 3456", Nombre = "Tobias", Telefono = "091641844"};
            Cliente cliente2 = new Cliente { Apellido = "Gutierrez", Cedula = "4589998-9", Direccion = "dr Edye 5585", Nombre = "Santiago", Telefono = "091794081"};
            Cliente cliente3 = new Cliente { Apellido = "Cardoso", Cedula = "3785468-2", Direccion = "Aigua 3588", Nombre = "Facundo", Telefono = "091463558" };
            Cliente cliente4 = new Cliente { Apellido = "Perez", Cedula = "5785468-2", Direccion = "Olaza 3588", Nombre = "Elias", Telefono = "091563958" };
            Cliente cliente5 = new Cliente { Apellido = "Araujo", Cedula = "5382468-1", Direccion = "Tomas Berreta 3588", Nombre = "Julieta", Telefono = "098564958" };
            Cliente cliente6 = new Cliente { Apellido = "De Leon", Cedula = "5445438-2", Direccion = "Carlos Cal 445", Nombre = "Martina", Telefono = "091564999" };
            Cliente cliente7 = new Cliente { Apellido = "Araujo", Cedula = "5775228-2", Direccion = "Montengro 123", Nombre = "Nacho", Telefono = "091564128" };

            listaClientes.Add(cliente);
            listaClientes.Add(cliente2);
            listaClientes.Add(cliente3);
            listaClientes.Add(cliente4);
            listaClientes.Add(cliente5);
            listaClientes.Add(cliente6);
            listaClientes.Add(cliente7);



            Auto vehiculo = new Auto { Marca = "Ferrari", Matricula = "MA458855", Modelo = "F40", PrecioVenta = 34000000, PrecioAlquilerDia = 400, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://cdn.motor1.com/images/mgl/vE9Av/s1/ten-things-you-didn-t-know-about-the-ferrari-f40.jpg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo2 = new Auto { Marca = "Chery", Matricula = "TG945884", Modelo = "TIGO", PrecioVenta = 95600, PrecioAlquilerDia = 180, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://3.bp.blogspot.com/-_YVzjX19uew/XGTGEb4rphI/AAAAAAAAShY/WgJArqv37JAET3tJd6mh7ld--JMNQ9LCACLcBGAs/s1600/Coao-Chery-Tiggo-7%2B%252825%2529.jpg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo3 = new Auto { Marca = "Fiat", Matricula = "FR46665", Modelo = "UNO", PrecioVenta = 8000, PrecioAlquilerDia = 50, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://auto-drive.pt/wp-content/uploads/2020/08/1996-Fiat-Uno-11.jpg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo4 = new Auto { Marca = "Lamborghini", Matricula = "GT45565", Modelo = "Murcielago", PrecioVenta = 200600, PrecioAlquilerDia = 300, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://img.remediosdigitales.com/561478/lamborghini-versace-2008-01/1366_2000.jpeg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo5 = new Auto { Marca = "Fiat", Matricula = "EG45565", Modelo = "Strada", PrecioVenta = 20588, PrecioAlquilerDia = 140, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://maiscar.com.br/wp-content/uploads/2023/09/ca28ba6c34ef4d3d9df4159fabcfb718_1693945796547.jpeg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo6 = new Auto { Marca = "Chevrolet", Matricula = "AG45565", Modelo = "Camaro", PrecioVenta = 180588, PrecioAlquilerDia = 220, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://i.pinimg.com/originals/59/66/9a/59669a54ab8bebb4dcb5c8afc5ae373a.jpg", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };
            Auto vehiculo7 = new Auto { Marca = "ByD", Matricula = "BTG5467", Modelo = "F0-1", PrecioVenta = 9500, PrecioAlquilerDia = 70, Activo = true, Imagen3 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Imagen1 = "https://http2.mlstatic.com/D_NQ_NP_895071-MLU72699131229_112023-O.webp", Imagen2 = "https://phantom-expansion.unidadeditorial.es/1f59a66b768009525bd78ad642177e2c/crop/55x0/770x477/resize/414/f/jpg/assets/multimedia/imagenes/2022/09/15/16632231996207.jpg", Tipo = "Auto" };

            listaVehiculos.Add(vehiculo);
            listaVehiculos.Add(vehiculo2);
            listaVehiculos.Add(vehiculo3);
            listaVehiculos.Add(vehiculo4);
            listaVehiculos.Add(vehiculo5);
            listaVehiculos.Add(vehiculo6);
            listaVehiculos.Add(vehiculo7);




        }

        public static List<Vehiculo> ListadoVehiculosActivos()
        {
            List<Vehiculo> vehiculosActivos = new List<Vehiculo>();
            foreach (var vehiculo in listaVehiculos)
            {
                if (vehiculo.Activo)
                    vehiculosActivos.Add(vehiculo);
            }
            return vehiculosActivos;
        }

        public static void GuardarUsuarioLogeado(Usuario usuario)
        {
            usuarioLogeado = usuario;
        }
        public static List<Cliente> ObtenerListaClientes()
        {
            // Simplemente retornar la lista de alquileres
            return listaClientes;
        }

        public static List<Alquiler> ObtenerListaAlquileres()
        {
            // Simplemente retornar la lista de alquileres
            return listaAlquileres;
        }

        public static List<Vehiculo> ObtenerListaVehiculos()
        {
            // Simplemente retornar la lista de alquileres
            return listaVehiculos;
        }
    }

}

