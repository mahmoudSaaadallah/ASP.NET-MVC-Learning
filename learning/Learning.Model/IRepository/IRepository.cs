using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.IRepository
{
    public interface IRepository<T> where T : class
    {
        // The IRepository is a generic class which accept any type of class.
        // This interface will contain all the CRUD operations


        // This method used to get all the records in the data base.
        IEnumerable<T> GetAll();

        // This method used to get a specific record using its id.
        T GetByID(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        // This method used to add a new record to database.
        void Add(T Entity);

        // This method used to add a multiple records to database.
        void AddRange(IEnumerable<T> entities);

        void Delete(T Entity);

        // This method used to remove multiple records from database
        void RemoveRange(IEnumerable<T> entities);
    }
}
