using DataSim.Shared.Models;
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

        public static List<Produto> Produtos { get; set; } = new();
    }
}
