using System;
using System.Linq;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class EditModel : PageModel
{
	private readonly IMediator _mediator;
	private readonly IRepo<AddressBookEntry> _repo;

	public EditModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	[BindProperty]
	public UpdateAddressRequest UpdateAddressRequest { get; set; }

    public void OnGet(Guid id)
	{
        // Todo: Use repo to get address book entry, set UpdateAddressRequest fields.
        //Fetches the address entry by id
        var addressBookEntry = _repo.GetById(id);

        //Creates object then populates with fields from addressBookEntry
        UpdateAddressRequest = new UpdateAddressRequest
        {
            Id = addressBookEntry.Id,
            Line1 = addressBookEntry.Line1,
            Line2 = addressBookEntry.Line2,
            City = addressBookEntry.City,
            State = addressBookEntry.State,
            PostalCode = addressBookEntry.PostalCode
        };
        

    }

	public ActionResult OnPost()
	{
        // Todo: Use mediator to send a "command" to update the address book entry, redirect to entry list.
        var command = new UpdateAddressRequest
        {
            Id = UpdateAddressRequest.Id,
            Line1 = UpdateAddressRequest.Line1,
            Line2 = UpdateAddressRequest.Line2,
            City = UpdateAddressRequest.City,
            State = UpdateAddressRequest.State,
            PostalCode = UpdateAddressRequest.PostalCode
        };

        _mediator.Send(command);
        return RedirectToPage("/AddressBook/Index");
	}

    
}