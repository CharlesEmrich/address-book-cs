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
      Get["/contacts/search"] = _ => {
        string query = Request.Query["search-string"];
        List<Contact> searchList = Contact.GetAll().FindAll(delegate(Contact ctct){return ctct.GetName().Contains(query);});
        // List<Contact> searchList = new List<Contact> {};
        // foreach(Contact contact in Contact.GetAll())
        // {
        //   if (contact.GetName().Contains(query)) {
        //     searchList.Add(contact);
        //   }
        // }

        return View["list-view.cshtml", searchList];
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
        Contact.GetAll().Find(delegate(Contact ctct){return ctct.GetId() == parameters.id;}).Delete();
        //Don't forget to refactor index to include a reference to the deletion.
        return View["index.cshtml", Contact.GetAll()];
      };
    }
  }
}
