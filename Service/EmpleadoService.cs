using Model;
using NPoco;
using Persistence;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Service
{
    public class EmpleadoService
    {
        public static IEnumerable<Empleado> GetAllLinq()
        {
            var result = new List<Empleado>();

            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    result = db.Query<Empleado>().Include(x =>
                        x.Profesion
                    ).Where(x => x.Profesion_id == 2)
                    .OrderBy(x => x.FechaNacimiento)
                    .ToList();
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return result;
        }

        public static IEnumerable<Empleado> GetAll()
        {
            var result = new List<Empleado>();

            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    #region Select All
                    result = db.Fetch<Empleado>();
                    #endregion

                    #region Select especificando las columnas
                    //result =  db.Fetch<Empleado>("SELECT id, Nombre, Apellido FROM Empleado");
                    #endregion

                    #region Select con Where
                    //result = db.Fetch<Empleado>("SELECT * FROM Empleado WHERE Sexo = @0", 2);
                    #endregion

                    #region Select con Where directo, omitiendo el SELECT *
                    //result = db.Fetch<Empleado>("WHERE Sexo = @0", 2);
                    #endregion
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return result;
        }

        public static Empleado Get(int id = 0)
        {
            var result = new Empleado();

            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    if (id > 0)
                    {
                        result = db.SingleOrDefaultById<Empleado>(id);
                    }
                    else
                    {
                        result = db.FirstOrDefault<Empleado>("WHERE id IS NOT NULL");
                    }
                        
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return result;
        }

        public static Empleado GetWithRelation(int id)
        {
            var result = new Empleado();

            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    result = db.Query<Empleado>().Include(x => x.Profesion).Where(x => x.id == id).SingleOrDefault();

                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return result;
        }

        public static void Insert(Empleado model)
        {
            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    db.Insert(model);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public static void Update(Empleado model)
        {
            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    var originalModel = db.SingleById<Empleado>(model.id);

                    originalModel.Nombre = model.Nombre;
                    originalModel.Apellido = model.Apellido;
                    originalModel.Correo = model.Correo;

                    db.Update(originalModel);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }

        public static void Delete(int id)
        {
            try
            {
                using (IDatabase db = DbContext.GetInstance())
                {
                    db.Delete<Empleado>(id);
                }
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
        }
    }
}
