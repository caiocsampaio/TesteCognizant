using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cognizant.MVC.Models;
using Cognizant.Domain.Models;
using Cognizant.Repository.Contracts;
using Cognizant.MVC.DAL;

namespace Cognizant.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IIndexDAL _indexDal;

        public HomeController(IIndexDAL indexDal)
        {
            _indexDal = indexDal;
        }

        public IActionResult Index()
        {
            List<Account> model = _indexDal.GetAccountsList();

            return View(model);
        }

        /// <summary>
        /// Creates new account and client
        /// </summary>
        /// <param name="request">Account data</param>
        public JsonResult CreateAccount([FromBody] CreateAccountRequest request)
        {
            Account account = _indexDal.CreateAccount(request);

            return Json(account);
        }

        public JsonResult Transaction([FromBody] TransactionRequest request)
        {
            Account account = _indexDal.NewTransaction(request);

            return Json(new {
                AccountId = account.Id,
                Balance = account.Balance
            });
        }

        public JsonResult RemoveAccount([FromBody] RemoveAccountRequest request)
        {
            int success = _indexDal.RemoveAccount(request.AccountId);

            if (success > 0) 
            {
                return Json(true);
            }
            
            return Json(false);
        }
    }
}
