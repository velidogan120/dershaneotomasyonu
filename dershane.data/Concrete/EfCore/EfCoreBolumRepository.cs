using System.Collections.Generic;
using System.Linq;
using dershane.data.Abstract;
using dershane.entity;
using Microsoft.EntityFrameworkCore;

namespace dershane.data.Concrete.EfCore
{
    public class EfCoreBolumRepository : EfCoreGenericRepository<Bolum, DershaneContext>, IBolumRepository
    {
        public void DeleteFromBolum(int ogrenciId, int bolumId)
        {
            using(var context = new DershaneContext()){
                var cmd ="delete from ogrencibolum where OgrenciId=@p0 and BolumId=@p1";
                context.Database.ExecuteSqlRaw(cmd,ogrenciId,bolumId);
            }
        }

        public Bolum GetByIdWithOgrenciler(int bolumId)
        {
           using(var context = new DershaneContext()){
               return context.Bolumler.Where(i=>i.BolumId==bolumId).Include(i=>i.OgrenciBolumler).ThenInclude(i=>i.Ogrenci).FirstOrDefault();
           }
        }
       
    }
}