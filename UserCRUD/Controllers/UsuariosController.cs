using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserCRUD.Data;
using UserCRUD.Model;
using Microsoft.EntityFrameworkCore;
using UserCRUD.Data.DAO;
using UserCRUD.Data.Interface;
using UserCRUD.BI;

namespace UserCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosDAO usuariosDAO;

        public UsuariosController(DataContext dataContext)
        {
            usuariosDAO = new UsuariosDAO(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuarios>>> Get()
        {
            return Ok(usuariosDAO.Read());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Usuarios>>> Get(int id)
        {
            var _usuario = usuariosDAO.ReadId(id);

            if (_usuario == null)
            {
                return NotFound(new { message = "Usuário não existe!" });
            }

            return Ok(_usuario);

        }

        [HttpPost]
        public async Task<ActionResult<List<Usuarios>>> Post(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (Validator.IsCpf(usuario.cpf))
                {
                    if (!Validator.CPFExist(usuario.cpf, usuariosDAO))
                    {
                        if (Validator.BirthdayCheck(usuario.DataNascimento))
                        {
                            usuariosDAO.Create(usuario);
                            return Ok(new { message = "Usuário salvo com sucesso!" });
                        }
                        return BadRequest(new { message = "Data de nascimento deve ser menor que a data atual!" });
                    }
                    return BadRequest(new { message = "Esse usuário já está cadastrado!" });
                }
                return BadRequest(new { message = "CPF inválido!" });

            }

            return BadRequest(ModelState);

        }

        [HttpPatch]
        public async Task<ActionResult<List<Usuarios>>> Patch(Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                if (Validator.IsCpf(usuario.cpf))
                {                    
                    if (Validator.BirthdayCheck(usuario.DataNascimento))
                    {
                        usuariosDAO.Update(usuario);
                        return Ok(new { message = "Usuário atualizado com sucesso!" });
                    }
                    return BadRequest(new { message = "Data de nascimento deve ser menor que a data atual!" });
                    
                }
                return BadRequest(new { message = "CPF inválido!" });
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Usuarios>>> Delete(int id)
        {
            try
            {
                usuariosDAO.Delete(id);

                return Ok(new { message = "Usuário excluído com sucesso!" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível excluir esse usuário!" });
            }
            
        }
               
               
    }
}
