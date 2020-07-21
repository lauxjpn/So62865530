using System;
using System.Security.Claims;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public Guid UserId { get; }
        public bool IsAuthenticated { get; }
    
        public CurrentUserService(IHttpContextAccessor httpContextAccessor) {
            var claim = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    
            IsAuthenticated = claim != null;
            UserId = IsAuthenticated ? Guid.Parse(claim) : Guid.Empty;
        }
    }
}