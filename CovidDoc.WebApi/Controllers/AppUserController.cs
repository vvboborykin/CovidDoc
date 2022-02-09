using CovidDoc.Model;
using CovidDoc.WebApi.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidDoc.WebApi.Controllers
{
    /// <summary>
    /// WebApi контроллер для класса EF модели AppUser (Пользователь приложения)
    /// </summary>
    public partial class AppUserController : BaseController<AppUser>
    {
        public AppUserController(ILogger<AppUserController> logger, CovidDoc.Model.CovidDocModel dbContext, SecurityService securityService)
            : base(logger, dbContext, securityService)
        {
        }
    }
}
