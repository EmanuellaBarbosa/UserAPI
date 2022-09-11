using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UserCRUD.Data;
using UserCRUD.Data.DAO;
using UserCRUD.Data.Interface;
using UserCRUD.Model;
using UserCRUD.BI;
using Microsoft.AspNetCore.Authorization;

namespace UserCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscolaridadeController : ControllerBase
    {
        private IEscolaridadeDAO escolaridadeDAO;
        public EscolaridadeController(DataContext dataContext)
        {
            escolaridadeDAO = new EscolaridadeDAO(dataContext);
        }

        [HttpGet]
        public async Task<ActionResult<List<Escolaridade>>> Get()
        {
            return Ok(escolaridadeDAO.Read());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Escolaridade>>> Get(int id)
        {
            var _escolaridade = escolaridadeDAO.Read(id);

            if(_escolaridade == null)
            {
                return NotFound(new { message = "Esclaridade não existe!" });
            }

            return Ok(_escolaridade);

        }

        [HttpPost]
        public async Task<ActionResult<List<Escolaridade>>> Post(Escolaridade escolaridade)
        {
            if (ModelState.IsValid)
            {
                if (!Validator.EscolaridadeExist(escolaridade.Descricao, escolaridadeDAO))
                {
                    if (Validator.EscolaridadeCheck(escolaridade.Descricao))
                    {
                        escolaridadeDAO.Create(escolaridade);
                        return Ok(new { message = "Escolaridade salva com sucesso!" });
                    }
                    return BadRequest(new { message = "Informe uma escolaridade válida!" });
                }
                return BadRequest(new { message = "Essa escolaridade já existe!" });
            }

            return BadRequest(ModelState);
        }

        [HttpPatch]
        public async Task<ActionResult<List<Escolaridade>>> Patch(Escolaridade escolaridade)
        {
            if (ModelState.IsValid)
            {
                if (Validator.EscolaridadeCheck(escolaridade.Descricao))
                {
                    escolaridadeDAO.Update(escolaridade);
                    return Ok(new { message = "Escolaridade atualizada com sucesso!" });
                }
                return BadRequest(new { message = "Informe uma escolaridade válida!" });
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Escolaridade>>> Delete(int id)
        {
            try
            {
                escolaridadeDAO.Delete(id);

                return Ok(new { message = "Escolaridade excluída com sucesso!" });
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível excluir essa escolaridade!" });
            }

        }

        
    }
}
