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
        /// <returns>Список сотрудников</returns>
        List<Employee> GetAll(GetAllDTO dto);
        /// <summary>
        /// Получить полную информацию о сотруднике
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <returns><see cref="Employee"/></returns>
        Employee GetById(Guid employeeId);
        /// <summary>
        /// Поиск сотрудников
        /// </summary>
        /// <param name="query">Строка запроса</param>
        /// <returns>Список подходящих сотрудников</returns>
        List<Employee> Search(string query);
        /// <summary>
        /// Добавить сотрудника
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <returns>Идентификатор сотрудника</returns>
        Guid Add(AddEmployeeDTO dto);
        /// <summary>
        /// Загрузить/обновить фотографию сотрудника
        /// </summary>
        /// <param name="dto">Входные данные</param>
        /// <param name="webRootPath">Корневой путь проекта</param>
        /// <param name="hostUrl">Домен API</param>
        /// <returns>Ссылка на загруженную фотографию</returns>
        string UploadPhoto(UploadPhotoDTO dto, string webRootPath, string hostUrl);
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
