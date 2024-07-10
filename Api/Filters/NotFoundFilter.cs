using Core.DTOs;
using Core.Model;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NLayer.API.Filters
{
    // Bu NotFoundFilter<T> filtresi, belirli bir ID'ye sahip bir varlık (entity) olup olmadığını kontrol eder.
    // Eğer bu ID'ye sahip bir varlık bulunamazsa, filtre bir 404 Not Found hatası döndürür. 
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {

        private readonly IGenericService<T, T> _service;

        public NotFoundFilter(IGenericService<T, T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) // her hangi bir filtr a takılmaz ise next diyip devam edeceğiz
        {
            // context uygulamanın kalbi tüm bu context den request ve responslara erişe bilirim
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            int id = 0;

            if (idValue != null)
            {
                if (idValue is int intValue)
                {
                    id = intValue;
                }
                else
                {
                    var propertyInfo = idValue.GetType().GetProperty("Id");
                    if (propertyInfo?.GetValue(idValue) is int propValue)
                    {
                        id = propValue;
                    }
                }
            }


            var anyEntity = await _service.AnyAsync(x => x.Id == id && !x.IsDeleted); // id var mı yok mu kontrol edecek 
            // GetByIdAsync belirli bir ID'ye sahip bir öğeyi getirmek için kullanılır. Eğer bir öğenin belirli bir kimliğiyle bir varlık almak istiyorsanız, GetByIdAsync kullanmak daha uygundur. Bu yöntem, bir öğe varsa onu döndürür veya null döner.
            // AnyAsync, belirli bir koşula sahip herhangi bir öğe olup olmadığını kontrol etmek için kullanılır.Bu metot, verilen koşulu karşılayan herhangi bir öğe varsa true döndürür; aksi takdirde false döner.Özellikle bir öğenin kendisini almak yerine, bir koşulu kontrol etmek istediğinizde kullanışlıdır.
            // Eğer belirli bir ID'ye sahip bir varlık almak istiyorsanız, GetByIdAsync kullanmak daha doğru olabilir. Ancak eğer sadece belirli bir koşulu kontrol etmek istiyorsanız ve öğenin kendisine ihtiyacınız yoksa, AnyAsync kullanabilirsiniz.
            // çünkü GetByIdAsync Id ile eşleşen öğeyi döndürür veya eşleşen bir öğe bulunamazsa null değer döndürür.
            // AnyAsync Bir koleksiyon içinde belirli bir koşulu sağlayan öğenin varlığını kontrol etmek için kullanılır. Bu metot sadece bir bool sonucu döndürür; belirtilen koşulu sağlayan bir öğe varsa true, aksi takdirde false döner.

            if (anyEntity.Data)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(CustomResponseDto<NoContentDto>.Fail(404, $"{typeof(T).Name}({id}) not found"));

        }
    }
}
