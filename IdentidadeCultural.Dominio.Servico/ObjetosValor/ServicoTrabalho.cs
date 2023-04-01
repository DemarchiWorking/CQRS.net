using IdentidadeCultural.Dominio.Servicos.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentidadeCultural.Dominio.Servicos.ObjetosValor
{
    public class ServicoTrabalho
    {

        public ServicoTrabalho(Guid id, Guid? id_Usuario, string titulo, Categoria categoria, string descricao, string foto, DateTime criacao)
        {
            Id = id;
            Id_Usuario = id_Usuario;
            Titulo = titulo;
            Categoria = categoria;
            Descricao = descricao;
            Foto = foto;
            Criacao = criacao;
        }

        public Guid Id { get; set; }
        public Guid? Id_Usuario { get; set; }
        public string Titulo { get; set; }
        public Categoria Categoria { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public DateTime Criacao { get; set; }

    }
}