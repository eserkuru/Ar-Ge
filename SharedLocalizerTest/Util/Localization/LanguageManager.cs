using System.Diagnostics;
using Microsoft.Extensions.Localization;

namespace Util.Localization
{
    public class LanguageManager : ILanguageService
    {
        private readonly IStringLocalizerFactory _factory;

        public LanguageManager(IStringLocalizerFactory factory)
        {
            _factory = factory;
        }

        public string Core(string text)
        {
            var _localizer = _factory.Create("CoreResource", "Core");
            return _localizer[text];
        }

        public string Shared(string text)
        {
            var stackTrace = new StackTrace();
            var callerMethod = stackTrace.GetFrame(1).GetMethod();
            var assemblyName = callerMethod.ReflectedType.Assembly.GetName();
            var _localizer = _factory.Create("SharedResource", assemblyName.Name);

            return _localizer[text];
        }

        public string Local(string text)
        {
            var stackTrace = new StackTrace();
            var callerMethod = stackTrace.GetFrame(1).GetMethod();
            var _localizer = _factory.Create(callerMethod.DeclaringType);

            return _localizer[text];
        }
    }
}
