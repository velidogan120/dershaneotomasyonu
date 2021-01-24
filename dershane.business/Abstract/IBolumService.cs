using System.Collections.Generic;
using dershane.entity;
namespace dershane.business.Abstract
{
    public interface IBolumService:IValidator<Bolum>
    {
         Bolum GetById(int id);
         Bolum GetByIdWithOgrenciler(int bolumId);
         List<Bolum> GetAll();
         void Create (Bolum entity);
         void Update (Bolum entity);
         void Delete (Bolum entity);
         void DeleteFromBolum(int ogrenciId,int bolumId);
    }
}