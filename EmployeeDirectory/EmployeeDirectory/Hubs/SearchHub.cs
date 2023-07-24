using EmployeeDirectory.Application.Interfaces;
using EmployeeDirectory.Application.Interfaces.IRepository;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Hubs
{
    /// <summary>
    /// Хаб для "живого" поиска сотрудников
    /// </summary>
    /// <inheritdoc/>
    public class SearchHub : Hub, ISearchHub
    {
        private string UrlRaw => 
            $"{Context.GetHttpContext().Request.Scheme}://{Context.GetHttpContext().Request.Host}";
        private readonly IEmployeeRepository _employeeRepository;

        public SearchHub(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task Search(string query)
        {
            var result = await _employeeRepository.Search(query, UrlRaw);
            await this.Clients.All.SendAsync("Search", result);
        }
    }
}
