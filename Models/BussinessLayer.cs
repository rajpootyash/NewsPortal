using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Models
{
    public class BussinessLayer
    {
        DataLayer dataLayer = new DataLayer();
        public  List<SelectListItem> CreatDropDown(DataTable dt)
        {
            var list = new List<SelectListItem>();
           
            for (int i = 0;i<dt.Rows.Count; i++)
            {
                list.Add(new SelectListItem() { Value = dt.Rows[i][0].ToString(), Text = dt.Rows[i][1].ToString()});
            }
            return list;
        }

        internal string GetHtmlCode(List<News> list)
        {
            string MainString="";
            string str = "";
            int count = 0;
            
            for(int i = 0;i<list.Count; i++)
            {
                count++;
                str += $"<div class='col-12  col-md-4 col-sm-3'><div class='MainDiv'><img src='{list[i].Url}{list[i].Server_CoverPath}' onclick='GetNews({list[i].NewsID})'/><div>${list[i].NewsTitle}</div></div></div>";
                if (count %3  == 0)
                {
                    MainString += $"<div class='row'>{str}</div><br>";
                    str = "";

                }
                
            }
            if(str !="")
            MainString += $"<div class='row'>{str}</div>";
            return MainString; 
        }

        internal News GetNews(string id)
        {

            DataTable dt = dataLayer.GetTable("select *from tbl_NewsData where IsActive = 1 and NewsID='"+id+"'");
                News news = new News();
            if (dt != null && dt.Rows.Count>0)
            {
                news.NewsID = Convert.ToString(dt.Rows[0]["NewsID"]);
                news.Server_CoverFileName = Convert.ToString(dt.Rows[0]["Server_CoverFileName"]);
                //news.FullNewDescription = Convert.ToString(dt.Rows[i]["FullNewDescription"]);
                news.NewsTitle = Convert.ToString(dt.Rows[0]["NewsTitle"]);
                news.NewDescription = Convert.ToString(dt.Rows[0]["NewDescription"]);
                news.Server_CoverPath = Convert.ToString(dt.Rows[0]["Server_CoverPath"]);
                news.Server_AudioFileName = Convert.ToString(dt.Rows[0]["Server_AudioFileName"]);
                news.Server_AudioPath = Convert.ToString(dt.Rows[0]["Server_AudioPath"]);
                news.Server_VideoFileName = Convert.ToString(dt.Rows[0]["Server_VideoFileName"]);
                news.SubTabID = Convert.ToString(dt.Rows[0]["SubTabID"]);
                news.News_TypeID = Convert.ToString(dt.Rows[0]["News_TypeID"]);
                news.Url = Convert.ToString(dt.Rows[0]["Url"]);
                news.PublishDatetime = Convert.ToString(dt.Rows[0]["PublishDatetime"]);
            }
            return news;
            }

        internal DataTable GetNewsCategorie(string categories, string sub)
        {
            SqlParameter[] sp = new SqlParameter[2];
            sp[0] = new SqlParameter("@TabID", categories);
            sp[1] = new SqlParameter("SubTabId",sub);
            return dataLayer.GetHashCategories(sp, "GetNewsCategoriesSubCategories");
        }

        internal List<News> GetNewsList(List<News> list,string sql)
        {
            list = new List<News>();
               DataTable dt=dataLayer.GetTable(sql);
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                News news = new News();
                news.NewsID = Convert.ToString(dt.Rows[i]["NewsID"]);
                news.Server_CoverFileName = Convert.ToString(dt.Rows[i]["Server_CoverFileName"]);
                //news.FullNewDescription = Convert.ToString(dt.Rows[i]["FullNewDescription"]);
                news.NewsTitle = Convert.ToString(dt.Rows[i]["NewsTitle"]);
                news.NewDescription = Convert.ToString(dt.Rows[i]["NewDescription"]);
                news.Server_CoverPath = Convert.ToString(dt.Rows[i]["Server_CoverPath"]);
                news.Server_AudioFileName = Convert.ToString(dt.Rows[i]["Server_AudioFileName"]);
                news.Server_AudioPath = Convert.ToString(dt.Rows[i]["Server_AudioPath"]);
                news.Server_VideoFileName = Convert.ToString(dt.Rows[i]["Server_VideoFileName"]);
                news.SubTabID = Convert.ToString(dt.Rows[i]["SubTabID"]);
                news.News_TypeID = Convert.ToString(dt.Rows[i]["News_TypeID"]);
                news.Url = Convert.ToString(dt.Rows[i]["Url"]);
                list.Add (news);


            }
            return list;
        }       
        internal List<News> GetNewsListCategories(DataTable dt)
        {
                List<News> list = new List<News>();
            
            for(int i = 0; i<dt.Rows.Count; i++)
            {
                News news = new News();
                news.NewsID = Convert.ToString(dt.Rows[i]["NewsID"]);
                news.Server_CoverFileName = Convert.ToString(dt.Rows[i]["Server_CoverFileName"]);
                //news.FullNewDescription = Convert.ToString(dt.Rows[i]["FullNewDescription"]);
                news.NewsTitle = Convert.ToString(dt.Rows[i]["NewsTitle"]);
                news.NewDescription = Convert.ToString(dt.Rows[i]["NewDescription"]);
                news.Server_CoverPath = Convert.ToString(dt.Rows[i]["Server_CoverPath"]);
                news.Server_AudioFileName = Convert.ToString(dt.Rows[i]["Server_AudioFileName"]);
                news.Server_AudioPath = Convert.ToString(dt.Rows[i]["Server_AudioPath"]);
                news.Server_VideoFileName = Convert.ToString(dt.Rows[i]["Server_VideoFileName"]);
                news.SubTabID = Convert.ToString(dt.Rows[i]["SubTabID"]);
                news.News_TypeID = Convert.ToString(dt.Rows[i]["News_TypeID"]);
                news.Url = Convert.ToString(dt.Rows[i]["Url"]);
                list.Add (news);


            }
            return list;
        }
    }
}