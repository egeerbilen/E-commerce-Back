using API.Controllers;
using Core.DTOs;
using Entity.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace JwtInDotnetCore.Controllers
{
    public class UserLoginController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;
        private static readonly TimeSpan CacheDuration = TimeSpan.FromSeconds(10);

        public UserLoginController(IUserService service, IMemoryCache memoryCache)
        {
            _userService = service;
            _cache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserLoginRequestDto userLoginRequest)
        {
            var cacheKey = $"UserJwtToken_{userLoginRequest.Email}";

            if (!_cache.TryGetValue(cacheKey, out CustomResponseDto<string> jwtToken))
            {
                jwtToken = await _userService.GenerateJwtTokenAsync(userLoginRequest);
                if (jwtToken.Data == null) {
                    return CreateActionResult(CustomResponseDto<string>.Fail(401, jwtToken.Errors));
                }

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = CacheDuration
                };

                _cache.Set(cacheKey, jwtToken, cacheEntryOptions);
            }
            else
            {
                jwtToken = _cache.Get<CustomResponseDto<string>>(cacheKey);
            }

            return CreateActionResult(CustomResponseDto<string>.Success(200, jwtToken.Data));
        }
    }
}
