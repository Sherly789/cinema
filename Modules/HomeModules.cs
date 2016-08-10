using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;

namespace Cinema
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => {
        return View["index.cshtml"];
      };
    }

  }
}
