using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsPortal.Models
{
    public class News
    {
        public string mode {  get; set; }
        public string SubTabID { get; set; }
        public string TabID { get; set; }
        public string SubTabTitle { get; set; }
        public string IsActive { get; set; }
        public string News_TypeID { get; set; }
        public string News_TypeTitle { get; set; }
        public string TabTitle { get; set; }
        public List<SelectListItem> ListTabTitle { get; set; }
        public List<SelectListItem> ListCategories { get; set; }
        public List<SelectListItem> ListSubCategories { get; set; }
        public List<SelectListItem> ListNewsType { get; set; }
        public List<SelectListItem> ListNewsPriorities { get; set; }
        public string NewsPreoritieslevel_ID { get; set; }
        public string NewsPreoritieslevel_Title { get; set; }
        public string AddedOn { get; set; }
        public string AddedBy { get; set; }
        public string News_BriefID { get; set; }
        public string NewsID { get; set; }
        public string Html { get; set; }
        public string Url { get; set; }
        public string Server_CoverFileName { get; set; }
        public string Local_CoverFileName { get; set; }
        public string Server_VideoFileName { get; set; }
        public string Server_AudioFileName { get; set; }
        public string NewsTitle { get; set; }
        public string NewDescription { get; set; }
        [AllowHtml]
        public string FullNewDescription { get; set; }
        public string AuthorID { get; set; }
        public string PublishNews { get; set; }
        public string Server_CoverPath { get; set; }
        public string Server_VideoPath { get; set; }
        public string Server_AudioPath { get; set; }
        public string SocialMediaUrl { get; set; }
        public string PublishDatetime { get; set; }
        public string Pools_OptionID { get; set; }
        public string PoolsID { get; set; }
        public string Pools_OptionTitle { get; set; }
        public string Correct { get; set; }
        public string PoolsTitle { get; set; }
        public string PoolsHint { get; set; }
        public string Publish { get; set; }
        public List<News> NewsList { get; set; }
        public HttpPostedFileBase CoverFile { get; set; }
        public HttpPostedFileBase AudioFile { get; set; }
        public HttpPostedFileBase VideoFile { get; set; }
        

        public News()
        {
            NewsList = new List<News>();    
        }

    }
  
}