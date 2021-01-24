using System.Collections.Generic;
using dershane.business.Abstract;
using dershane.data.Abstract;
using dershane.data.Concrete.EfCore;
using dershane.entity;
namespace dershane.business.Concrete
{
    public class BolumManager : IBolumService
    {
        private IBolumRepository _bolumRepository;
        public BolumManager(IBolumRepository bolumRepository)
        {
            _bolumRepository = bolumRepository;
        }

        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(Bolum entity)
        {
            _bolumRepository.Create(entity);
        }

        public void Delete(Bolum entity)
        {
            _bolumRepository.Delete(entity);
        }

        public void DeleteFromBolum(int ogrenciId, int bolumId)
        {
           _bolumRepository.DeleteFromBolum(ogrenciId,bolumId);
        }

        public List<Bolum> GetAll()
        {
            return _bolumRepository.GetAll();
        }

        public Bolum GetById(int id)
        {
            return _bolumRepository.GetById(id);
        }

        public Bolum GetByIdWithOgrenciler(int bolumId)
        {
            return _bolumRepository.GetByIdWithOgrenciler(bolumId);
        }

        public void Update(Bolum entity)
        {
            _bolumRepository.Update(entity);
        }

        public bool Validation(Bolum entity)
        {
            throw new System.NotImplementedException();
        }
    }
}