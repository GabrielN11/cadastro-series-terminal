using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
	public class SerieRepositorio : IRepositorio<Serie>
	{
        private List<Serie> listaSerie { get; set; }
        private FileHelper helper = new FileHelper();

		public SerieRepositorio()
        {
			listaSerie = helper.getAll();
        }
		public void Atualizar(int id, Serie objeto)
		{
			listaSerie[id] = objeto;
			helper.insertData(listaSerie);
		}

		public string Excluir(int id)
		{
            try
            {
				listaSerie[id].Excluir();
				helper.insertData(listaSerie);
				return "Excluído com sucesso";
            }
            catch
            {
				return "ID não encontrado";
            }
		}

		public void Inserir(Serie objeto)
		{
			listaSerie.Add(objeto);
			helper.insertData(listaSerie);
		}

		public List<Serie> Listar()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornarPorId(int id)
		{
            try
            {
				return listaSerie[id];
            }
            catch
            {
				Console.WriteLine("ID não encontrado.");
				return null;
            }
		}
	}
}