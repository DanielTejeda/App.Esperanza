using App.Esperanza.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.Esperanza.UI.MVC.Controllers
{
    //[ErrorActionFilter]
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IUnitOfWork _unit;
        // descomentar para log4net
        //protected readonly ILog _log;
        //public BaseController(IUnitOfWork unit, ILog log)
        public BaseController(IUnitOfWork unit)
        {
            _unit = unit;
            //_log = log;
        }
    }
}