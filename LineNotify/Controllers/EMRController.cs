using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LineNotify.Models;
using System.Data.Entity;
using System.Net;

namespace LineNotify.Controllers
{
    public class EMRController : Controller
    {
        private LineNotifyEntities db = new LineNotifyEntities();

        // GET: Examiners
        public ActionResult Index()
        {
            var emr = db.Examiners.Include(o => o.Orders);
            return View(emr.ToList());
        }
        
        public ActionResult Report(string ap, string bp, string cp, string dp, string fp, string gp, string hp, string ip, string jp, string kp, string lp, string mp, string zp)
        {
            ViewBag.ap = ap;
            ViewBag.bp = bp;
            ViewBag.cp = cp;
            ViewBag.dp = dp;
            ViewBag.fp = fp;
            ViewBag.gp = gp;
            ViewBag.hp = hp;
            ViewBag.ip = ip;
            ViewBag.jp = jp;
            ViewBag.kp = kp;
            ViewBag.lp = lp;
            ViewBag.mp = mp;
            ViewBag.zp = zp;
            return View("Report");
        }
    }
}