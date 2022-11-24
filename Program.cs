using Libreria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ef_practica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibDb db = new LibDb();
            db.pedirCantidad();
            db.registrarUsuarios();
            menu(db);

            //final del programa 
            Console.WriteLine("final: presione una tecla para continuar.");
            Console.ReadKey();
        }
        static void menu(LibDb db)
        {
            Console.Clear();
            bool salirDelMenu = false;
            while (!salirDelMenu)
            {
                int op;
                Console.WriteLine(":::::Menu::::::");
                Console.WriteLine("[1] Leer usuarios.");
                Console.WriteLine("[2] Crear Usuario.");
                Console.WriteLine("[3] Actualizar usuario Usuario por Id.");
                Console.WriteLine("[4] Buscar usuario por dni.");
                Console.WriteLine("[5] Buscar usuario por id.");
                Console.WriteLine("[6] Eliminar usuario por id.");
                Console.WriteLine("[7] Ordenar usuarios");
                Console.WriteLine("[8] buscador por nombre");
                Console.WriteLine("[0] Salir");
                Console.Write("ingrese una opcion: ");
                op = int.Parse(Console.ReadLine());
                accionesAlgoritmo(op, ref salirDelMenu, db);
            }
        }
        static void menuOrdenar(LibDb db)
        {
            Console.Clear();
            bool salirDelMenu = false;
            while (!salirDelMenu)
            {
                int op;
                Console.WriteLine("[1] ordenar por id (ascendente).");
                Console.WriteLine("[2] ordenar por id (descendente).");
                Console.WriteLine("[3] ordenar por nombre (ascendente).");
                Console.WriteLine("[4] ordenar por nombre (descendente).");
                Console.WriteLine("[5] leer usuarios.");
                Console.WriteLine("[0] volver al menu principal");
                Console.Write("ingrese una opcion: ");
                op = int.Parse(Console.ReadLine());
                accionesOrdenar(op, ref salirDelMenu, db);
            }
        }
        static void accionesAlgoritmo(int op, ref bool salir, LibDb db)
        {
            switch (op)
            {
                case 0:
                    Console.Clear();
                    salir = true;
                    break;
                case 1:
                    Console.Clear();
                    db.leerUsuarios();
                    continuarMenu();
                    break;
                case 2:
                    Console.Clear();
                    db.registrarUsuario();
                    continuarMenu();
                    break;
                case 3:
                    Console.Clear();
                    db.actualizarUsuarioPorId();
                    continuarMenu();
                    break;
                case 4:
                    Console.Clear();
                    db.leerUsuarioPorDni();
                    continuarMenu();
                    break;
                case 5:
                    Console.Clear();
                    db.leerUsuarioPorId();
                    continuarMenu();
                    break;
                case 6:
                    Console.Clear();
                    db.eliminarUsuarioPorId();
                    continuarMenu();
                    break;
                case 7:
                    Console.Clear();
                    menuOrdenar(db);
                    break;
                case 8:
                    Console.Clear();
                    db.buscarUsuariosPorNombre();
                    continuarMenu();
                    break;
                case 9:
                    Console.Clear();
                    Console.WriteLine("wilser".Substring(0, 1));
                    //Console.WriteLine(db.encontrarPalabra("wilser", "e") ? "si" : "no");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("campo ingressado no valido");
                    continuarMenu();
                    break;
            }
        }
        static void accionesOrdenar(int op, ref bool salir, LibDb db)
        {
            switch (op)
            {
                case 0:
                    Console.Clear();
                    salir = true;
                    break;
                case 1:
                    Console.Clear();
                    db.ordenarPorIdsAscendente();
                    continuarMenu();
                    break;
                case 2:
                    Console.Clear();
                    db.ordenarPorIdsDescendente();
                    continuarMenu();
                    break;
                case 3:
                    Console.Clear();
                    db.ordenarPorNombresAscendente();
                    continuarMenu();
                    break;
                case 4:
                    Console.Clear();
                    db.ordenarPorNombresDescendente();
                    continuarMenu();
                    break;
                case 5:
                    Console.Clear();
                    db.leerUsuarios();
                    continuarMenu();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("campo ingresado no valido");
                    continuarMenu();
                    break;
            }
        }
        static void continuarMenu()
        {
            Console.WriteLine("\npresione una tecla para volver al menu");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
