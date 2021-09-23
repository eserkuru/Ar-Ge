using Microsoft.Extensions.Localization;

namespace Util.Localization
{
    public interface ILanguageService<T>: IStringLocalizer<T>
    {
    }
}
