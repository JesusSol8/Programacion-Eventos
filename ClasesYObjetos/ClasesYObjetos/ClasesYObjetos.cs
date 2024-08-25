using System;
using System.IO;
using System.Collections.Generic;

class Persona
{
    public string Nombre { get; set; }
    public int Edad { get; set; }

    public Persona(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}");
    }

    public string Serializar()
    {
        return $"{Nombre},{Edad}";
    }

    public static Persona Deserializar(string linea)
    {
        var datos = linea.Split(',');
        return new Persona(datos[0], int.Parse(datos[1]));
    }
}

class Estudiante : Persona
{
    public string Matricula { get; set; }

    public Estudiante(string nombre, int edad, string matricula) : base(nombre, edad)
    {
        Matricula = matricula;
    }

    public new void MostrarInfo()
    {
        Console.WriteLine($"Nombre: {Nombre}, Edad: {Edad}, Matricula: {Matricula}");
    }

    public new string Serializar()
    {
        return $"{Nombre},{Edad},{Matricula}";
    }

    public static new Estudiante Deserializar(string linea)
    {
        var datos = linea.Split(',');
        return new Estudiante(datos[0], int.Parse(datos[1]), datos[2]);
    }
}

class Program
{
    static string filePath = "datos.txt";

    static void Main()
    {
        List<Persona> personas = new List<Persona>();

        // Cargar datos desde el archivo
        if (File.Exists(filePath))
        {
            foreach (var linea in File.ReadAllLines(filePath))
            {
                if (linea.Split(',').Length == 3)
                {
                    personas.Add(Estudiante.Deserializar(linea));
                }
                else
                {
                    personas.Add(Persona.Deserializar(linea));
                }
            }
        }

        // Mostrar datos cargados
        personas.ForEach(p => p.MostrarInfo());

        // Agregar nuevas personas
        personas.Add(new Persona("Erick", 14));
        personas.Add(new Persona("Aurelio", 53));
        personas.Add(new Estudiante("Jesus", 18, "JD2610"));

        // Guardar datos en el archivo
        File.WriteAllLines(filePath, personas.ConvertAll(p => p.Serializar()));

        Console.WriteLine("Datos guardados en el archivo.");
    }
}
