using boilerplate_netcore_api_mysql.Apps.Dtos.In;
using boilerplate_netcore_api_mysql.Apps.Dtos.Out;
using boilerplate_netcore_api_mysql.Apps.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Interfaces
{
    /// <summary>
    /// IPersonRepository
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Get detail by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PersonOutDtos> GetDetail(Guid Id);

        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<PersonOutDtos>> Gets();

        /// <summary>
        /// Create person
        /// </summary>
        /// <param name="personInDtos"></param>
        /// <returns></returns>
        Task<string> Create(PersonInDtos personInDtos);

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="personOutDtos"></param>
        /// <param name="personInDtos"></param>
        /// <returns></returns>
        Task Update(PersonOutDtos personOutDtos, PersonInDtos personInDtos);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="personOutDtos"></param>
        /// <returns></returns>
        Task Delete(PersonOutDtos personOutDtos);
    }
}
