using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyAppCore.MyAppCoreComponents.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace MyAppCore.MyAppCoreComponents.Core
{
    public class GenericRepository<Tobj> : ICrudBusiness<Tobj> where Tobj : class
    {
        DbContext _dbcontext;

        string errorMessage = string.Empty;
        public GenericRepository(DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual Tobj Get(int id)
        {
            return _dbcontext.Set<Tobj>().Find(id);
        }
        /// <summary>
        /// Returns a single object with a primary key of the provided id
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="id">The primary key of the object to fetch</param>
        /// <returns>A single object with the provided primary key or null</returns>
        public virtual async Task<Tobj> GetAsync(int id)
        {
            return await _dbcontext.Set<Tobj>().FindAsync(id);
        }
        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual IQueryable<Tobj> GetAll()
        {
            return _dbcontext.Set<Tobj>().AsNoTracking().AsQueryable();
        }
        /// <summary>
        /// Gets a collection of all objects in the database
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>An ICollection of every object in the database</returns>
        public virtual async Task<ICollection<Tobj>> GetAllAsync()
        {
            return await _dbcontext.Set<Tobj>().AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual Tobj Find(Expression<Func<Tobj, bool>> match)
        {
            return _dbcontext.Set<Tobj>().SingleOrDefault(match);
        }
        /// <summary>
        /// Returns a single object which matches the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A Linq expression filter to find a single result</param>
        /// <returns>A single object which matches the expression filter. 
        /// If more than one object is found or if zero are found, null is returned</returns>
        public virtual async Task<Tobj> FindAsync(Expression<Func<Tobj, bool>> match)
        {
            return await _dbcontext.Set<Tobj>().SingleOrDefaultAsync(match);
        }
        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual ICollection<Tobj> FindAll(Expression<Func<Tobj, bool>> match)
        {
            return _dbcontext.Set<Tobj>().Where(match).ToList();
        }
        /// <summary>
        /// Returns a collection of objects which match the provided expression
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="match">A linq expression filter to find one or more results</param>
        /// <returns>An ICollection of object which match the expression filter</returns>
        public virtual async Task<ICollection<Tobj>> FindAllAsync(Expression<Func<Tobj, bool>> match)
        {
            return await _dbcontext.Set<Tobj>().Where(match).ToListAsync();
        }

        /// <summary>
        /// Create a single object to the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting of the insert</returns>
        public virtual int Add(Tobj entity)
        {

            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {

                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().Add(entity);
                    var Result = _dbcontext.SaveChanges();
                    dbContextTransaction.Commit();
                    return Result;
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{

                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}

        }

        /// <summary>
        /// Inserts a single object to the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entity">The object to insert</param>
        /// <returns>The resulting of the insert</returns>
        public virtual async Task<int> AddAsync(Tobj entity)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().Add(entity);
                    var Result = await _dbcontext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            //catch (DbEntityValidationException dbEx)
            //{
            //    dbContextTransaction.Rollback();
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
            //        }
            //    }
            //    throw new Exception(errorMessage, dbEx);
            //}
        }
        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The resulting of the insert</returns>
        public virtual int AddAll(IEnumerable<Tobj> entityList)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entityList == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().AddRange(entityList);
                    var Result = _dbcontext.SaveChanges();
                    dbContextTransaction.Commit();
                    return Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}



        }
        /// <summary>
        /// Inserts a collection of objects into the database and commits the changes
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entityList">An IEnumerable list of objects to insert</param>
        /// <returns>The resulting of the insert</returns>
        public virtual async Task<int> AddAllAsync(IEnumerable<Tobj> entityList)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entityList == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().AddRange(entityList);
                    var Result = await _dbcontext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}


        }
        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The updated object to apply to the database</param>
        /// <returns>The resulting  of the update </returns>
        public virtual int Update(Tobj entity)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                    _dbcontext.Set<Tobj>().Add(entity);
                    var Result = _dbcontext.SaveChanges();
                    dbContextTransaction.Commit();
                    return Result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}


        }
        /// <summary>
        /// Updates a single object based on the provided primary key and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entity">The updated object to apply to the database</param>
        /// <returns>The resulting  of the update</returns>
        public virtual async Task<int> UpdateAsync(Tobj entity)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Entry(entity).State = EntityState.Modified;
                    var Result = await _dbcontext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return Result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}
        }
        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <param name="entity">The object to delete</param>
        /// <returns>The resulting  of the delete</returns>
        public virtual int Delete(Tobj entity)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().Remove(entity);
                    var Result = _dbcontext.SaveChanges();
                    dbContextTransaction.Commit();
                    return Result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}

        }
        /// <summary>
        /// Deletes a single object from the database and commits the change
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <param name="entity">The object to delete</param>
        /// <returns>The resulting  of the delete</returns>
        public virtual async Task<int> DeleteAsync(Tobj entity)
        {
            using (IDbContextTransaction dbContextTransaction = _dbcontext.Database.BeginTransaction())
                try
                {
                    if (entity == null)
                    {
                        throw new ArgumentNullException("entity");
                    }
                    _dbcontext.Set<Tobj>().Remove(entity);
                    var Result = await _dbcontext.SaveChangesAsync();
                    dbContextTransaction.Commit();
                    return Result;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                //catch (DbEntityValidationException dbEx)
                //{
                //    dbContextTransaction.Rollback();
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                //        }
                //    }
                //    throw new Exception(errorMessage, dbEx);
                //}

        }

        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Synchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual int Count()
        {
            return _dbcontext.Set<Tobj>().AsNoTracking().Count();
        }
        /// <summary>
        /// Gets the count of the number of objects in the databse
        /// </summary>
        /// <remarks>Asynchronous</remarks>
        /// <returns>The count of the number of objects</returns>
        public virtual async Task<int> CountAsync()
        {
            return await _dbcontext.Set<Tobj>().AsNoTracking().CountAsync();
        }

        public DbContext getDbContext()
        {
            return _dbcontext;
        }
    }
}
