using System.Collections.Generic;
using dershane.entity;
namespace dershane.data.Abstract
{
    public interface IBolumRepository:IRepository<Bolum>
    {
        Bolum GetByIdWithOgrenciler(int bolumId);
        void DeleteFromBolum(int ogrenciId,int bolumId);

    }
}