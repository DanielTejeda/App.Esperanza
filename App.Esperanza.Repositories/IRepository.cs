using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Esperanza.Repositories
{
    public interface IRepository<T> where T : class
    {
        //CRUD: Create, Read, Update, Delete
        Task<int> Agregar(T entidad); //Create
        Task<T> Obtener(int id); //Read
        Task<IEnumerable<T>> Listar(); //Read
        Task<bool> Eliminar(T entidad); //Delete
        Task<bool> Modificar(T entidad); //Update
    }
}
