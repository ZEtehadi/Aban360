﻿using Aban360.BlobPool.Domain.Features.Taxonomy.Entities;
using Aban360.BlobPool.Persistence.Contexts.Contracts;
using Aban360.Common.Db.DbSeeder.Contracts;
using Aban360.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Aban360.BlobPool.Persistence.DbSeeder.Implementations
{
    public class DocumentCategorySeeder : IDataSeeder
    {
        public int Order { get; set; } = 10;
        private readonly IUnitOfwork _uow;
        private readonly DbSet<DocumentCategory> _documentCategorys;
        public DocumentCategorySeeder(IUnitOfwork uow)
        {
            _uow = uow;
            _uow.NotNull(nameof(_uow));

            _documentCategorys = _uow.Set<DocumentCategory>();
            _documentCategorys.NotNull(nameof(_documentCategorys));
        }


        public void SeedData()
        {
            if (_documentCategorys.Any())
            {
                return;
            }

            ICollection<DocumentCategory> documentCategorys = new List<DocumentCategory>()
            {
                new DocumentCategory(){Id=1,Title="مجوز ها",Icon="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"},
                new DocumentCategory(){Id=2,Title="ساختمان",Icon="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"},
                new DocumentCategory(){Id=3,Title="ارزیابی",Icon=""},
                new DocumentCategory(){Id=4,Title="کروکی",Icon=""},
                new DocumentCategory(){Id=5,Title="سایر",Icon=""},
            };
            _documentCategorys.AddRange(documentCategorys);
            _uow.SaveChanges();

        }
    }
}
