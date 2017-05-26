using Nancy;
using JobBoard.Objects;
using System.Collections.Generic;

namespace JobBoard
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml", Job.GetAll()];
      Get["/jobs/new"] = _ => View["job-form.cshtml"];
      Post["/"] = _ => {
        Contact newContact = new Contact(Request.Form["new-contact-name"],
                                         Request.Form["new-telephone"],
                                         Request.Form["new-email"]);
        Job newJob = new Job (Request.Form["new-title"],
                              Request.Form["new-description"],
                              newContact);
        return View["index.cshtml", Job.GetAll()];
      };
      Post["/jobs/cleared"] = _ => {
        Job.ClearAll();
        return View["jobs_cleared.cshtml"];
      };
      Get["/jobs/{id}"] = parameters => {
        return View["job-listing.cshtml", Job.SearchJobs(parameters.id)];
      };
    }
  }
}
