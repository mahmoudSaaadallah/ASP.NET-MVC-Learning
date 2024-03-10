using Learning.Model.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            StudentRepository = new StudentRepository(_context);

        }

        public IStudentRepository StudentRepository { get; private set; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
