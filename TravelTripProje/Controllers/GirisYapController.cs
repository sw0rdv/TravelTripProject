using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Siniflar;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        Context c = new Context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Admin ad)
        {
            var admin = c.Admins.FirstOrDefault(x =>
                x.Kullanici == ad.Kullanici &&
                x.Sifre == ad.Sifre);

            if (admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Kullanici, false);
                Session["Kullanici"] = admin.Kullanici;

                return RedirectToAction("Index", "Admin");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            return RedirectToAction("Index", "GirisYap");
        }
    }
}