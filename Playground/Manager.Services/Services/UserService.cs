using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.DTO;
using Manager.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null)
                throw new DomainException("Já existe um usuário com o email cadastrado !");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            return _mapper.Map<UserDTO>(await _userRepository.Create(user));
        }

        public async Task<UserDTO> Get(long id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.Get(id));
        }

        public async Task<List<UserDTO>> Get()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.Get());
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetByEmail(email));
        }

        public async Task Remove(long id)
        {
            await _userRepository.Remove(id);
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.SearchByEmail(email));
        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.SearchByName(name));
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.Get(userDTO.Id);

            if (userExists == null)
                throw new DomainException("Não existe nenhum usuário com o id informado !");

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            return _mapper.Map<UserDTO>(await _userRepository.Update(user));
        }
    }
}
