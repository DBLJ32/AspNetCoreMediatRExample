using System;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook
{
    public class DeleteAddressRequest : IRequest
    {
        public Guid Id { get; set; }

        public DeleteAddressRequest(Guid id)
        {
            Id = id;
        }
    }
}
