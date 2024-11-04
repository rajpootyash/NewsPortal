using NewsPortal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace NewsPortal.Controllers
{
    public class HomeController : Controller
    {
        Executer executer = new Executer();
        BussinessLayer bussinessLayer = new BussinessLayer();
        DataLayer dataLayer = new DataLayer();

        public void GetCategory()
        {
            DataTable dt = dataLayer.GetTable("select tabid,tabtitle  from m_newscategories where isactive =1");
            List<CategriesSubCategries> ListCate = new List<CategriesSubCategries>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CategriesSubCategries obj = new CategriesSubCategries();
                obj.SubCategories = bussinessLayer.CreatDropDown(dataLayer.GetTable($"select SubTabID,SubTabTitle from M_News_SubCategories where TabID = {dt.Rows[i]["tabid"]}"));
                obj.CategriesName = Convert.ToString(dt.Rows[i]["tabtitle"]);
                obj.Value = Convert.ToString(dt.Rows[i]["tabid"]);
                ListCate.Add(obj);
            }

            ViewBag.categories = ListCate;
        }
        public async Task<ActionResult> Index()
        
        {
            List<News> list = new List<News>();
            DataTable dt = dataLayer.GetTable("select tabid,tabtitle  from m_newscategories where isactive =1");

            List<CategriesSubCategries> ListCate = new List<CategriesSubCategries>();


            for (int i=0; i<dt.Rows.Count; i++)
            {
                CategriesSubCategries obj = new CategriesSubCategries();
                obj.SubCategories = bussinessLayer.CreatDropDown(dataLayer.GetTable($"select SubTabID,SubTabTitle from M_News_SubCategories where TabID = {dt.Rows[i]["tabid"]}"));
                obj.CategriesName = Convert.ToString(dt.Rows[i]["tabtitle"]);
                obj.Value = Convert.ToString(dt.Rows[i]["tabid"]);
                ListCate.Add(obj);
            }

            ViewBag.categories = ListCate;
          var data=  bussinessLayer.GetHtmlCode(bussinessLayer.GetNewsList(list, "select top(8) *from tbl_NewsData where IsActive = 1"));

            ViewBag.HtmlString = data;

            ViewBag.LetestNews= bussinessLayer.GetNewsList(list, "select top(10) *from tbl_NewsData where IsActive = 1 order by NewsID desc");

            ViewBag.DigitalNews= bussinessLayer.GetNewsList(list, "select top(10) *from tbl_NewsData where IsActive = 1 order by NewsID desc");



            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult News(string Id)
        {
            var data = bussinessLayer.GetNews(Id);
            GetCategory();
            return View(data);  
        }
        public  ActionResult GetNewsAllCategoriWise(string Categories ,string Sub)
        {
            List<News> list = new List<News>();
            DataTable dt = dataLayer.GetTable("select tabid,tabtitle  from m_newscategories where isactive =1");

            List<CategriesSubCategries> ListCate = new List<CategriesSubCategries>();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CategriesSubCategries obj = new CategriesSubCategries();
                obj.SubCategories = bussinessLayer.CreatDropDown(dataLayer.GetTable($"select SubTabID,SubTabTitle from M_News_SubCategories where TabID = {dt.Rows[i]["tabid"]}"));
                obj.CategriesName = Convert.ToString(dt.Rows[i]["tabtitle"]);
                obj.Value = Convert.ToString(dt.Rows[i]["tabid"]);
                ListCate.Add(obj);
            }

            ViewBag.categories = ListCate;

            var data = bussinessLayer.GetHtmlCode(bussinessLayer.GetNewsListCategories( bussinessLayer.GetNewsCategorie(Categories, Sub)));
            ViewBag.HtmlString = data;
            return View(list);
        }
    }
}