using System;
using System.Linq;
using System.Linq.Expressions;

namespace Challenge.Domain.Core
{
    public interface IRepository<T> where T : class
    {
        IUnitOfWork UnitOfWork { get; }

        /// <summary>
        /// Añadir un elemento en el repositorio.
        /// </summary>
        /// <param name="item">Elemento a añadir</param>
        void Add(T item);

        /// <summary>
        /// Modifica un elemento del repositorio.
        /// </summary>
        /// <param name="item">Elemento a modificar.</param>
        void Update(T item);

        /// <summary>
        /// Elimina un elemento del repositorio.
        /// </summary>
        /// <param name="item">Elemento a eliminar.</param>
        void Delete(T item);

        /// <summary>
        /// Registra un elemento en el repositorio.
        /// </summary>
        /// <param name="item">Elemento a registrar.</param>
        void Register(T item);
        /// <summary>
        /// UnRegistra un elemento en el repositorio.
        /// </summary>
        /// <param name="item"></param>
        void UnRegister(T item);

        /// <summary>
        /// Obtiene todos los elementos de un repositorio.
        /// </summary>
        /// <returns>Lista enumerada de elementos.</returns>
        IQueryable<T> GetAll(Func<T, bool> filter = null);

        /// <summary>
        /// Obtiene todos los elementos de un repositorio aplicando distinct
        /// </summary>
        /// <returns>Lista enumerada de elementos.</returns>
        IQueryable<T> GetAllDistinct(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Obtiene los elementos de un repositorio de forma paginada y ordenados.
        /// </summary>
        /// <typeparam name="S">Tipo genérico de la expresión.</typeparam>
        /// <param name="pageIndex">Página índice.</param>
        /// <param name="pageCount">Número de paginas.</param>
        /// <param name="orderExpression">Campo por el que ordenar.</param>
        /// <param name="ascending">Si queremos que se ordene de forma ascendente o descendente.</param>
        /// <returns>Lista enumerada de elementos paginados y ordenados.</returns>
        IQueryable<T> GetPagedElements<S>(int pageIndex, int pageCount, Expression<Func<T, S>> orderExpression, bool ascending);

        /// <summary>
        /// Obtiene los elementos de un reposiorio de forma paginada, ordenados y filtrados.
        /// </summary>
        /// <typeparam name="S">Tipo genérico de la expresión.</typeparam>
        /// <param name="filter">Expresión de filtrado.</param>
        /// <param name="pageIndex">Página índice.</param>
        /// <param name="pageCount">Número de paginas.</param>
        /// <param name="orderExpression">Campo por el que ordenar.</param>
        /// <param name="ascending">Si queremos que se ordene de forma ascendente o descendente.</param>
        /// <returns>Lista enumerada de elementos paginados, filtrados y ordenados.</returns>
        IQueryable<T> GetPagedWithFilter<S>(Expression<Func<T, bool>> filter, int pageIndex, int pageCount, Expression<Func<T, S>> orderExpression, bool ascending);

        /// <summary>
        /// Obtiene todos los elementos filtrados.
        /// </summary>
        /// <param name="filter">Expresión de filtrado.</param>
        /// <returns>Lista enumerada de elemtnos filtrados.</returns>
        IQueryable<T> Find(Expression<Func<T, bool>> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        T Single(Expression<Func<T, bool>> where);
    }
}
