using EmployeeDirectory.Application.Interfaces;
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
        public async Task Search(string query)
        {
            await this.Clients.All.SendAsync("SearchResult", query);
        }
    }
}
