using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook
{
    public class UpdateAddressHandler : IRequestHandler<UpdateAddressRequest>
    {
        private readonly IRepo<AddressBookEntry> _repo;

        public UpdateAddressHandler(IRepo<AddressBookEntry> repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(UpdateAddressRequest request, CancellationToken cancellationToken)
        {
            var entry = _repo.GetById(request.Id);
            if (entry != null)
            {
                entry.Update(request.Line1, request.Line2, request.City, request.State, request.PostalCode);
                _repo.Update(entry);
            }

            return await Task.FromResult(Unit.Value);
        }
    }
}