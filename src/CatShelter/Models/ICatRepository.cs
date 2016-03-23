using CatShelter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatShelter.Models
{
    public interface ICatRepository
    {
        CatListVM[] GetAll();
    }

    public class DBCatsRepository : ICatRepository
    {
        CatShelterContext context;
        public DBCatsRepository(CatShelterContext context)
        {
            this.context = context;
        }
        public CatListVM[] GetAll()
        {
            return context.Cats
                .OrderBy(o => o.Name)
                .Select(o => new CatListVM
                {
                    Name = o.Name,
                    Friendly = o.Kindness < 60 ? true : false
                })
                .ToArray();
        }
    }

    public class TestCatRepository : ICatRepository
    {
        public CatListVM[] GetAll()
        {
            return new CatListVM[]
                {
                    new CatListVM { Name = "Manne", Friendly = true},
                    new CatListVM { Name = "Severin", Friendly = true},
                    new CatListVM { Name = "Tom", Friendly = false}
                };
        }
    }
}
