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

        public BaseController(ILogger<BaseController<T>> logger, CovidDocModel dbContext, SecurityService securityService): base()
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
                if (SecurityService.ReadGranted(entity, GetAppUser()))
                {
                    Logger.LogDebug($@"Запрошен объект {typeof(T).Name} с ключом {id}");
                    return Ok(entity);
                }
                else
                {
                    Logger.LogDebug($@"Доступ к объекту {entity} запрещен системой безопасности");
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
                if (SecurityService.DeleteGranted(entity, GetAppUser()))
                {
                    DbContext.Remove<T>(entity);
                    await DbContext.SaveChangesAsync();
                    Logger.LogDebug($@"Удален объект {typeof(T).Name} {entity}");
                    return Ok(entity);
                }
                else
                {
                    Logger.LogDebug($@"Удаление объекта {typeof(T).Name} {entity} запрещено системой безопасности");
                    return Unauthorized(entity);
                }
            }
        }

        private AppUser GetAppUser()
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
                if (SecurityService.CreateGranted(entity, GetAppUser()))
                {
                    CustomValidateModelState(entity, ModelState);
                    if (!ModelState.IsValid)
                        return BadRequest(ModelState);

                    await DbContext.AddAsync<T>(entity);
                    await DbContext.SaveChangesAsync();

                    var key = (long)entity.GetType().GetProperty("Id").GetValue(entity);

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
        /// Пользовательская проверка объекта перед сохранением (в дополнение к атрибутам)
        /// </summary>
        /// <param name="entity">Сохранияемый объект</param>
        /// <param name="modelState">Состояние модели для добавления ошибок</param>
        protected virtual void CustomValidateModelState(T entity, ModelStateDictionary modelState)
        {
            
        }
    }
}
