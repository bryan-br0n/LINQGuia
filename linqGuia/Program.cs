﻿// See https://aka.ms/new-console-template for more information
using linqGuia;

Console.WriteLine("Hello, World!");

//LinQ

#region ListaModelos

List<Casa> listaCasas = new List<Casa>();
List<Habitante> listaHabitante = new List<Habitante>();

#endregion

#region Casa

// Clase anónima - No se puede escribir sobre ella, son de solo lectura.
listaCasas.Add(new Casa
{
    IdCasa = 1,
    Direccion = "3 avn Chalatenango",
    Ciudad = "Chalatenango",
    numeroHabitaciones = 20
});

listaCasas.Add(new Casa
{
    IdCasa = 2,
    Direccion = "4 av",
    Ciudad = "San Salvador",
    numeroHabitaciones = 9
});

listaCasas.Add(new Casa
{
    IdCasa = 3,
    Direccion = "6 avn",
    Ciudad = "San Miguel",
    numeroHabitaciones = 5
});

#endregion

#region Habitante

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Elena",
    Edad = 25,
    IdCasa = 1
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Carlos",
    Edad = 20,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Alfredo",
    Edad = 30,
    IdCasa = 3
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Luis",
    Edad = 50,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Sonia",
    Edad = 18,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Elmer",
    Edad = 36,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Miguel",
    Edad = 45,
    IdCasa = 2
});

listaHabitante.Add(new Habitante
{
    IdHabitante = 1,
    Nombre = "Olga",
    Edad = 15,
    IdCasa = 2
});

#endregion

#region SentenciaLinQ

// Nos permite tener un elemento sobre el que iteraremos 
IEnumerable<Habitante> listaEdad = from objTemporal in listaHabitante
                                   where objTemporal.Edad > 40 
                                   select objTemporal;

// foreach no afecta al elemento recorrido
foreach(var iteracion in listaEdad)
{
    Console.WriteLine(iteracion.datosHabitante());
}

// JOIN
IEnumerable<Habitante> listaCasaGothan = from objTemporalHabitante in listaHabitante
                                   join objTemporalCasa in listaCasas
                                   on objTemporalHabitante.IdHabitante equals objTemporalCasa.IdCasa
                                   where objTemporalCasa.Ciudad == "Chalatenango"
                                   select objTemporalHabitante;
Console.WriteLine("----------------------------------------------------------------------------------------------");
foreach (Habitante h in listaCasaGothan)
{
    Console.WriteLine(h.datosHabitante());
}



#endregion

#region FirsthAndFirsthOrDefault
Console.WriteLine("----------------------------------------------------------------------------------------------");
var primeraCasa = listaCasas.First(); //esto no es linQ es  una fucnin de los Ienumarable
Console.WriteLine(primeraCasa.dameDatosCasa());

//aplicando una restriccion sin restricion lambda
Habitante personaEdad = (from variableTemporalHabitante in listaHabitante where variableTemporalHabitante.Edad > 25 select variableTemporalHabitante).First();
Console.WriteLine(personaEdad.datosHabitante());
Console.WriteLine("---------------------------Lo mismo pero con lambdas---------------------------------------------------------");
var Habitante1 = listaHabitante.First(objectTemp => objectTemp.Edad > 25);
Console.WriteLine(Habitante1.datosHabitante());

// Si no tenemos el elemento que buscamos entonces la consulta devolvera una exepcion esto detendra el codigo en su totalidad

//Casa EdadError = (from vCasaTemp in ListaCasas where vCasaTemp.Id >10 select vCasaTemp).First() ;
//Console.WriteLine(EdadError.dameDatosCasa());

Casa CasaConFirsthOrDedault = listaCasas.FirstOrDefault(vCasa => vCasa.Id > 200);
if (CasaConFirsthOrDedault == null)
{
    Console.WriteLine("No existe !No hay!");
    return;
}
Console.WriteLine("existe !Si existe!");

#endregion