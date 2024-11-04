//using system;
//using system.codedom.compiler;
//using system.collections;
//using system.collections.generic;
//using system.data;
//using system.drawing;
//using system.linq;
//using system.threading.tasks;
//using system.web;
//using system.web.mvc;
//using system.web.script.serialization;

//using system.io;
//using newtonsoft;

//using system.web.ui.webcontrols;
//namespace newsportal.controllers
//{
//    public class admincontroller : controller
//    {
//        executer executer = new executer();
//        bussinesslayer bussinesslayer = new bussinesslayer();
//        datalayer datalayer = new datalayer();
//        javascriptserializer js = new javascriptserializer();
//        // get: admin
//        public actionresult index()
//        {
//            return view();
//        }
//        [httpget]
//        public actionresult addmastercategories()
//        {

//            return view();
//        }


//        public async task<string> addmastercategoriesave(news news)
//        {
//            query<news> query;
//            if (!string.isnullorempty(news.tabtitle))
//            {
//                query = await task.run(() => executer.insertandgetidentityasync<news>(news, "m_newscategoriessave", true)).configureawait(false);
//                if (query.issuccess)
//                {
//                    query.commit();
//                }
//                else
//                {
//                    query.rollback();
//                }
//            }

//            query = await task.run(() => executer.select<news>("getm_newscategories")).configureawait(false);


//            var data = js.serialize(query.resultdata);
//            return data;
//        }
//        [httpget]
//        public async task<actionresult> addmastersubcategories()
//        {
//            query<news> query;
//            news obj = new news();
//            obj.listtabtitle = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            query = await task.run(() => executer.select<news>("getsubtabtitle")).configureawait(false);
//            obj.newslist = query.resultdata;
//            return view(obj);
//        }
//        [httppost]

//        public async task<actionresult> addmastersubcategories(news news)
//        {
//            news obj = new news();
//            obj.listtabtitle = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));
//            query<news> query;
//            if (!string.isnullorempty(news.subtabtitle))
//            {
//                query = await task.run(() => executer.insertandgetidentityasync<news>(news, "m_news_subcategoriessave", true)).configureawait(false);
//                if (query.issuccess)
//                {
//                    query.commit();
//                }
//                else
//                {
//                    query.rollback();
//                }
//            }

//            query = await task.run(() => executer.select<news>("getsubtabtitle")).configureawait(false);
//            obj.newslist = query.resultdata;
//            return view(obj);
//        }
//        public actionresult addnewsdetails()
//        {
//            return view();
//        }
//        public async task<actionresult> addpoolsoptions()
//        {

//            query<news> query;
//            news obj = new news();
//            obj.listtabtitle = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            query = await task.run(() => executer.select<news>("getsubtabtitle")).configureawait(false);
//            obj.newslist = query.resultdata;
//            return view(obj);
//        }
//        [httpget]
//        public async task<actionresult> addpoolsquestionier()
//        {
//            query<news> query;
//            news obj = new news();
//            obj.listtabtitle = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            query = await task.run(() => executer.select<news>("getsubtabtitle")).configureawait(false);
//            obj.newslist = query.resultdata;
//            return view(obj);

//        }
//        [httpget]
//        public async task<actionresult> addmasternewsprioitise()
//        {

//            news news = new news();
//            query<news> query = await task.run(() => executer.select<news>("getm_newspreorities")).configureawait(false);
//            news.newslist = query.resultdata;
//            return view(news);
//        }
//        public async task<string> subtabtitleeditdelete(news news)
//        {

//            query<news> query;

//            query = await task.run(() => executer.insertandgetidentityasync<news>(news, "updatedeletesubtabtitle", true)).configureawait(false);
//            if (query.issuccess)
//            {
//                query.commit();
//            }
//            else
//            {
//                query.rollback();
//            }


//            return "";
//        }
//        public async task<string> newsprioitiseeditdelet(news news)
//        {

//            query<news> query;

//            query = await task.run(() => executer.insertandgetidentityasync<news>(news, "updatedeleteprioitise", true)).configureawait(false);
//            if (query.issuccess)
//            {
//                query.commit();
//            }
//            else
//            {
//                query.rollback();
//            }


//            return "";
//        }

//        [httppost]
//        public async task<actionresult> addmasternewsprioitise(news news)
//        {

//            query<news> query;
//            if (!string.isnullorempty(news.newspreoritieslevel_title))
//            {
//                query = await task.run(() => executer.insertandgetidentityasync<news>(news, "m_newspreoritieslevelsave", true)).configureawait(false);
//                if (query.issuccess)
//                {
//                    query.commit();
//                }
//                else
//                {
//                    query.rollback();
//                }
//            }

//            query = await task.run(() => executer.select<news>("getm_newspreorities")).configureawait(false);
//            news.newslist = query.resultdata;
//            return view(news);

//        }
//        [httpget]
//        public async task<actionresult> addnews()

//        {
//            news news = new news();
//            news.listcategories = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            news.listnewspriorities = bussinesslayer.creatdropdown(datalayer.gettable("select *from m_newspreoritieslevel where isactive = 1"));
//            news.listnewstype = bussinesslayer.creatdropdown(datalayer.gettable("select subtabid,subtabtitle from m_newscategories inner join m_news_subcategories on m_news_subcategories.tabid = m_newscategories.tabid where m_news_subcategories.isactive =1 and m_newscategories.isactive =1  "));
//            news.listsubcategories = new list<selectlistitem>() { new selectlistitem() { text = "--select--", value = "0" } };/* bussinesslayer.creatdropdown(datalayer.gettable("select news_typeid,news_typetitle from m_news_types where isactive =1"));*/


//            return view(news);
//        }
//        [httppost]
//        public async task<actionresult> addnews(news news)
//        {



//            query<news> query = new query<news>();

//            if (news.audiofile != null)
//            {

//                string directorypath = @"c:\uploadaudiofile\";
//                if (!directory.exists(directorypath))
//                {
//                    directory.createdirectory(directorypath);
//                }
//                news.server_audiofilename = datetime.now.tostring("ddmmyyyy_hh_mm_ss_ms") + news.audiofile.filename;
//                news.server_audiopath = path.combine(directorypath + news.server_audiofilename);
//                news.coverfile.saveas(news.server_audiopath);
//            }
//            if (news.videofile != null)
//            {

//                string directorypath = @"c:\uploadvideofile\";
//                if (!directory.exists(directorypath))
//                {
//                    directory.createdirectory(directorypath);
//                }
//                news.server_videofilename = datetime.now.tostring("ddmmyyyy_hh_mm_ss_ms") + news.videofile.filename;
//                news.server_videopath = path.combine(directorypath + news.server_videofilename);

//                news.coverfile.saveas(news.server_videopath);
//            }
//            if (news.coverfile != null)
//            {
//                string directorypath = @"c:\uploadcoverfile\";
//                if (!directory.exists(directorypath))
//                {
//                    directory.createdirectory(directorypath);
//                }
//                news.server_coverfilename = datetime.now.tostring("ddmmyyyy_hh_mm_ss_ms") + news.coverfile.filename;
//                news.server_coverpath = path.combine(directorypath + news.server_coverfilename);

//            }
//            try
//            {

//                query = await task.run(() => executer.insertandgetidentityasync<news>(news, "tbl_newsdatasave", true)).configureawait(false);
//                if (query.issuccess)
//                {
//                    if (news.audiofile != null)
//                    {
//                        news.coverfile.saveas(news.server_audiopath);
//                    }
//                    if (news.videofile != null)
//                    {
//                        news.coverfile.saveas(news.server_videopath);
//                    }
//                    if (news.coverfile != null)
//                    {
//                        news.coverfile.saveas(news.server_coverpath);
//                    }

//                    query.commit();
//                }
//                else
//                {
//                    query.rollback();
//                }
//            }
//            catch (exception)
//            {

//                query.rollback();
//            }
//            modelstate.clear();
//            news.listcategories = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            news.listnewspriorities = bussinesslayer.creatdropdown(datalayer.gettable("select *from m_newspreoritieslevel where isactive = 1"));
//            news.listnewstype = bussinesslayer.creatdropdown(datalayer.gettable("select subtabid,subtabtitle from m_newscategories inner join m_news_subcategories on m_news_subcategories.tabid = m_newscategories.tabid where m_news_subcategories.isactive =1 and m_newscategories.isactive =1  "));
//            news.listsubcategories = bussinesslayer.creatdropdown(datalayer.gettable("select news_typeid,news_typetitle from m_news_types where isactive =1"));
//            return view(news);
//        }

//        [httpget]
//        public async task<actionresult> addmasternewstypes()
//        {
//            news news = new news();
//            query<news> query = await task.run(() => executer.select<news>("get_newstype")).configureawait(false);
//            news.newslist = query.resultdata;
//            return view(news);
//        }
//        [httppost]
//        public async task<actionresult> addmasternewstypes(news news)
//        {


//            query<news> query;
//            if (!string.isnullorempty(news.news_typetitle))
//            {
//                query = await task.run(() => executer.insertandgetidentityasync<news>(news, "m_news_typessave", true)).configureawait(false);
//                if (query.issuccess)
//                {
//                    query.commit();
//                }
//                else
//                {
//                    query.rollback();
//                }
//            }

//            query = await task.run(() => executer.select<news>("get_newstype")).configureawait(false);
//            news.newslist = query.resultdata;
//            return view(news);
//        }

//        [httpget]
//        public async task<actionresult> addnewnews()
//        {
//            news news = new news();
//            news.listcategories = bussinesslayer.creatdropdown(datalayer.gettable("select tabid,tabtitle  from m_newscategories where isactive =1"));

//            news.listnewspriorities = bussinesslayer.creatdropdown(datalayer.gettable("select *from m_newspreoritieslevel where isactive = 1"));
//            news.listnewstype = bussinesslayer.creatdropdown(datalayer.gettable("select subtabid,subtabtitle from m_newscategories inner join m_news_subcategories on m_news_subcategories.tabid = m_newscategories.tabid where m_news_subcategories.isactive =1 and m_newscategories.isactive =1  "));
//            news.listsubcategories = bussinesslayer.creatdropdown(datalayer.gettable("select news_typeid,news_typetitle from m_news_types where isactive =1"));
//            return view(news);
//        }
//        [httppost]
//        public async task<actionresult> addnewnews(news newa)
//        {
//            return view();
//        }

//        public async task<string> updatecategories(news news)
//        {

//            query<news> query;

//            query = await task.run(() => executer.insertandgetidentityasync<news>(news, "updatedeletecategory", true)).configureawait(false);
//            if (query.issuccess)
//            {
//                query.commit();
//            }
//            else
//            {
//                query.rollback();
//            }
//            return "";
//        }

//        public string getsubcategories(string tabid)
//        {
//            list<selectlistitem> data = bussinesslayer.creatdropdown(datalayer.gettable($"select subtabid,subtabtitle from m_news_subcategories where tabid = {tabid}"));
//            return js.serialize(data);
//        }
//    }
//}