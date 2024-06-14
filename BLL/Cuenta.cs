using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cuenta
    {
        public static (bool, string, ML.Cuenta, Exception) Add(ML.Cuenta cuenta)
        {
            try
            {
                using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
                {
                    int rowsAffected = context.AddCuenta( cuenta.NumeroCuenta, cuenta.Banco.IdBanco, cuenta.Persona.IdPersona);

                    if (rowsAffected > 0)
                    {
                        return (true, null, cuenta, null);
                    }
                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, null);
            }
            return (false, null, null, null);
        }


        public static (bool, string, ML.Cuenta, Exception) GetAllEF()
        {
            ML.Cuenta cuenta1 = new ML.Cuenta();

            try
            {
                using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())

                {

                    var registros = context.GetAllCuentas().ToList();

                    if (registros.Count > 0)

                    {

                        cuenta1.ListCuenta = new List<ML.Cuenta>();

                        foreach (var registro in registros)
                        {

                            ML.Cuenta cuentaObj = new ML.Cuenta();
                            cuentaObj.IdCuenta = registro.IdPersona;
                            cuentaObj.NumeroCuenta = (registro.NumeroCuenta == null) ? "N/A" : registro.NumeroCuenta;

                            //intanciar 
                            cuentaObj.Banco = new ML.Banco();
                            cuentaObj.Banco.IdBanco = registro.IdBanco;
                            cuentaObj.Banco.Nombre = (registro.NombreBanco == null) ? "N/A" : registro.NombreBanco;


                            //Instancia 
                            cuentaObj.Persona = new ML.Persona();
                            cuentaObj.Persona.IdPersona = registro.IdPersona;
                            cuentaObj.Persona.Nombre = registro.Nombre;
                            cuentaObj.Persona.ApellidoPaterno = registro.ApellidoPaterno;
                            cuentaObj.Persona.ApellidoMaterno = registro.ApellidoMaterno;
                            cuentaObj.Persona.RFC = registro.RFC;


                            cuenta1.ListCuenta.Add(cuentaObj);

                        }
                    }
                    return (true, null, cuenta1, null);

                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);

            }

        }


    }
}
