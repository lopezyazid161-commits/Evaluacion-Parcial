using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_Parcial
{
    internal class Program
    {
        const int MAX_EXPEDIENTES = 100;
        static string[] codigos = new string[MAX_EXPEDIENTES];
        static string[] dnis = new string[MAX_EXPEDIENTES];
        static string[] nombres = new string[MAX_EXPEDIENTES];
        static int cantidad = 0;

        static void Main(string[] args)
        {
            string opcion = "";
            while (opcion != "5")
            {
                Console.WriteLine("\n==========================================");
                Console.WriteLine(" MESA DE PARTES - POSTA MÉDICA SANTA LUZMILA");
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Registrar nuevo expediente");
                Console.WriteLine("2. Buscar expediente por código");
                Console.WriteLine("3. Ordenar expedientes por código");
                Console.WriteLine("4. Mostrar todos los expedientes");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opción (1-5): ");
                opcion = Console.ReadLine()?.Trim();
                switch (opcion)
                {
                    case "1":
                        RegistrarExpediente();
                        break;
                    case "2":
                        BuscarExpediente();
                        break;
                    case "3":
                        OrdenarExpedientes();
                        break;
                    case "4":
                        MostrarExpedientes();
                        break;
                    case "5":
                        Console.WriteLine("\nSaliendo del sistema...");
                        break;
                    default:
                        Console.WriteLine("[Error] Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }
        static bool ValidarDni(string dni)
        {
            if (string.IsNullOrEmpty(dni) || dni.Length != 8)
            {
                return false;
            }
            foreach (char c in dni)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        static void RegistrarExpediente()
        {
            if (cantidad >= MAX_EXPEDIENTES)
            {
                Console.WriteLine("\n[Error] El sistema ha alcanzado su límite de registros.");
                return;
            }
            Console.WriteLine("\n--- REGISTRO DE EXPEDIENTE ---");
            string codigo = $"EXP-{(cantidad + 1):D3}";
            Console.Write("Ingrese el DNI del paciente (8 dígitos): ");
            string dni = Console.ReadLine()?.Trim();
            while (!ValidarDni(dni))
            {
                Console.WriteLine("[Error] DNI inválido. Debe contener exactamente 8 números.");
                Console.Write("Ingrese el DNI del paciente nuevamente: ");
                dni = Console.ReadLine()?.Trim();
            }
            Console.Write("Ingrese nombres y apellidos del paciente: ");
            string nombre = Console.ReadLine()?.Trim();
            codigos[cantidad] = codigo;
            dnis[cantidad] = dni;
            nombres[cantidad] = nombre;
            cantidad++;
            Console.WriteLine($"\n[Éxito] Expediente {codigo} registrado correctamente.");
        }
        static void BuscarExpediente()
        {
            Console.WriteLine("\n--- BÚSQUEDA DE EXPEDIENTE ---");
            Console.Write("Ingrese el código del expediente a buscar (ej. EXP-001): ");
            string codigoBuscado = Console.ReadLine()?.Trim();
            bool hallado = false;
            for (int i = 0; i < cantidad; i++)
            {
                if (codigos[i].Equals(codigoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\nExpediente Encontrado:");
                    Console.WriteLine($"Código: {codigos[i]} | DNI: {dnis[i]} | Paciente: {nombres[i]}");
                    hallado = true;
                    break;
                }
            }
            if (!hallado)
            {
                Console.WriteLine("\n[Aviso] No se encontró ningún expediente con el código ingresado.");
            }
        }
        static void OrdenarExpedientes()
        {
            if (cantidad < 2)
            {
                Console.WriteLine("\n[Aviso] Se requieren al menos 2 expedientes para ordenar.");
                return;
            }
            for (int i = 0; i < cantidad - 1; i++)
            {
                for (int j = 0; j < cantidad - i - 1; j++)
                {
                    if (string.Compare(codigos[j], codigos[j + 1], StringComparison.Ordinal) > 0)
                    {
                        string tempCod = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCod;
                        string tempDni = dnis[j];
                        dnis[j] = dnis[j + 1];
                        dnis[j + 1] = tempDni;
                        string tempNom = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = tempNom;
                    }
                }
            }
            Console.WriteLine("\n[Éxito] Expedientes ordenados exitosamente por código.");
        }
        static void MostrarExpedientes()
        {
            Console.WriteLine("\n--- LISTADO GENERAL DE EXPEDIENTES ---");
            if (cantidad == 0)
            {
                Console.WriteLine("No hay expedientes registrados.");
                return;
            }
            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"[{i + 1}] Código: {codigos[i]} | DNI: {dnis[i]} | Paciente: {nombres[i]}");
            }
        }



    }

}
