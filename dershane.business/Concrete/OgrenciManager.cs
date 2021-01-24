using System.Collections.Generic;
using dershane.business.Abstract;
using dershane.data.Abstract;
using dershane.data.Concrete.EfCore;
using dershane.entity;
namespace dershane.business.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        private IOgrenciRepository _ogrenciRepository;
        public OgrenciManager(IOgrenciRepository ogrenciRepository)
        {
            _ogrenciRepository = ogrenciRepository;
        }

        

        public bool Create(Ogrenci entity)
        {
            if(Validation(entity)){
                 _ogrenciRepository.Create(entity);
                 return true;
            }
            return false;
           
        }

        public void Delete(Ogrenci entity)
        {
            // iş kuralları
            _ogrenciRepository.Delete(entity);
        }

        public List<Ogrenci> GetAll()
        {            
            return _ogrenciRepository.GetAll();
        }

        public Ogrenci GetById(int id)
        {
           return _ogrenciRepository.GetById(id);
        }

        public Ogrenci GetByIdWithBolumler(int id)
        {
            return _ogrenciRepository.GetByIdWithBolumler(id);
        }

        public int GetCountByBolum(string bolum)
        {
            return _ogrenciRepository.GetCountByBolum(bolum);
        }

        public List<Ogrenci> GetHomePagesOgrenciler()
        {
            return _ogrenciRepository.GetHomePageOgrenciler();
        }

        public Ogrenci GetOgrenciDetails(string url)
        {
            return _ogrenciRepository.GetOgrenciDetails(url);
        }

        public List<Ogrenci> GetOgrencilerByBolum(string name,int page,int pageSize)
        {
            return _ogrenciRepository.GetOgrencilerByBolum(name,page,pageSize);
        }

        public List<Ogrenci> GetSearchResult(string searchString)
        {
            return _ogrenciRepository.GetSearchResult(searchString);
        }

        public void Update(Ogrenci entity)
        {
            _ogrenciRepository.Update(entity);
        }

        public bool Update(Ogrenci entity, int[] bolumIds)
        {
            if(Validation(entity)){
                if(bolumIds.Length==0)
                {
                    ErrorMessage += "Öğrenci için bir kategori seçmelisiniz.";
                    return false;
                }
                _ogrenciRepository.Update(entity,bolumIds);
                return true;
            }
            return false;
        }
        public string ErrorMessage { get; set; }
        public bool Validation(Ogrenci entity)
        {
            var isValid = true;
            if(string.IsNullOrEmpty(entity.Name)){
                ErrorMessage += "Öğrenci ismi girmelisiniz.\n";
                isValid= false;
            }

            if(entity.Sınıf<0){
                ErrorMessage += "Öğrenci Sınıfı negatif olamaz.\n";
                isValid= false;
            }


            return isValid;
        }
    }
}