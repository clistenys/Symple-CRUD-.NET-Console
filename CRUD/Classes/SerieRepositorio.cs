using System.Collections.Generic;
using CRUD.Interfaces;

namespace CRUD.Classes
{
    public class SerieRepositorio : Repositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Create(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public void Delete(int id)
        {
            listaSerie[id].Excluir();
        }

        public List<Serie> ShowList()
        {
            return listaSerie;
        }

        public int NextId()
        {
            return listaSerie.Count;
        }

        public Serie Read(int id)
        {
            return listaSerie[id];
        }

        public void Update(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }
    }
}