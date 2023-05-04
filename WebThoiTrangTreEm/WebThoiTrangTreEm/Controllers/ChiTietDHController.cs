using MyClass.DAO;
using MyClass.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebThoiTrangTreEm.Controllers
{
    public class ChiTietDHController : Controller
    {
		private OrderDAO orderDAO = new OrderDAO();
		private OrderdetailsDAO orderdetailsDAO = new OrderdetailsDAO();
		// GET: ChiTietDH
		public ActionResult Index()
        {
			List<Order> list = orderDAO.getList("Index");
			return View(list);
        }
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Order order = orderDAO.getRow(id);
			if (order == null)
			{
				return HttpNotFound();
			}
			ViewBag.ListChiTiet = orderdetailsDAO.getList(id);
			return View(order);
		}
	}
}