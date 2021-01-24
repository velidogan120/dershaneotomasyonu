using System.Linq;
using Microsoft.EntityFrameworkCore;
using dershane.entity;
namespace dershane.data.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed(){
            var context = new DershaneContext();
            if(context.Database.GetPendingMigrations().Count()==0){
                if(context.Bolumler.Count()==0){
                    context.Bolumler.AddRange(Bolumler);
                } 
                if(context.Ogrenciler.Count()==0){
                    context.Ogrenciler.AddRange(Ogrenciler);
                    context.AddRange(OgrenciBolumler);
                }

            }
            context.SaveChanges();    
        }
        private static Bolum[] Bolumler={
            new Bolum(){Name="Sayısal",Url="sayısal"},
            new Bolum(){Name="Sözel",Url="sözel"},
            new Bolum(){Name="Eşit Ağırlık",Url="esit-agırlık"},
            new Bolum(){Name="Yabancı Dil",Url="yabancı-dil"}
        };
        private static Ogrenci[] Ogrenciler={
            new Ogrenci(){Name="Ali",Url="ali",Sınıf=9,ImageUrl="2.jpg",Description="orta",IsApproved=true},
            new Ogrenci(){Name="Veli",Url="veli",Sınıf=12,ImageUrl="3.jpg",Description="orta",IsApproved=false},
            new Ogrenci(){Name="Ayşe",Url="ayse",Sınıf=10,ImageUrl="4.jpg",Description="orta",IsApproved=true},
            new Ogrenci(){Name="Melis",Url="melis",Sınıf=10,ImageUrl="5.jpg",Description="orta",IsApproved=false},
            new Ogrenci(){Name="Meral",Url="meral",Sınıf=11,ImageUrl="6.jpg",Description="orta",IsApproved=true},
           
        };

        private static OgrenciBolum[] OgrenciBolumler={
            new OgrenciBolum(){Ogrenci=Ogrenciler[0],Bolum=Bolumler[0]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[0],Bolum=Bolumler[2]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[1],Bolum=Bolumler[0]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[1],Bolum=Bolumler[2]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[2],Bolum=Bolumler[0]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[2],Bolum=Bolumler[2]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[3],Bolum=Bolumler[0]},
            new OgrenciBolum(){Ogrenci=Ogrenciler[3],Bolum=Bolumler[2]}
        };
        
    }
}