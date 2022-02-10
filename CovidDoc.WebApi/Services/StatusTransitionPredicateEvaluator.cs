using CovidDoc.Model;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace CovidDoc.WebApi.Services
{
    /// <summary>
    /// Сервис вычисления предиката в контексте документа и текущего пользователя
    /// </summary>
    public class StatusTransitionPredicateEvaluator
    {

        /// <summary>
        /// Вычислить значение предиката
        /// </summary>
        /// <param name="document">Контекстный документ</param>
        /// <param name="appUser">Пользователь</param>
        /// <param name="predicateSource">Исходный текст предиката</param>
        /// <returns></returns>
        public bool Evaluate(Document document, AppUser appUser, string predicateSource)
        {
            var result = !(string.IsNullOrEmpty(predicateSource) || appUser == null || document == null);
            if (result)            
            {
                Func<Document, AppUser, bool> predicate = CompilePredicateSource(predicateSource).Result;
                result = predicate(document, appUser);
            }
            return result;
        }

        private async Task<Func<Document, AppUser, bool>> CompilePredicateSource(string predicateSource)
        {
            var options = ScriptOptions.Default.AddReferences(typeof(Document).Assembly);

            return await CSharpScript.EvaluateAsync<Func<Document, AppUser, bool>>(predicateSource, options);
        }
    }
}
