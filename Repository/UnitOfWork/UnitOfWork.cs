using Core.UnitOfWorks;

namespace Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        // Entity Framework gibi ORM'ler, veritabanıyla etkileşimde bulunmak için nesne odaklı programlama tekniklerini kullanır.
        // Kod üzerinde yapılan değişiklikler (nesnelerin ekleme, güncelleme veya silme işlemleri),
        // veritabanına yansıtılmadan önce bir takım geçici bellek alanlarında tutulur. SaveChangesAsync metodu, bu geçici değişiklikleri veritabanına asenkron bir şekilde (yani beklemeksizin) kaydetmek için kullanılır.
        // Bu da, uygulamanın performansını artırabilir çünkü bu işlem sırasında diğer işlemlerle eş zamanlı olarak çalışılabilir. 
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext context)
        {
            _appDbContext = context;
        }

        public void Commit()
        {
            // değişiklikleri veri tabanına yansıt
            _appDbContext.SaveChanges(); // SaveChanges, Entity Framework gibi ORM'lerde veritabanına yapılan değişiklikleri kaydetmek için kullanılan bir metottur. Bu metot, asenkron olmayan bir şekilde çalışır ve veritabanındaki eşleşen veri öğelerini ekler, günceller veya siler.
        }

        public async Task CommitAsync()
        {
            // burada da değişiklikleri async olarak veri tabanına yansıt
            await _appDbContext.SaveChangesAsync(); // SaveChangesAsync, Entity Framework Core gibi ORM'lerde veritabanına yapılan değişiklikleri kaydetmek için kullanılan bir metottur. Bu metod, asenkron bir şekilde çalışır ve veritabanındaki eşleşen veri öğelerini ekler, günceller veya siler.
        }
    }
}
