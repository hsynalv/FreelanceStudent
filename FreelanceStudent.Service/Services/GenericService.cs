using FreelanceStudent.Core.Dtos;
using FreelanceStudent.Core.Repositories;
using FreelanceStudent.Core.Services;
using FreelanceStudent.Core.UnitOfWork;
using FreelanceStudent.Service.Mapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FreelanceStudent.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto>
        where TEntity : class
        where TDto : class
    {

        private readonly IRepositoryBase<TEntity> _repositoryBase;
        private readonly IUnitOfWork _unitOfWork;

        public GenericService(IRepositoryBase<TEntity> repositoryBase, IUnitOfWork unitOfWork)
        {
            _repositoryBase = repositoryBase;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponse<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            await _repositoryBase.AddAsync(newEntity);
            await _unitOfWork.CommitAsync();
            var returnEntity = ObjectMapper.Mapper.Map<TDto>(newEntity);
            return CustomResponse<TDto>.Success(returnEntity, 201);
        }

        public async Task<CustomResponse<IEnumerable<TDto>>> GetAllAsync()
        {
            var entities = await _repositoryBase.GetAllAsync();
            var retunEntites = ObjectMapper.Mapper.Map<List<TDto>>(entities);
            return CustomResponse<IEnumerable<TDto>>.Success(retunEntites, 200);
        }

        public async Task<CustomResponse<TDto>> GetByIdAsync(int id)
        {
            var entity = await _repositoryBase.GetByIdAsync(id);
            if (entity is null)
            {
                return CustomResponse<TDto>.Fail("ID Not Found", 404);
            }

            var returnEntity = ObjectMapper.Mapper.Map<TDto>(entity);
            return CustomResponse<TDto>.Success(returnEntity, 200);
        }

        public async Task<CustomResponse<NoContent>> Remove(int id)
        {
            var isExistEntity = await _repositoryBase.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return CustomResponse<NoContent>.Fail("Id not found", 404);
            }

            _repositoryBase.Remove(isExistEntity);

            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContent>.Success(204);
        }

        public async Task<CustomResponse<NoContent>> Update(TDto entity, int id)
        {
            var isExistEntity = await _repositoryBase.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return CustomResponse<NoContent>.Fail("Id not found", 404);
            }

            var updateEntity = ObjectMapper.Mapper.Map<TEntity>(entity);
            _repositoryBase.Update(updateEntity);
            await _unitOfWork.CommitAsync();
            return CustomResponse<NoContent>.Success(204);

        }

        public async Task<CustomResponse<IEnumerable<TDto>>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            var list = _repositoryBase.Where(predicate);
            var returnEntities = ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync());
            return CustomResponse<IEnumerable<TDto>>.Success(returnEntities,200);
        }
    }
}
