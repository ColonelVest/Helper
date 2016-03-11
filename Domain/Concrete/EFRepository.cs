using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFRepository : IRepository
    {
        private static EFDbContext _context = new EFDbContext();

        public IEnumerable<Period> Periods
        {
            get
            {
                return _context.Periods;
            }
        }

        public IEnumerable<Day> Days
        {
            get
            {
                return _context.Days.Include(d => d.Periods);
            }
        }

        public static void Insert<TEntity>(TEntity entity) where TEntity : class
        {
            _context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));

            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        /// <summary>
        /// Запись нескольких полей в БД
        /// </summary>
        public static void Inserts<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            // Отключаем отслеживание и проверку изменений для оптимизации вставки множества полей
            _context.Configuration.AutoDetectChangesEnabled = false;
            _context.Configuration.ValidateOnSaveEnabled = false;

            _context.Database.Log = (s => System.Diagnostics.Debug.WriteLine(s));


            foreach (TEntity entity in entities)
            {
                _context.Entry(entity).State = EntityState.Added;
            }

            _context.SaveChanges();

            _context.Configuration.AutoDetectChangesEnabled = true;
            _context.Configuration.ValidateOnSaveEnabled = true;
        }
    }
}
