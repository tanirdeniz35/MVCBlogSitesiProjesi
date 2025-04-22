using AutoMapper;
using BlogSitesi.BL.DTO;
using BlogSitesi.BL.Managers.Abstract;
using BlogSitesi.BL.MappingProfiles;
 
using BlogSitesi.DAL.Entities.Common;
using BlogSitesi.DAL.Repositories.Abstract;
using BlogSitesi.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogSitesi.BL.Managers.Concrete
{
    public class Manager<Tmodel, Tentity> : IManager<Tmodel, Tentity>
        where Tmodel : BaseDTOModel
        where Tentity : BaseEntity
    {
        private readonly Repository<Tentity> _repository;
        private readonly Mapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;
        public Manager(Repository<Tentity> repository)
        {
            _repository = repository;
            ManagerMappingProfile managerMappingProfile = new ManagerMappingProfile();
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(managerMappingProfile);
            }
            );
            _mapper = new Mapper(_mapperConfiguration);
        }



        public int Add(Tmodel entity)
        {
            return _repository.Add(_mapper.Map<Tentity>(entity));
        }

        public List<Tmodel> GetAll()
        {
            return _mapper.Map<List<Tmodel>>(_repository.GetAll().ToList());
        }

        public Tmodel GetById(int id)
        {
            return _mapper.Map<Tmodel>(_repository.GetById(id));
        }

        public Tmodel GetSingle(Expression<Func<Tentity, bool>> predicate)
        {
            return _mapper.Map<Tmodel>(_repository.GetSingle(predicate));
        }

        public List<Tmodel> GetWhere(Expression<Func<Tentity, bool>> predicate)
        {
            return _mapper.Map<List<Tmodel>>(_repository.GetWhere(predicate).ToList());
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Remove(Tmodel entity)
        {
            _repository.Remove(_mapper.Map<Tentity>(entity));
        }

        public void Update(Tmodel entity)
        {
            _repository.Update(_mapper.Map<Tentity>(entity));
        }
    }
}
