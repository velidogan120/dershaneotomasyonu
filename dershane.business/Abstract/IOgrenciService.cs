using System.Collections.Generic;
using dershane.entity;

namespace dershane.business.Abstract
{
    public interface IOgrenciService:IValidator<Ogrenci>
    {
        Ogrenci GetById(int id);
        Ogrenci GetByIdWithBolumler(int id);
        Ogrenci GetOgrenciDetails(string url);
        List<Ogrenci> GetOgrencilerByBolum(string name,int page,int pageSize);
        List<Ogrenci> GetHomePagesOgrenciler();
        List<Ogrenci> GetSearchResult(string searchString);
        List<Ogrenci> GetAll();
        bool Create (Ogrenci entity);
        void Update (Ogrenci entity);
        void Delete (Ogrenci entity);
        int GetCountByBolum(string bolum);
        bool Update(Ogrenci entity, int[] bolumIds);
    }
}