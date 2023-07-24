using EmployeeDirectory.Application.DTOs;
using EmployeeDirectory.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeDirectory.Application.Interfaces.IRepository
{
    /// <summary>
    /// Интерфейс, описывающий методы операций над сотрудниками
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Получить список сотрудников
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <param name="hostUrl">Домен API</param>
        /// <returns>Список сотрудников</returns>
        Task<List<Employee>> GetAll(GetAllDTO dto, string hostUrl);
        /// <summary>
        /// Получить полную информацию о сотруднике
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="hostUrl">Домен API</param>
        /// <returns><see cref="Employee"/></returns>
        Task<Employee> GetById(Guid employeeId, string hostUrl);
        /// <summary>
        /// Поиск сотрудников
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <param name="hostUrl">Домен API</param>
        /// <returns>Список подходящих сотрудников</returns>
        Task<List<Employee>> Search(string query, string hostUrl);
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <returns>Идентификатор сотрудника</returns>
        Task<Guid> Add(AddEmployeeDTO dto);
        /// <summary>
        /// Загрузить/обновить фотографию сотрудника
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <param name="webRootPath">Корневой путь проекта</param>
        /// <param name="hostUrl">Домен API</param>
        /// <returns>Ссылка на загруженную фотографию</returns>
        Task<string> UploadPhoto(UploadPhotoDTO dto, string webRootPath, string hostUrl);
        /// <summary>
        /// Редактирование информации о сотруднике
        /// </summary>
        /// <param name="dto">Входные данные</param>
        Task Update(UpdateDetailsDTO dto);
        /// <summary>
        /// Удалить сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        Task Delete(Guid employeeId);
    }
}
