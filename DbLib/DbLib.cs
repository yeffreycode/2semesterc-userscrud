using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class LibDb
    {
        int c;//cantidad
        int id = 0; //id de incremento
        string[] nombres;
        string[] apellidos;
        string[] emails;
        int[] dnis;
        int[] ids;

        public void pedirCantidad()
        {
            Console.Write("cuantos usuario desea registrar: ");
            c = int.Parse(Console.ReadLine());
            nombres = new string[c];
            apellidos = new string[c];
            dnis = new int[c];
            ids = new int[c];
            emails = new string[c];
        }
        //utils methods
        public void incrementarId()
        {
            id++;
        }
        public int generarDni()
        {
            int dni = 00000000;
            Random r = new Random();
            dni = r.Next(10000000, 100000000);
            while (buscarPorDni(dni) != -1)
            {
                dni = r.Next(10000000, 1000000000);
            }
            return dni;
        }
        public int buscarPorDni(int dni)
        {
            int index = -1;
            for (int i = 0; i < c; i++)
            {
                if (dnis[i] == dni)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int buscarPorId(int id)
        {
            int index = -1;
            for (int i = 0; i < c; i++)
            {
                if (ids[i] == id)
                {
                    index = ids[i];
                }
            }
            return index;
        }
        public string generarEmail(string n, string a, int dni)
        {
            return $"{n[0].ToString().ToLower()}{a[0].ToString().ToLower()}{dni}@mail.com";
        }
        public void crearUsuario(int i)
        {
            Console.WriteLine($"\n::registro de usuario {(i + 1)}");
            Console.Write("nombre: ");
            string n = Console.ReadLine();
            nombres[i] = n;
            Console.Write("apellido: ");
            string a = Console.ReadLine();
            apellidos[i] = a;
            dnis[i] = generarDni();
            emails[i] = generarEmail(nombres[i], apellidos[i], dnis[i]);
            ids[i] = id;
            incrementarId();
        }
        public void leerPorIndex(int i)
        {
            Console.WriteLine("\nId: " + ids[i]);
            Console.WriteLine("DNI: " + dnis[i]);
            Console.WriteLine("Email: " + emails[i]);
            Console.WriteLine("Nombre: " + nombres[i]);
            Console.WriteLine("Apellido: " + apellidos[i]);
        }
        //ordenar arrays de numeros
        public void cambiarOrdenNumeros(ref int[] arr, int i, int j)
        {
            int aux = arr[i];
            arr[i] = arr[j];
            arr[j] = aux;
        }
        public void cambiarOrdenStrings(ref string[] arr, int i, int j)
        {
            string aux = arr[i];
            arr[i] = arr[j];
            arr[j] = aux;
        }

        public void ordenarArrayDeNumerosAscendente(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[j] >= arr[j + 1])
                    {
                        cambiarOrdenNumeros(ref dnis, j, j + 1);
                        cambiarOrdenNumeros(ref ids, j, j + 1);
                        cambiarOrdenStrings(ref emails, j, j + 1);
                        cambiarOrdenStrings(ref nombres, j, j + 1);
                        cambiarOrdenStrings(ref apellidos, j, j + 1);
                    }
                }
            }
        }
        public void ordenarArrayDeNumerosDescendente(ref int[] arr)
        {
            ordenarArrayDeNumerosAscendente(ref arr);
            revertirOrdenUsuarios();
        }
        //algoritmo de ordenar strings
        public void ordenarArrayDeStringsAscendente(ref string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    int index = 1;
                    string str1 = index < arr[j].Length ? arr[j].Substring(0, index).ToLower() : arr[j].ToLower();
                    string str2 = index < arr[j + 1].Length ? arr[j + 1].Substring(0, index).ToLower() : arr[j + 1].ToLower();
                    int suma1 = sumarCaracteres(str1);
                    int suma2 = sumarCaracteres(str2);

                    while (suma1 == suma2 && index < arr[j + 1].Length)
                    {
                        index++;
                        str1 = index < arr[j].Length ? arr[j].Substring(0, index).ToLower() : arr[j].ToLower();
                        str2 = index < arr[j + 1].Length ? arr[j + 1].Substring(0, index).ToLower() : arr[j + 1].ToLower();
                        suma1 = sumarCaracteres(str1);
                        suma2 = sumarCaracteres(str2);
                    }
                    if (suma1 >= suma2)
                    {
                        cambiarOrdenNumeros(ref dnis, j, j + 1);
                        cambiarOrdenNumeros(ref ids, j, j + 1);
                        cambiarOrdenStrings(ref emails, j, j + 1);
                        cambiarOrdenStrings(ref nombres, j, j + 1);
                        cambiarOrdenStrings(ref apellidos, j, j + 1);
                    }
                }
            }
        }
        public void revertirOrdenUsuarios()
        {
            Array.Reverse(dnis);
            Array.Reverse(ids);
            Array.Reverse(emails);
            Array.Reverse(nombres);
            Array.Reverse(apellidos);
        }
        public void ordenarArrayDeStringsDescendente(ref string[] arr)
        {
            ordenarArrayDeStringsAscendente(ref arr);
            revertirOrdenUsuarios();
        }
        public int sumarCaracteres(string s)
        {
            int[] arrStr = s.ToCharArray().Select(a => a - '0').ToArray();
            int suma = arrStr.Sum();
            return suma;
        }
        //buscador
        public int[] buscadorDeStrings(string[] arr, string palabraBuscar)
        {
            int[] indices = new int[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (encontrarPalabra(arr[i], palabraBuscar))
                {
                    Array.Resize<int>(ref indices, indices.Length + 1);
                    indices[indices.Length - 1] = i;
                }
            }
            return indices;
        }
        public bool encontrarPalabra(string p, string pB)
        {
            p = p.ToLower();//palabra
            pB = pB.ToLower().Trim();
            int i = p.IndexOf(pB[0].ToString());
            if ((i == -1)) return false;
            string resto = p.Substring(i);
            string str = resto.Length > pB.Length ? resto.Substring(0, pB.Length) : resto;
            return str == pB;
        }
        //crud methods lib
        //registrar usuarios
        public void registrarUsuarios()
        {
            Console.WriteLine("registro de usuarios");
            for (int i = 0; i < c; i++)
            {
                crearUsuario(i);
            }
            Console.WriteLine("\nusuarios registrados exitosamente");
            Console.WriteLine("presione una tecla para continuar");
            Console.ReadKey();
            Console.Clear();
        }

        //read users
        public void leerUsuarios()
        {
            for (int i = 0; i < c; i++)
            {
                Console.WriteLine($"\n::user {(i + 1)}");
                leerPorIndex(i);
            }
        }

        //create new user
        public void registrarUsuario()
        {
            Array.Resize<int>(ref dnis, c + 1);
            Array.Resize<string>(ref nombres, c + 1);
            Array.Resize<string>(ref apellidos, c + 1);
            Array.Resize<string>(ref emails, c + 1);
            Array.Resize<int>(ref ids, c + 1);
            crearUsuario(c);
            c++;
            Console.WriteLine("usuario registrado exitosamente");
        }
        //update users by id
        public void actualizarUsuarioPorId()
        {
            Console.Write("ingresa el id: ");
            int i = buscarPorId(int.Parse(Console.ReadLine()));
            if (i == -1) { Console.WriteLine("usuario no encontrado para actualizar"); return; }
            Console.WriteLine("Id: " + ids[i]);
            Console.WriteLine("DNI: " + dnis[i]);
            Console.Write($"{nombres[i]}: Nuevo Nombre: ");
            nombres[i] = Console.ReadLine();
            Console.Write($"{apellidos[i]}: Nuevo Apellido: ");
            apellidos[i] = Console.ReadLine();
            emails[i] = generarEmail(nombres[i], apellidos[i], dnis[i]);
        }

        //read user by id.
        public void leerUsuarioPorId()
        {
            Console.Write("ingresa el id: ");
            int i = buscarPorId(int.Parse(Console.ReadLine()));
            if (i == -1) { Console.WriteLine("usuario no encontrado"); return; }
            leerPorIndex(i);
        }
        //ready user by dni
        public void leerUsuarioPorDni()
        {
            Console.Write("ingresa el dni: ");
            int i = buscarPorDni(int.Parse(Console.ReadLine()));
            if (i == -1) { Console.WriteLine("usuario no encontrado"); return; }
            leerPorIndex(i);
        }
        //eliminar
        public void eliminarUsuarioPorId()
        {
            Console.Write("ingresa el id para eliminar: ");

            int index = buscarPorId(int.Parse(Console.ReadLine()));
            if (index == -1) { Console.WriteLine("usuario no encontrado para eliminar"); return; }
            for (int i = index; i < c; i++)
            {
                dnis[i] = i < c - 1 ? dnis[i + 1] : dnis[i];
                ids[i] = i < c - 1 ? ids[i + 1] : ids[i];
                emails[i] = i < c - 1 ? emails[i + 1] : emails[i];
                nombres[i] = i < c - 1 ? nombres[i + 1] : nombres[i];
                apellidos[i] = i < c - 1 ? nombres[i + 1] : apellidos[i];
            }
            Array.Resize<int>(ref dnis, c - 1);
            Array.Resize<int>(ref ids, c - 1);
            Array.Resize<string>(ref nombres, c - 1);
            Array.Resize<string>(ref apellidos, c - 1);
            Array.Resize<string>(ref emails, c - 1);
            c--;
            Console.WriteLine("usuario eliminado correctamente");
        }
        //ordenar methods
        public void ordenarPorIdsAscendente()
        {
            ordenarArrayDeNumerosAscendente(ref ids);
            Console.WriteLine("ordenados por ids (ascendente)");
        }
        public void ordenarPorIdsDescendente()
        {
            ordenarArrayDeNumerosDescendente(ref ids);
            Console.WriteLine("ordenados por id (descendente)");
        }
        public void ordenarPorNombresAscendente()
        {
            ordenarArrayDeStringsAscendente(ref nombres);
            Console.WriteLine("ordenados por nombres (ascendente)");
        }
        public void ordenarPorNombresDescendente()
        {
            ordenarArrayDeStringsDescendente(ref nombres);
            Console.WriteLine("ordenados por nombres (descendente)");
        }
        public void buscarUsuariosPorNombre()
        {
            Console.Write("ingrese palabra para buscar: ");
            string palabra = Console.ReadLine();

            if (palabra.Length == 0)
            {
                leerUsuarios();
                return;
            }
            int[] indices = buscadorDeStrings(nombres, palabra);
            for (int i = 0; i < indices.Length; i++)
            {
                leerPorIndex(indices[i]);
            }

        }
    }
}
