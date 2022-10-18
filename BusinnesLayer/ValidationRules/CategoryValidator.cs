﻿using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçilmez");
            RuleFor(x=>x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş geçilmez");
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adı en fazla 50 karakter olmalı");
            RuleFor(x=>x.CategoryName).NotEmpty().WithMessage("Kategori adı en az 2 karakter olmalı");

        }
    }
}
