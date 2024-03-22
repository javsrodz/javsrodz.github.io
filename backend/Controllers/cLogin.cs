using Escuela.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;


namespace Escuela.Controllers
{
    [Route("api")]
    [ApiController]
    public class cLogin : ControllerBase
    {

        private readonly string Conexion;
        private readonly string secretkey;

        public cLogin(IConfiguration config)
        {
            Conexion = config.GetConnectionString("ConexionSQL");
            secretkey = config.GetSection("JWTConfig").GetSection("secretkey").ToString();
        }

        [HttpPost]
        [Route("login")]

        public IActionResult Login([FromBody] mUsuario datos)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ValidarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@US", cEncriptar.ToSHA256(datos.user));
                        command.Parameters.AddWithValue("@PASS", cEncriptar.ToSHA256(datos.password));
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                var name = reader.GetString(0);
                                var lastname = cEncriptar.DecriptMD5(reader.GetString(1));
                                var puesto = cEncriptar.DecriptMD5(reader.GetString(2));
                                var rol = reader.GetInt32(3);
                                var email = cEncriptar.DecriptMD5(reader.GetString(4));

                                var enriptkey = Encoding.ASCII.GetBytes(secretkey);
                                var claims = new ClaimsIdentity();


                                claims.AddClaim(new Claim(ClaimTypes.Name, name));
                                claims.AddClaim(new Claim(ClaimTypes.Surname, lastname));
                                claims.AddClaim(new Claim(ClaimTypes.Actor, puesto));
                                claims.AddClaim(new Claim(ClaimTypes.Role, Convert.ToString(rol)));
                                claims.AddClaim(new Claim(ClaimTypes.Email, email));


                                var TokenDescriptor = new SecurityTokenDescriptor
                                {
                                    Subject = claims,
                                    Expires = DateTime.UtcNow.AddHours(2),
                                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(enriptkey), SecurityAlgorithms.HmacSha256)
                                };

                                var tokenhandler = new JwtSecurityTokenHandler();
                                var tokenconfig = tokenhandler.CreateToken(TokenDescriptor);
                                var tokencreado = tokenhandler.WriteToken(tokenconfig);

                                return StatusCode(StatusCodes.Status200OK, new { mensaje = "usuario encontrado", token = tokencreado });
                            }
                            else
                            {
                                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Usuario no encontrado", token = "" });
                            }
                        }
                    }
                }

            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al registrar" });
            }
        }

        [HttpPost]
        [Route("nuevous")]

        public IActionResult InsertarUsuario([FromBody] mNuevoUsuario datos)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Conexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("I_NuevoUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@NOMBRE", cEncriptar.ToSHA256(datos.nombre));
                        command.Parameters.AddWithValue("@APPELLIDOS", cEncriptar.ToMD5(datos.apellidos));
                        command.Parameters.AddWithValue("@CORREO", cEncriptar.ToMD5(datos.correo));
                        command.Parameters.AddWithValue("@CONTRASEÑA", cEncriptar.ToSHA256(datos.contrasena));
                        command.Parameters.AddWithValue("@PUESTO", cEncriptar.ToMD5(datos.puesto));
                        command.Parameters.AddWithValue("@ROL", datos.rol);
                        command.CommandType = CommandType.StoredProcedure;
                        command.ExecuteNonQuery();
                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "usuario registrado" });
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex });
            }
        }



        [HttpGet]
        [Route("getusuario")]
        public IActionResult listausuarios()
        {
            List<mNuevoUsuario> lista = new List<mNuevoUsuario>();
            try
            {
                using (var conexion = new SqlConnection(Conexion))
                {
                    conexion.Open();
                    var command = new SqlCommand("LISTAUSUARIO", conexion);
                    command.CommandType = CommandType.StoredProcedure;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new mNuevoUsuario()
                            {
                                nombre = cEncriptar.DecriptMD5(reader["NOMBRE"].ToString()),
                                apellidos = cEncriptar.DecriptMD5(reader["APPELLIDOS"].ToString()),
                                correo = cEncriptar.DecriptMD5(reader["CORREO"].ToString()),
                                puesto = cEncriptar.DecriptMD5(reader["PUESTO"].ToString()),
                                rol = Convert.ToInt32(reader["ROL"]),
                            });


                        }
                    }
                }
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (SqlException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al mostrar los datos", ex });
            }

        }


    }
}
