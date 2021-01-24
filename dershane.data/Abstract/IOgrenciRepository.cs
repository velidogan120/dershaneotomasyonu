using dershane.entity;
using System.Collections.Generic;
namespace dershane.data.Abstract
{
    public interface IOgrenciRepository:IRepository<Ogrenci>
    {
        Ogrenci GetOgrenciDetails(string url);
        Ogrenci GetByIdWithBolumler(int id);
        List<Ogrenci> GetOgrencilerByBolum(string name,int page,int pageSize);

        List<Ogrenci> GetSearchResult(string searchString);

        List<Ogrenci> GetHomePageOgrenciler();
        int GetCountByBolum(string bolum);

        void Update(Ogrenci entity, int[] bolumIds);

    }
}