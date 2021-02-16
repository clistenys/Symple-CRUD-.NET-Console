using System.Collections.Generic;

namespace CRUD.Interfaces
{
    public interface Repositorio<T>
    {
        List<T> ShowList();
        
        void Create(T entidade);
        T Read(int id);
        void Update(int id, T entidade);
        void Delete(int id);
        int NextId();
    }
}