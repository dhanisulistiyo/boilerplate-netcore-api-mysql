using AutoMapper;
using AutoMapper.QueryableExtensions;
using boilerplate_netcore_api_mysql.Apps.Dtos.In;
using boilerplate_netcore_api_mysql.Apps.Dtos.Out;
using boilerplate_netcore_api_mysql.Apps.Interfaces;
using boilerplate_netcore_api_mysql.Apps.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace boilerplate_netcore_api_mysql.Apps.Repository
{
    /// <summary>
    /// PersonRepository
    /// </summary>
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mapper"></param>
        public PersonRepository(DataSource db, IMapper mapper) : base(db, mapper)
        {
        }

        /// <summary>
        /// GetDetail by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<PersonOutDtos> GetDetail(Guid Id) => await _db.Person.ProjectTo<PersonOutDtos>(_mapper.ConfigurationProvider).AsNoTracking().SingleOrDefaultAsync(x => x.Id == Id);

        /// <summary>
        /// Get list
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PersonOutDtos>> Gets() => await _db.Person.ProjectTo<PersonOutDtos>(_mapper.ConfigurationProvider).AsNoTracking().ToListAsync();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="personInDtos"></param>
        /// <returns></returns>
        public async Task<string> Create(PersonInDtos personInDtos)
        {
            var data = _mapper.Map<Person>(personInDtos);
            Add(data);
            await SaveAsync();
            return data.Name;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="personOutDtos"></param>
        /// <param name="personInDtos"></param>
        /// <returns></returns>
        public async Task Update(PersonOutDtos personOutDtos, PersonInDtos personInDtos)
        {
            var data = _mapper.Map<Person>(personOutDtos);
            data.Name = personInDtos.Name;
            Update(entity: data);
            await SaveAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="personOutDtos"></param>
        /// <returns></returns>
        public async Task Delete(PersonOutDtos personOutDtos)
        {
            var data = _mapper.Map<Person>(personOutDtos);
            Remove(entity: data);
            await SaveAsync();
        }
    }
}
