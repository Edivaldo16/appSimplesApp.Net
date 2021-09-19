using System;

namespace DIO.Empregos
{
    public class Empregos : EntidadeBase
    {
        // Atributos
		private Profissao Profissao { get; set; }
		private string Titulo { get; set; }
		private string Descricao { get; set; }
		private string Ano { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Empregos(int id, Profissao profissao, String titulo, String descricao, String ano)
		{
			this.Id = id;
			this.Profissao = profissao;
			this.Titulo = titulo;
			this.Descricao = descricao;
			this.Ano = ano;
            this.Excluido = false;
		}

        public override String ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Profissão: " + this.Profissao + Environment.NewLine;
            retorno += "Nome completo: " + this.Titulo + Environment.NewLine;
            retorno += "Breve descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de nascimento: " + this.Ano + Environment.NewLine;
            //retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaTitulo()
		{
			return this.Titulo;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}