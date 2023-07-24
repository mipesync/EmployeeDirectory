using System;

namespace EmployeeDirectory.Application.Exceptions
{
    /// <summary>
    /// Исключение, говорящее о том, что объект уже существует
    /// </summary>
    public class AlreadyExistException : Exception
    {
        /// <summary>
        /// Исключение с кастомным текстом
        /// </summary>
        /// <param name="message">Текст ошибки</param>
        public AlreadyExistException(string message): base(message) { }
    }
}
