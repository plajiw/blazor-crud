using BlazorCRUD.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCRUD.Shared.Models
{
    // Uma classe estática chamada Banco que simula um banco de dados em memória
    // Usamos uma lista estática de produtos para armazenar os dados, como se fosse uma tabela no banco.
    // Aqui não há conexão com um banco real, e as operações são realizadas apenas em memória.
    public static class Banco
    {

        public static List<Produto> Produtos { get; set; } = new()
        {
            new Produto
            {
                Id = 1,
                Nome = "Produto A",
                Preco = 29.99,
                Quantidade = 100,
                Imagem = "https://via.placeholder.com/50x50?text=Produto+A"
            },
            new Produto
            {
                Id = 2,
                Nome = "Produto B",
                Preco = 45.50,
                Quantidade = 50,
                Imagem = "https://via.placeholder.com/50x50?text=Produto+B"
            },
            new Produto
            {
                Id = 3,
                Nome = "Produto C",
                Preco = 19.99,
                Quantidade = 200,
                Imagem = "https://via.placeholder.com/50x50?text=Produto+C"
            },
            new Produto
            {
                Id = 4,
                Nome = "Produto D",
                Preco = 99.99,
                Quantidade = 10,
                Imagem = "https://via.placeholder.com/50x50?text=Produto+D"
            }
        };
    }
}
