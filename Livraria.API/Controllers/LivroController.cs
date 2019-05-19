using Livraria.ApplicationCore.Models.Base;
using Livraria.ApplicationCore.Models.Exemplar.Services.Interfaces;
using Livraria.ApplicationCore.Models.Livros.DTOs.Requests;
using Livraria.ApplicationCore.Models.Livros.DTOs.Responses;
using Livraria.ApplicationCore.Models.Livros.Exception;
using Livraria.ApplicationCore.Models.Livros.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Livraria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroService _livroService;
        private readonly IExemplarService _exemplarService;

        #region Constructor

        public LivroController(ILivroService livroService, IExemplarService exemplarService)
        {
            _livroService = livroService;
            _exemplarService = exemplarService;
        }

        #endregion

        /// <summary>
        /// GET: /api/Livro
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            List<LivroResponse> livros = null;

            try
            {
                livros = _livroService.GetAllWithExemplares().ToList();

                if (livros == null || !livros.Any())
                    return BadRequest("Não há livros para serem listados");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(livros);
        }

        /// <summary>
        /// POST: /api/Livro
        /// </summary>
        /// <param name="request">dados do livro a ser cadastrado</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] LivroRequest request)
        {
            LivroResponse livroResponse = null;

            try
            {
                if (request == null)
                    return BadRequest(new LivroResponse(false, "A request não foi encontrada"));

                livroResponse = _livroService.Add(request);

                if (livroResponse == null)
                    return BadRequest(new LivroResponse(false, "Não foi possível cadastrar o livro informado"));
            }
            catch(LivroException ex)
            {
                return BadRequest(new LivroResponse(false, ex.Message));
            }
            catch (Exception)
            {
                return BadRequest(new LivroResponse(false, "Internal Server error"));
            }

            livroResponse.Status = true;
            livroResponse.Message = "Cadastro realizado com sucesso";
            return Ok(livroResponse);
        }

        /// <summary>
        /// PUT: /api/Livro/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LivroRequest request)
        {
            LivroResponse livroResponse = null;

            try
            {
                if (id == 0)
                    return NotFound(new LivroResponse(false, "Não foi possível localizar o id informado para alteração"));

                if (id != request.Id)
                    return BadRequest(new LivroResponse(false, "O Id informado não condiz com o Id informado na request"));

                livroResponse = _livroService.Update(request);
            }
            catch(LivroException ex)
            {
                return BadRequest(new LivroResponse(false, ex.Message));
            }
            catch (Exception)
            {
                return BadRequest(new LivroResponse(false, "Internal Server error"));
            }

            livroResponse.Status = true;
            livroResponse.Message = "Edição realizada com sucesso";
            return Ok(livroResponse);
        }

        /// <summary>
        /// DELETE: /api/Livro/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromBody] LivroRequest request)
        {
            try
            {
                if (id == 0)
                    return NotFound(new BaseResponse(false, "Não foi possível localizar o id informado para alteração"));

                if (id != request.Id)
                    return BadRequest(new BaseResponse(false, "O Id informado não condiz com o Id informado na request"));

                _livroService.Delete(request);
            }
            catch (Exception)
            {
                return BadRequest(new BaseResponse(false, "Internal Server error"));
            }

            return Ok(new BaseResponse(true, "Livro excluído com sucesso"));
        }


    }
}