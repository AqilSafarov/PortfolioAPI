using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioApi.Api.Client.DTOs.ContactMessageDto
{
    public class MessageCreateDto
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

    public class MessageCreateDtoValidator : AbstractValidator<MessageCreateDto>
    {
        public MessageCreateDtoValidator()
        {
            RuleFor(x => x.Fullname).MaximumLength(100);
            RuleFor(x => x.Email).MaximumLength(50).NotEmpty();
            RuleFor(x => x.Subject).MaximumLength(100);
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bos ola bilmez");



        }
    }
}
