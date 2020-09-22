using Microsoft.EntityFrameworkCore;
using RegistroEstudiante.DAL;
using RegistroEstudiante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroEstudiante.BLL
{
    public class EstudiantesBLL
    {

        public static bool Guardar(Estudiantes estudiante)
        {
            if (!Existe(estudiante.EstudianteID))
                return Insertar(estudiante);
            else
                return Modificar(estudiante);
        }

        private static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.estudiantes.Any(d => d.EstudianteID == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        private static bool Insertar(Estudiantes estudiante)
        {
            Contexto contexto = new Contexto();
            bool paso = false;

            try
            {
                contexto.estudiantes.Add(estudiante);
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Estudiantes estudiante)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            
            try
            {
                contexto.Entry(estudiante).State = EntityState.Modified;
                paso = (contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Estudiantes Buscar(int id)
        {

            Estudiantes estudiantes;
            Contexto contexto = new Contexto();

            try
            {
                estudiantes = contexto.estudiantes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return estudiantes;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto _contexto = new Contexto();

            try
            {
                var eliminar = _contexto.estudiantes.Find(id);
                _contexto.Entry(eliminar).State = EntityState.Deleted;

                paso = (_contexto.SaveChanges() > 0);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }

    }
}
