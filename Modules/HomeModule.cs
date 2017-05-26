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
      Get["/contacts/form"] = _ => View["contact-form.cshtml"];
      Get["/contacts/{id}"] = parameters => {
        return View["contact-details.cshtml", Contact.Find(parameters.id)];
      };
      Post["/contacts/new"] = _ => {
        Address newAddress = new Address(Request.Form["street"],
                                         Request.Form["city"],
                                         Request.Form["zip"]);
        Contact newContact = new Contact(Request.Form["contact-name"],
                                         Request.Form["telephone"],
                                         Request.Form["email"],
                                         newAddress);
        return View["contact-details.cshtml", newContact];
      };
      Post["/contacts/clear"] = _ => {
        Contact.ClearAll();
        return View["contact-clear.cshtml"];
      };
      Post["/contacts/delete/{id}"] = parameters => {
        
        return View["index.cshtml", Contact.Find(parameters.id)];
      };
    }
  }
}
