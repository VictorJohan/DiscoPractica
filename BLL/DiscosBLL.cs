using Microsoft.EntityFrameworkCore;
using RegistroDisco.DAL;
using RegistroDisco.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RegistroDisco.BLL
{
    public class DiscosBLL
    {
        public static bool Guardar(Discos disco)
        {
            if (!Existe(disco.IdDisco))
            {
                return Insertar(disco);
            }
            else
            {
                return Modificar(disco);
            }
        }

        public static bool Existe(int id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                ok = contexto.Discos.Any(e => e.IdDisco == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Insertar(Discos disco)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Discos.Add(disco);
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        private static bool Modificar(Discos disco)
        {
            bool ok = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(disco).State = EntityState.Modified;
                ok = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static bool Eliminar(int id)
        {
            bool ok = false;
            Contexto contexto = new Contexto();
            

            try
            {
                var disco = contexto.Discos.Find(id);
                if(disco != null)
                {
                    contexto.Discos.Remove(disco);
                    ok = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ok;
        }

        public static Discos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Discos disco;

            try
            {
                disco = contexto.Discos.Find(id);
               
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return disco;
        }
    }
}
