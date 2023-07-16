using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDirectory.Application.DTOs
{
    /// <summary>
    /// DTO для загрузки фотографии сотрудника
    /// </summary>
    public class UploadPhotoDTO
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Required(ErrorMessage = "Идентификатор сотрудника обязателен")]
        public Guid UserId { get; set; }
        /// <summary>
        /// Фотография сотрудника
        /// </summary>
        [Required(ErrorMessage = "Фотография обязательна")]
        public IFormFile Photo { get; set; }
    }
}
