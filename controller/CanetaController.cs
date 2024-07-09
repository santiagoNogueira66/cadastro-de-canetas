using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_C_.entidades;
using CRUD_C_.context;
using Microsoft.AspNetCore.Mvc;
namespace CRUD_C_.controller
{
    [ApiController]
    [Route("[controller]")]
    public class CanetaController : ControllerBase
    {
        private readonly CanetaContext _context;

        public CanetaController(CanetaContext context){
            _context = context;
        }       
        /*create*/
        [HttpPost]
        public IActionResult Create(Caneta caneta){
            _context.Add(caneta);
            _context.SaveChanges();
            return Ok(caneta);
        }
        
        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id){
            var caneta = _context.Canetas.Find(id);     
            
            if (caneta == null)
            {
                return NotFound();
            }
            return Ok(caneta);
        }

        /*read*/
        [HttpGet("listar-todos")]
        public IActionResult ListarTodos(){
            var canetas = _context.Canetas.ToList();
            return Ok(canetas);
        }

        /*update*/
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Caneta caneta){
               var canetaBanco = _context.Canetas.Find(id);
               if (canetaBanco == null)
               {
                return NotFound();
               }
               canetaBanco.Marca = caneta.Marca;
               canetaBanco.Modelo = caneta.Modelo;
               canetaBanco.Cor = caneta.Cor;

               
               _context.Canetas.Update(canetaBanco);
               _context.SaveChanges();

               return Ok(canetaBanco);
        }
        /*delete*/
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id){
         var canetaBanco = _context.Canetas.Find(id);
         if (canetaBanco == null)
         {
            return NotFound();
         }
         _context.Canetas.Remove(canetaBanco);
         _context.SaveChanges();

         return NoContent();
         }
         // Contar canetas por cor
        [HttpGet("quantidade-por-cor")]
        public IActionResult QuantidadePorCor()
        {
        var quantidadePorCor = _context.Canetas
                                .GroupBy(c => c.Cor)
                                .Select(g => new { Cor = g.Key, Quantidade = g.Count() })
                                .ToList();
        return Ok(quantidadePorCor);
        } 
        [HttpGet("contar-todos")]
        public IActionResult ContarTodos()
        {
        var totalCanetas = _context.Canetas.Count();
        return Ok(totalCanetas);
}
    }

}