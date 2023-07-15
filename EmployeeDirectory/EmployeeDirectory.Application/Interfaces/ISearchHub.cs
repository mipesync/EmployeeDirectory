using System.Threading.Tasks;

namespace EmployeeDirectory.Application.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий хаб поиска
    /// </summary>
    public interface ISearchHub
    {
        /// <summary>
        /// Метод поиска
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Результат поиска по запросу</returns>
        Task Search(string query);
    }
}