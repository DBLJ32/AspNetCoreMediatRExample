using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesLab.Pages.AddressBook;

public class IndexModel : PageModel
{
	private readonly IRepo<AddressBookEntry> _repo;
	private readonly IMediator _mediator;
	public IEnumerable<AddressBookEntry> AddressBookEntries;

	public IndexModel(IRepo<AddressBookEntry> repo, IMediator mediator)
	{
		_repo = repo;
		_mediator = mediator;
	}

	public void OnGet()
	{
		AddressBookEntries = _repo.Find(new AllEntriesSpecification());
	}

	//Added OnPostDelete method
	public ActionResult OnPostDelete(Guid id)
	{
		var command = new DeleteAddressRequest(id);

		_mediator.Send(command);

		return RedirectToPage("/AddressBook/Index");
	}
}