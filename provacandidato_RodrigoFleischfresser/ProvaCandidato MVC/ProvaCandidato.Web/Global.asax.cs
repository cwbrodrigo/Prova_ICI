using AutoMapper;
using ProvaCandidato.Data.Entidade;
using ProvaCandidato.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ProvaCandidato
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Cliente, ClienteViewModel>();
                cfg.CreateMap<ClienteViewModel, Cliente>();
                cfg.CreateMap<CidadeViewModel, Cidade>();
                cfg.CreateMap<Cidade, CidadeViewModel>();
            });
        }
  }
}
