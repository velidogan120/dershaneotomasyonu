using System.Collections.Generic;
using System.Linq;
using dershane.data.Abstract;
using dershane.entity;
using Microsoft.EntityFrameworkCore;

namespace dershane.data.Concrete.EfCore
{
    public class EfCoreOgrenciRepository:EfCoreGenericRepository<Ogrenci,DershaneContext>,IOgrenciRepository
    {
        public Ogrenci GetByIdWithBolumler(int id)
        {
            using(var context = new DershaneContext()){
                return context.Ogrenciler.Where(i=>i.OgrenciId == id).Include(i=>i.OgrenciBolumler).ThenInclude(i=>i.Bolum).FirstOrDefault();
            }
        }

        public int GetCountByBolum(string bolum)
        {
           using(var context = new DershaneContext()){
                
                var ogrenciler = context.Ogrenciler.Where(i=>i.IsApproved).AsQueryable();
                
                if(!string.IsNullOrEmpty(bolum)){
                    
                    ogrenciler = ogrenciler
                            .Include(i=>i.OgrenciBolumler)
                            .ThenInclude(i=>i.Bolum)
                            .Where(i=>i.OgrenciBolumler.Any(a=>a.Bolum.Url==bolum));

                }

                return ogrenciler.Count();
            }
        }

        public List<Ogrenci> GetHomePageOgrenciler()
        {
            using(var context = new DershaneContext()){
                return context.Ogrenciler.Where(i=>i.IsApproved && i.IsHome).ToList();
            }
        }

        public Ogrenci GetOgrenciDetails(string url)
        {
            using(var context = new DershaneContext()){
                return context.Ogrenciler.Where(i=>i.Url==url).Include(id=>id.OgrenciBolumler).ThenInclude(id=>id.Bolum).FirstOrDefault();
            }
        }

        public List<Ogrenci> GetOgrencilerByBolum(string name,int page,int pageSize)
        {
            using(var context = new DershaneContext()){
                
                var ogrenciler = context.Ogrenciler.Where(i=>i.IsApproved).AsQueryable();
                
                if(!string.IsNullOrEmpty(name)){
                    
                    ogrenciler = ogrenciler
                            .Include(i=>i.OgrenciBolumler)
                            .ThenInclude(i=>i.Bolum)
                            .Where(i=>i.OgrenciBolumler.Any(a=>a.Bolum.Url==name));

                }

                return ogrenciler.Skip((page-1)*pageSize).Take(pageSize).ToList();
            }

        }

        public Ogrenci GetOgrencilerDetails(string name)
        {
            throw new System.NotImplementedException();
        }

        public List<Ogrenci> GetSearchResult(string searchString)
        {
             using(var context = new DershaneContext()){
                
                var ogrenciler = context.Ogrenciler.Where(i=>i.IsApproved && (i.Name.ToLower().Contains(searchString.ToLower()) || i.Description.ToLower().Contains(searchString.ToLower()))).AsQueryable();
                                
                return ogrenciler.ToList();
            }
        }

        public void Update(Ogrenci entity, int[] bolumIds)
        {
            using(var context = new DershaneContext()){
                var ogrenci= context.Ogrenciler.Include(i=>i.OgrenciBolumler).FirstOrDefault(i=>i.OgrenciId==entity.OgrenciId);


                if(ogrenci!=null){
                    ogrenci.Name=entity.Name;
                    ogrenci.Sınıf=entity.Sınıf;
                    ogrenci.Description=entity.Description;
                    ogrenci.Url=entity.Url;
                    ogrenci.ImageUrl = entity.ImageUrl;
                    ogrenci.IsApproved=entity.IsApproved;
                    ogrenci.IsHome=entity.IsHome;


                    ogrenci.OgrenciBolumler = bolumIds.Select(bolIds=>new OgrenciBolum(){
                        OgrenciId=entity.OgrenciId,
                        BolumId=bolIds

                    }).ToList();
                    context.SaveChanges();

                }
            }
        }
    }
}