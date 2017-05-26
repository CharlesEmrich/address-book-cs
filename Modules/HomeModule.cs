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
      Post["/contacts/new"] = _ => {
        Address newAddress = new Address(Request.Form["street"],
                                         Request.Form["city"],
                                         Request.Form["zip"]);
        Contact newContact = new Contact(Request.Form["contact-name"],
                                         Request.Form["telephone"],
                                         Request.Form["email"],
                                         newAddress);
        // Dictionary<string, object> newDict = new Dictionary <string, object> {{"contact", newContact}, {"justCreated", {justCreated: true}}};
        return View["contact-details.cshtml", newContact];
      };
      Get["/contacts/{id}"] = parameters => {
        return View["contact-details.cshtml", Contact.Find(parameters.id)];
      };
      Post["/contacts/clear"] = _ => {
        // Contact.ClearAll();
        return View["contact-clear.cshtml"];
      };
    }
  }
}
