using AutoMapper;
using Core.DTOs;
using Core.Repositories;
using Core.UnitOfWorks;
using Entity.Model;
using Entity.Repositories;
using Entity.Services;
using Service.Services;

namespace Bussines.Services
{
    public class RoleService : GenericService<Role, RoleDto>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IGenericRepository<Role> repository, IUnitOfWork unitOfWork, IMapper mapper, IRoleRepository roleRepository) : base(repository, unitOfWork, mapper)
        {
            _roleRepository = roleRepository;
        }
    }
}
