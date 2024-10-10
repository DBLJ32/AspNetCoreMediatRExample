using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace RazorPagesLab.Pages.AddressBook
{
    public class DeleteAddressHandler : IRequestHandler<DeleteAddressRequest>
    {
        private readonly IRepo<AddressBookEntry> _repo;

        public DeleteAddressHandler(IRepo<AddressBookEntry> repo)
        {
            _repo = repo;
        }

        public async Task<Unit> Handle(DeleteAddressRequest request, CancellationToken cancellationToken)
        {
            var entry = _repo.GetById(request.Id);
            _repo.Remove(entry);

            return await Task.FromResult(Unit.Value);
        }
    }
}

