using CovidDoc.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDoc.WebApi.Services
{
    /// <summary>
    /// Сервис безопасности приложения
    /// </summary>
    public class SecurityService
    {
        private Type[] adminEntityTypes = new[] { typeof(AppUser), typeof(AppRole) };
        private bool IsAdminEntity<T>() => adminEntityTypes.Contains(typeof(T));

        private Func<T, bool> TryAdmin<T>(AppUser currentUser, Func<T, bool> securityFilterPredicate)
        {
            if (IsAdminEntity<T>())
            {
                securityFilterPredicate = (T obj) => currentUser?.IsAdmin() ?? false;
            }

            return securityFilterPredicate;
        }

        /// <summary>
        /// Ограничения доступности объектов модели для выборки текущим пользователем
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="source">Полный список объектов</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public IQueryable<T> WhereAccessGranted<T>(IEnumerable<T> source, AppUser currentUser)
        {
            Func<T, bool> securityFilterPredicate = (T obj) => true;
            securityFilterPredicate = TryAdmin(currentUser, securityFilterPredicate);
            return source.Where(x => securityFilterPredicate(x)).AsQueryable<T>();
        }        

        /// <summary>
        /// Проверка доступа текущего пользователя к объекту
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="entity">Объект</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public bool ReadGranted<T>(T entity, AppUser currentUser)
        {
            Func<T, bool> grantPredicate = (T obj) => true;
            grantPredicate = TryAdmin(currentUser, grantPredicate);
            return grantPredicate(entity);
        }

        /// <summary>
        /// Проверка доступа пользователя к удалению объекта
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="entity">Объект для удаления</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public bool DeleteGranted<T>(T entity, AppUser currentUser)
        {
            Func<T, bool> grantPredicate = (T obj) => true;
            grantPredicate = TryAdmin(currentUser, grantPredicate);
            return grantPredicate(entity);
        }

        /// <summary>
        /// Проверка доступа пользователя к изменению объекта
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="entity">Объект для изменения</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public bool ModifyGranted<T>(T entity, AppUser currentUser)
        {
            Func<T, bool> grantPredicate = (T obj) => true;
            grantPredicate = TryAdmin(currentUser, grantPredicate);
            return grantPredicate(entity);
        }

        /// <summary>
        /// Проверка доступа пользователя к созданию объекта
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="entity">Объект для включения в домен</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        internal bool CreateGranted<T>(T entity, AppUser currentUser) where T : class
        {
            Func<T, bool> grantPredicate = (T obj) => true;
            grantPredicate = TryAdmin(currentUser, grantPredicate);
            return grantPredicate(entity);
        }
    }
}
