﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Structure.Contract.Services.Product.Validators
{
    public class DeleteProductValidator : AbstractValidator<Command.DeleteProduct>
    {
        public DeleteProductValidator()
        {
            RuleFor(x => x.id).NotEmpty();
        }
    }
}
