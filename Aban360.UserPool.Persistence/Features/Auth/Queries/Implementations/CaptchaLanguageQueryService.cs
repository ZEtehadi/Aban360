﻿using Aban360.Common.Extensions;
using Aban360.UserPool.Domain.Features.Auth.Entities;
using Aban360.UserPool.Persistence.Contexts.UnitOfWork;
using Aban360.UserPool.Persistence.Features.Auth.Queries.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Aban360.UserPool.Persistence.Features.Auth.Queries.Implementations
{
    internal sealed class CaptchaLanguageQueryService : ICaptchaLanguageQueryService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<CaptchaLanguage> _captchaLanguages;
        public CaptchaLanguageQueryService(IUnitOfWork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(uow));

            _captchaLanguages = _uow.Set<CaptchaLanguage>();
            _captchaLanguages.NotNull();
        }
        public async Task<ICollection<CaptchaLanguage>> Get()
        {
            return await _captchaLanguages.ToListAsync();
        }

        public async Task<CaptchaLanguage> Get(short id)
        {
            return await _uow.FindOrThrowAsync<CaptchaLanguage>(id);
        }
    }
}