using BlazorCRUD.Shared.Models;
using DataSim.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Server.Controllers
{
    // Define a rota base para este controlador de API. O [controller] é substituído automaticamente pelo nome do controlador, 
    // ou seja, "ProdutosController" vai gerar a rota "api/produtos"
    [Route("api/[controller]")]
    [ApiController] // Indica que este controlador é uma API RESTful (usando convenções como resposta automática de 400 para erros).
    public class ProdutosController : ControllerBase
    {
        // Este é um método de ação para o endpoint "POST api/produtos/incluir", 
        // usado para adicionar um novo produto ao "banco de dados" (lista em memória).
        [HttpPost("incluir")]
        public IActionResult Adicionar(Produto produto)
        {
            // Verifica se o produto recebido como parâmetro é nulo. 
            // Se for, retorna um erro 400 (BadRequest), indicando que a solicitação foi malformada.
            if (produto == null)
            {
                return BadRequest("Produto não foi enviado por parâmetro");
            }

            // Tenta encontrar o último produto adicionado (o que tem o maior Id) para gerar um novo Id sequencial.
            Produto? produtoAnterior = Banco.Produtos.OrderByDescending(e => e.Id).FirstOrDefault();

            // Se um produto anterior foi encontrado (ou seja, a lista de produtos não está vazia),
            // o novo produto receberá o Id do produto anterior + 1, gerando um Id único e sequencial.
            if (produtoAnterior != null)
            {
                produto.Id = produtoAnterior.Id + 1;
            }
            else
            {
                // Se não houver produtos na lista, significa que é o primeiro produto. 
                // O Id será definido como 1.
                produto.Id = 1;
            }

            // Adiciona o novo produto à lista de produtos simulando o banco de dados em memória.
            Banco.Produtos.Add(produto);

            // Retorna um status HTTP 200 (OK) indicando que a operação foi bem-sucedida.
            return Ok();
        }

        [HttpGet("listar")]
        public IActionResult Listar(string? nome) // Tornamos o parâmetro nome opcional
        {
            List<Produto> retorno;

            if (!string.IsNullOrEmpty(nome)) // Verifica se o parâmetro nome não é nulo ou vazio
            {
                // Se o nome for fornecido, filtra os produtos que contenham esse nome
                retorno = Banco.Produtos.Where(e => e.Nome.Contains(nome, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            else
            {
                // Se o nome não for fornecido, retorna todos os produtos
                retorno = Banco.Produtos.ToList();
            }

            // Verifica se a lista de produtos retornada tem itens
            if (retorno.Count > 0)
            {
                return Ok(retorno); // Retorna os produtos encontrados
            }
            else
            {
                return NotFound("Produto não encontrado"); // Retorna um erro 404 se nenhum produto for encontrado
            }
        }

        [HttpPut("alterar")]
        public IActionResult Alterar(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto não foi enviado por parâmetro");
            }

            Produto? p = Banco.Produtos.Where(e => e.Id == produto.Id).FirstOrDefault();

            if (p == null)
            {
                return BadRequest("Produto não existe mais na base, possivelmente foi removido");
            }

            p.Nome = produto.Nome;
            p.Preco = produto.Preco;
            p.Quantidade = produto.Quantidade;
            p.Imagem = produto.Imagem;

            return Ok();
        }

        [HttpDelete("excluir/{id:int}")]
        public IActionResult Excluir(int id)
        {
            Produto? p = Banco.Produtos.Where(e => e.Id == id).FirstOrDefault();

            if (p == null)
            {
                return BadRequest("Produto não existe na base de dados.");
            }

            Banco.Produtos.Remove(p);
            return Ok();
        }
    }
}
