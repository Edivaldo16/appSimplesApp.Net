using System;
using System.Collections.Generic;
using DIO.Empregos.Interfaces;

namespace DIO.Empregos
{
	public class ProfissaoRepositorio : IRepositorio<Empregos>
	{
        private List<Empregos> listaProfissao = new List<Empregos>();
		public void Atualiza(int id, Empregos objeto)
		{
			listaProfissao[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaProfissao[id].Excluir();
		}

		public void Insere(Empregos objeto)
		{
			listaProfissao.Add(objeto);
		}

		public List<Empregos> Lista()
		{
			return listaProfissao;
		}

		public int ProximoId()
		{
			return listaProfissao.Count;
		}

		public Empregos RetornaPorId(int id)
		{
			return listaProfissao[id];
		}
	}
}