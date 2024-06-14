using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Banco
    {
        public static (bool, string, ML.Banco, Exception) GetAll()
        {
            ML.Banco banco = new ML.Banco();
            try
            {
                using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
                {
                    var bancos = (from a in context.Bancoes
                                    select a).ToList();
                    if (bancos != null)
                    {
                        banco.BancoList = new List<ML.Banco>();
                        foreach (var objBanco in bancos)
                        {
                            ML.Banco banco1 = new ML.Banco();
                            banco1.IdBanco =objBanco.IdBanco;
                            banco1.Nombre = objBanco.NombreBanco;

                            banco.BancoList.Add(banco1);
                        }
                        return (true, "", banco, null);

                    }
                    return (false, "No hay registro", null, null);

                }
            }
            catch (Exception ex)
            {

                return (false, ex.Message, null, null);
            }
        }

    }
}
