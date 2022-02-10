using CovidDoc.Model;
using CovidDoc.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDoc.WebApi.Controllers
{    
    /// <summary>
    /// Базовый шаблонный класс для контроллеров API + OData
    /// </summary>
    /// <typeparam name="T">Класс EF сущности</typeparam>
    [ApiController]
    [Route("[controller]")]
    public class BaseController<T> : Controller where T: class
    {
        public ILogger<BaseController<T>> Logger { get; }
        public CovidDocModel DbContext { get; }
        public SecurityService SecurityService { get; }

        public BaseController(ILogger<BaseController<T>> logger, CovidDocModel dbContext, SecurityService securityService)
            : base()
        {
            Logger = logger;
            DbContext = dbContext;
            SecurityService = securityService;
        }

        /// <summary>
        /// Выборка еденичного объекта
        /// </summary>
        /// <param name="Id">Ключ объекта для выборки</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Get(long? id)
        {
            var entity = await DbContext.FindAsync<T>(id);
            if (entity == null)
            {
                Logger.LogWarning($@"Запрошен объект {typeof(T).Name} с неверным ключом {id}");
                return NotFound();
            }
            else
            {
                if (SecurityService.ReadGranted(entity, GetCurrentAppUser()))
                {
                    Logger.LogDebug($@"Запрошен объект {typeof(T).Name} с ключом {id}");
                    return Ok(entity);
                }
                else
                {
                    Logger.LogWarning($@"Доступ к объекту {entity} запрещен системой безопасности");
                    return Unauthorized(entity);
                }
            }
        }

        /// <summary>
        /// Выборка списка объектов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetList()
        {
            var appUser = DbContext.AppUser.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);

            // выбираем только объекты доступные текущему пользователю (см SecurityService.WhereAccessGranted)
            var result = await Task.Run(() => SecurityService.WhereAccessGranted<T>(DbContext.Set<T>(), appUser));

            Logger.LogDebug($@"Запрошены объекты {typeof(T).Name} - возвращаем {result.Count()} штук");
            return Ok(result);
        }


        /// <summary>
        /// Удаление объекта по его ключу
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [EnableQuery]
        public async Task<IActionResult> Delete(long? id)
        {
            var entity = await DbContext.FindAsync<T>(id);
            if (entity == null)
                return NotFound();
            else
            {                
                if (SecurityService.DeleteGranted(entity, GetCurrentAppUser()))
                {
                    OnDeleting(entity);

                    DbContext.Remove<T>(entity);
                    await DbContext.SaveChangesAsync();

                    OnDeleted(entity);

                    Logger.LogDebug($@"Удален объект {typeof(T).Name} {entity}");

                    return Ok(entity);
                }
                else
                {
                    Logger.LogWarning($@"Удаление объекта {typeof(T).Name} {entity} запрещено системой безопасности");
                    return Unauthorized(entity);
                }
            }
        }

        /// <summary>
        /// Виртуальный метод выполняемый после удаления объекта из БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Удаленный объект</param>
        protected virtual void OnDeleted(T entity)
        {
            
        }

        /// <summary>
        /// Виртуальный метод выполняемый до удаления объекта из БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Удаляемый объект</param>
        protected virtual void OnDeleting(T entity)
        {
            
        }


        /// <summary>
        /// Получить текущего аутентифицированного пользователя
        /// </summary>
        /// <returns>Текущий пользователь или null если никто не залогинен</returns>
        protected AppUser GetCurrentAppUser()
        {
            return DbContext.AppUser.FirstOrDefault(x => x.UserName == HttpContext.User.Identity.Name);
        }



        /// <summary>
        /// Создание нового объекта
        /// </summary>
        /// <param name="entity">Содержание нового объекта</param>
        /// <returns></returns>
        [HttpPost]
        [EnableQuery]
        public async Task<IActionResult> Post(T entity)
        {
            if (entity == null)
                return NotFound();
            else
            {               
                if (SecurityService.CreateGranted(entity, GetCurrentAppUser()))
                {
                    CustomValidateModelState(entity, ModelState);

                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    OnCreating(entity);

                    await DbContext.AddAsync<T>(entity);
                    await DbContext.SaveChangesAsync();

                    OnCreated(entity);

                    Logger.LogDebug($@"Объект {typeof(T).Name} {entity} создан и записан в БД");

                    var key = GetKey(entity);

                    return CreatedAtAction(nameof(Get), new { id = key }, entity);
                }
                else
                {
                    Logger.LogWarning($@"Создание объекта {typeof(T).Name} {entity} запрещено системой безопасности");
                    return Unauthorized(entity);
                }
            }
        }

        /// <summary>
        /// Виртуальный метод выполняемый после записи нового объекта в БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Новый объект</param>
        protected virtual void OnCreated(T entity)
        {
            
        }

        /// <summary>
        /// Виртуальный метод выполняемый до записи ноовго объекта в БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Новый объект</param>
        protected virtual void OnCreating(T entity)
        {
            
        }

        protected static long? GetKey(T entity)
        {
            return entity == null ? null :(long)entity.GetType().GetProperty("Id").GetValue(entity);
        }

        /// <summary>
        /// Изменение объекта
        /// </summary>
        /// <param name="entity">Содержание измененного объекта</param>
        /// <returns></returns>
        [HttpPut]
        [EnableQuery]
        public async Task<IActionResult> Put(T entity)
        {
            long? key = GetKey(entity);

            if (DbContext.Find<T>(key) == null)
                return NotFound();
            else
            {
                if (SecurityService.ModifyGranted(entity, GetCurrentAppUser()))
                {
                    CustomValidateModelState(entity, ModelState);

                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    OnUpdating(entity);

                    DbContext.Update<T>(entity);
                    await DbContext.SaveChangesAsync();

                    OnUpdated(entity);

                    Logger.LogDebug($@"Объект {typeof(T).Name} {entity} измененен");

                    return Ok(entity);
                }
                else
                {
                    Logger.LogWarning($@"Изменениее объекта {typeof(T).Name} {entity} запрещено системой безопасности");
                    return Unauthorized(entity);
                }
            }
        }

        /// <summary>
        /// Виртуальный метод выполняемый до записи изменений объекта в БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Измененный объект</param>
        protected virtual void OnUpdated(T entity)
        {
            
        }

        /// <summary>
        /// Виртуальный метод выполняемый после записи изменений объекта в БД
        /// Переопределять в унаследованных контроллерах
        /// </summary>
        /// <param name="entity">Измененный объект</param>
        protected virtual void OnUpdating(T entity)
        {
            
        }

        /// <summary>
        /// Пользовательская проверка объекта перед сохранением (в дополнение к атрибутам)
        /// При необходимости переопределяем в наследниках
        /// </summary>
        /// <param name="entity">Сохранияемый объект</param>
        /// <param name="modelState">Состояние модели для добавления ошибок</param>
        protected virtual void CustomValidateModelState(T entity, ModelStateDictionary modelState)
        {
            
        }
    }
}
