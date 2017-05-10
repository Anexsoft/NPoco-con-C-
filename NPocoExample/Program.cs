using Model;
using Service;
using System;

namespace NPocoExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Get All Example
            //foreach (var e in EmpleadoService.GetAll())
            //{
            //    Console.WriteLine(
            //        Template(e)
            //    );
            //}
            #endregion

            #region FirstOrDefault
            //Console.WriteLine(
            //    Template(EmpleadoService.Get(50))
            //);
            #endregion

            #region Insert
            //EmpleadoService.Insert(new Empleado {
            //    Nombre = "Eduardo",
            //    Apellido = "Rodríguez Patiño",
            //    Correo = "eduardo@anexsoft.com",
            //    FechaNacimiento = DateTime.Now.AddYears(-28),
            //    FechaRegistro = DateTime.Now,
            //    Profesion_id = 1,
            //    Sueldo = 8000,
            //    Sexo = 1
            //});
            #endregion

            #region Update
            //EmpleadoService.Update(new Empleado
            //{
            //    id = 508,
            //    Nombre = "Jose",
            //    Apellido = "Peralta Patiño",
            //    Correo = "jose@anexsoft.com"
            //});
            #endregion

            #region Delete
            //EmpleadoService.Delete(504);
            #endregion

            #region Get With Relationship
            Console.Write(
                Template(EmpleadoService.GetWithRelation(1))
            );
            #endregion

            #region LinqQuery
            foreach (var e in EmpleadoService.GetAllLinq())
            {
                Console.WriteLine(
                    Template(e)
                );
            }
            #endregion

            Console.Read();
        }
    
        static string Template(Empleado e)
        {
            var messageTemplate = "{0} | {1} | {2} | {3} | {4}";

            return string.Format(messageTemplate,
                e.Apellido + ", " + e.Nombre,
                e.Correo,
                e.Sexo,
                e.FechaNacimiento,
                e.Sueldo
            );
        }
    }
}
