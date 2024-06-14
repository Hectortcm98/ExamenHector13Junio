using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class Persona
    {
        public static (bool, string, ML.Persona, Exception) GetAll()
        {
			ML.Persona  Personas = new ML.Persona();
			try
			{
				using(DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
				{
					var personas = context.GetAllPersona().ToList();
					if (personas != null)
					{
						Personas.PersonaList = new List<ML.Persona>();
						foreach (var objPersona in personas)
						{
							ML.Persona persona = new ML.Persona();
							persona.IdPersona = objPersona.IdPersona;
							persona.Nombre = objPersona.Nombre;
							persona.ApellidoPaterno = objPersona.ApellidoPaterno;
							persona.ApellidoMaterno = objPersona.ApellidoMaterno;
							persona.FechaNacimineto = objPersona.FechaNacimiento.Value;
							persona.PaisOrigen = objPersona.PaisOrigen;
							persona.Sexo = objPersona.Sexo;
							persona.CURP = objPersona.CURP;
							persona.RFC = objPersona.RFC;
							persona.Ocupacion = objPersona.Ocupacion;
							persona.TipoPersonaFisica = objPersona.TipoPersonaFisica;

							Personas.PersonaList.Add(persona);

                        }
                        return (true, "", Personas, null);

                    }
                    return (false, "No hay registro", null, null);
					
				}
			}
			catch (Exception ex)
			{

				return (false, ex.Message, null, null);
			}
        }

		public static (bool, string, ML.Persona, Exception) Add(ML.Persona persona)
		{
			try
			{
				using(DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
				{
					int rowsAffected = context.AddPersonas(persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.FechaNacimineto, persona.PaisOrigen, persona.Sexo, persona.CURP,persona.RFC, persona.Ocupacion, persona.TipoPersonaFisica);
					
					if(rowsAffected > 0 )
					{
						return (true, null, persona, null);
					}
				}
			}
			catch (Exception ex)
			{

				return (false,ex.Message, null, null);
			}
			return (false, null, null, null);
		}

		public static  (bool, string, ML.Persona, Exception) GetById(int IdPersona)
		{
			ML.Persona persona = new ML.Persona();

			try
			{
				using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
				{
					var query = (from obj in context.Personas
								 where obj.IdPersona.Equals(IdPersona)
								 select obj).Single();

					if (query != null)
					{
						persona.Nombre = query.Nombre;
						persona.ApellidoPaterno = query.ApellidoPaterno;
						persona.ApellidoMaterno = query.ApellidoMaterno;
						persona.FechaNacimineto = query.FechaNacimiento.Value;
						persona.PaisOrigen = query.PaisOrigen;
						persona.Sexo = query.Sexo;
						persona.CURP = query.CURP;
						persona.RFC = query.RFC;
						persona.Ocupacion = query.Ocupacion;
						persona.TipoPersonaFisica = query.TipoPersonaFisica;

						return(true, null, persona, null);

					}

				}
			}

			catch (Exception ex)
			{

				return (false, ex.Message, null, null);
			}
			return (true, null, null, null);
		}

		public static (bool, string, ML.Persona, Exception) Update(ML.Persona persona)
		{
			try
			{
				using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
				{
					var rowsAffected = context.UpdatePersona(persona.IdPersona,persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.FechaNacimineto, persona.PaisOrigen, persona.Sexo, persona.CURP, persona.RFC, persona.Ocupacion, persona.TipoPersonaFisica);
					
					if(rowsAffected > 0)
					{
                        return (true, null, null, null);
                    }
				}

			}
			catch (Exception ex)
			{

                return (false, ex.Message, null, ex);
            }
			return (true, null, null, null);
		}

		public static (bool, string, ML.Persona, Exception) Delete(ML.Persona persona)
		{
			try
			{
				using (DL.Ejercicio13JunioEntities context = new DL.Ejercicio13JunioEntities())
				{
					int rowsAffected = context.DeletePersonas(persona.IdPersona, persona.Nombre, persona.ApellidoPaterno, persona.ApellidoMaterno, persona.FechaNacimineto, persona.PaisOrigen, persona.Sexo, persona.CURP, persona.RFC, persona.Ocupacion, persona.TipoPersonaFisica);
					
					if(rowsAffected > 0)
					{
						return(true, null, null, null);
					}
				}
			}
			catch (Exception ex)
			{
                return (false, ex.Message, null, ex);
            }
			return (true, null, null, null);
		}
    }
}
