using CovidDoc.Model;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CovidDoc.WebApi.Services
{
    /// <summary>
    /// Обоработчик для машины состояний
    /// </summary>
    public class StateMachineService
    {
        public CovidDocModel DbContext { get; }
        public StatusTransitionPredicateEvaluator PredicateEvaluator { get; }

        public StateMachineService(CovidDocModel dbContext, StatusTransitionPredicateEvaluator predicateEvaluator)
        {
            DbContext = dbContext;
            PredicateEvaluator = predicateEvaluator;
        }

        /// <summary>
        /// Получить все возможные переходы для текущего состояния документа
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        private IEnumerable<StatusTransition> GetForwardTransitions(Document document) =>
            DbContext.Document.FirstOrDefault(x => x.Id == document.Id)
                .DocumentStatus?.FromTransitions ?? new List<StatusTransition>();

        /// <summary>
        /// Определить все переходы состояния разрешенные для текущего пользователя
        /// </summary>
        /// <param name="document"></param>
        /// <param name="currentUser"></param>
        /// <returns></returns>
        private IEnumerable<StatusTransition> GetGrantedForwardTransitions(Document document, AppUser currentUser) =>
            GetForwardTransitions(document).Where(x => currentUser != null && x.GrantedForRoles.Intersect(currentUser.Roles).Any());

        /// <summary>
        /// Определить разрешенные переходы для документа
        /// </summary>
        /// <param name="document">Документ</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public IEnumerable<StatusTransition> GetValidForwardTransitions(Document document, AppUser currentUser) =>
            GetGrantedForwardTransitions(document, currentUser)
                .Where(x => PredicateEvaluator.Evaluate(document, currentUser, 
                    x.EnablePredicate ?? "(doc, appUser) => true"));

        /// <summary>
        /// Определить разрешенные автопереходы для документа
        /// </summary>
        /// <param name="document">Документ</param>
        /// <param name="currentUser">Текущий пользователь</param>
        /// <returns></returns>
        public IEnumerable<StatusTransition> GetAutoForwardTransitions(Document document, AppUser currentUser) =>
            GetValidForwardTransitions(document, currentUser)
             .Where(x => PredicateEvaluator.Evaluate(document, currentUser,
                    x.AutoRunPredicate ?? "(doc, appUser) => false"));
    }
}
