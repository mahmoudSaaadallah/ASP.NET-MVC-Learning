using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Model.IRepository
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        void Save();
    }
}
