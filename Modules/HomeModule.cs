using Nancy;
using AddressBook.Objects;
using System.Collections.Generic;

namespace AddressBook
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml", Contact.GetAll()];
      Get["/contacts/new"] = _ => View["contact-form.cshtml"];
      Post["/"] = _ => {
        Address newAddress = new Address(Request.Form["street"],
                                         Request.Form["city"],
                                         Request.Form["zip"]);
        Contact newContact = new Contact(Request.Form["contact-name"],
                                         Request.Form["telephone"],
                                         Request.Form["email"],
                                         newAddress);
        return View["index.cshtml", Contact.GetAll()];
      };
      Get["/contacts/{id}"] = parameters => {
        return View["job-listing.cshtml", Contact.Find(parameters.id)];
      };
    }
  }
}
