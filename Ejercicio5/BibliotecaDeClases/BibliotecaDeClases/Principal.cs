using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace BibliotecaDeClases
{
    public class Principal
    {
        private string pathArchivo = "";
        public Principal()
        {
            string filepath = AppDomain.CurrentDomain.BaseDirectory;
            pathArchivo = filepath + "Suscripciones.json";
        }
        public List<Suscripcion> GetSuscripciones()
        {
            List<Suscripcion> suscripciones = new();
            if (File.Exists(pathArchivo))
            {
                suscripciones = JsonConvert.DeserializeObject<List<Suscripcion>>(File.ReadAllText(pathArchivo));
            }
            return suscripciones;
        }
        public void SaveSuscripciones(List<Suscripcion> suscripciones)
        {
            string saveData = JsonConvert.SerializeObject(suscripciones, Formatting.Indented);
            File.WriteAllText(pathArchivo, saveData);
        }
        public Suscripcion CrearSuscripcion(Suscripcion sus)
        {
            if (sus.DNI == 0 && sus.MontoBase == 0)
            {
                return new Suscripcion();
            }
            List<Suscripcion> suscripciones = GetSuscripciones();
            sus.Codigo = suscripciones.Count() + 1;
            sus.FechaInicio = DateTime.Now;
            suscripciones.Add(sus);
            SaveSuscripciones(suscripciones);
            return sus;
        }
        public List<Suscripcion> ObtenerSuscripciones(int fecha_monto, int orden)
        {
            List <Suscripcion>suscripciones = GetSuscripciones();
            if (fecha_monto==1)
            {
                if (orden == 0)
                {
                    suscripciones = suscripciones.OrderBy(x=>x.FechaInicio).ToList();
                }
                if (orden == 1)
                {
                    suscripciones = suscripciones.OrderByDescending(x => x.FechaInicio).ToList();
                }
            }
            if (fecha_monto == 2)
            {
                if (orden == 0)
                {
                    suscripciones = suscripciones.OrderBy(x => x.MontoBase).ToList();
                }
                if (orden == 1)
                {
                    suscripciones = suscripciones.OrderByDescending(x => x.MontoBase).ToList();
                }
            }
            return suscripciones;
        }
        public Suscripcion ObtenerSuscripcion(int cod)
        {
            List<Suscripcion> suscripciones = GetSuscripciones();
            return suscripciones.FirstOrDefault(x=>x.Codigo == cod);
        }
        public ResultadoActualizar ActualizarMonto(Suscripcion sus, int id)
        {
            ResultadoActualizar resul = new();
            if (sus.Codigo == default && sus.FechaInicio == default && sus.FechaEliminacion == default && sus.Pagos.Count() == 0)
            {
                List<Suscripcion> suscripciones = GetSuscripciones();
                suscripciones.FirstOrDefault(x=>x.Codigo==id).MontoBase=sus.MontoBase;
                resul.Sus = suscripciones.FirstOrDefault(x => x.Codigo == id);
                resul.Accionar = true;
                SaveSuscripciones(suscripciones);
                return resul;
            }
            resul.Mensaje = "Se intento actualizar propiedades de mas";
            resul.Accionar = false;
            return resul;
        }
        public ResultadoActualizar EliminarSuscripcion(int Codigo)
        {
            ResultadoActualizar resul = new();
            List<Suscripcion> suscripciones = GetSuscripciones();
            Suscripcion sus = suscripciones.FirstOrDefault(x => x.Codigo == Codigo);
            if (sus == null)
            {
                resul.Accionar=false;
                resul.Mensaje = "No existe una suscripcion con ese id";             
                return resul;
            }
            suscripciones.FirstOrDefault(x => x.Codigo == Codigo).FechaEliminacion = DateTime.Now;
            SaveSuscripciones(suscripciones);
            sus = suscripciones.FirstOrDefault(x => x.Codigo == Codigo);
            resul.Accionar=true;
            resul.Sus = sus;
            return resul;
        }
    }
}