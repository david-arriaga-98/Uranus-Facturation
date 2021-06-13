using ProyectoPuntoNet.DataAccess.Models;
using System;
using System.IO;

namespace ProyectoPuntoNet.DataAccess.Config
{
    public static class Session
    {

        public static string file = Path.GetTempPath() + "tempProjectSession.tmp";


        public static void QuitSession()
        {
            try
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void SaveSession(User usuario)
        {
            using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (BinaryWriter reader = new BinaryWriter(fileStream))
                {
                    try
                    {
                        reader.Write(usuario.nombres);
                        reader.Write(usuario.telefono);
                        reader.Write(usuario.cedula);
                        reader.Write(usuario.email);
                        reader.Write(usuario.id_usuario);
                        reader.Write(usuario.imagen_id);
                        reader.Write(DateTime.Now.AddDays(1).ToString());
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }

        public static User GetSession()
        {
            if (File.Exists(file))
            {
                using (FileStream fileStream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.Read))
                {
                    using (BinaryReader reader = new BinaryReader(fileStream))
                    {
                        try
                        {
                            reader.BaseStream.Seek(0, SeekOrigin.Begin);
                            string name = reader.ReadString();
                            string phone = reader.ReadString();
                            string schedule = reader.ReadString();
                            string email = reader.ReadString();
                            int id = reader.ReadInt32();
                            string image = reader.ReadString();
                            string date = reader.ReadString();

                            if (DateTime.Now < Convert.ToDateTime(date))
                            {
                                return new User()
                                {
                                    cedula = schedule,
                                    nombres = name,
                                    email = email,
                                    id_usuario = id,
                                    imagen_id = image,
                                    telefono = phone
                                };
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return null;
        }

    }
}
