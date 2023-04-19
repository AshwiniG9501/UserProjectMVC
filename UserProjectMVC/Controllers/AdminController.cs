using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserProjectMVC.Models;

namespace UserProjectMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetGridview();
            Bind_Country();
            return View();
        }
        [HttpPost]
        public ActionResult Create(User obj)
        {

            BalUser obj1 = new BalUser();
            obj1.Register(obj.Name, obj.Address, obj.Email, obj.Gender, obj.Number, obj.CityId);
            Response.Write("<script>alert('Your Details has been registered');</script>");
            return RedirectToAction("Create");

        }


        public void Bind_Country()//Add below method for populate Country Dropdownlist
        {
            BalUser objcountry = new BalUser();
            DataSet ds = new DataSet();
            ds = objcountry.ShowCountry();
            List<SelectListItem> Countrylist = new List<SelectListItem>();//list object created
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Countrylist.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString()

                });

            }
            ViewBag.Country = Countrylist;//In the above methods, I am calling Get_Country methods from
                                          //Balclass and storing the
                                          //list in ViewBag for passing a list to the view.
        }

        [HttpPost]
        public JsonResult Bind_State(int CountryId)
        {
            BalUser objState = new BalUser();
            DataSet ds = new DataSet();
            ds = objState.ShowState(CountryId);
            List<SelectListItem> Statelist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Statelist.Add(new SelectListItem
                {
                    Text = dr["StateName"].ToString(),
                    Value = dr["StateId"].ToString()

                });

            }
            return Json(Statelist, JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult Bind_City(int StateId)
        {
            BalUser objcity = new BalUser();
            DataSet ds = new DataSet();
            ds = objcity.ShowCity(StateId);
            List<SelectListItem> Citylist = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Citylist.Add(new SelectListItem
                {
                    Text = dr["CityName"].ToString(),
                    Value = dr["CityId"].ToString()

                });

            }
            return Json(Citylist, JsonRequestBehavior.AllowGet);


        }
        [HttpGet]
        public ActionResult GetGridview()
        {
            Bind_Country();
            BalUser obj = new BalUser();
            DataSet ds = new DataSet();
            ds = obj.GetTable();
            User objuser = new User();
            List<User> users1 = new List<User>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                User obju = new User();
                obju.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["UserId"].ToString());
                obju.Name = ds.Tables[0].Rows[i]["UserName"].ToString();
                obju.Address = ds.Tables[0].Rows[i]["UserAddress"].ToString();
                obju.Email = ds.Tables[0].Rows[i]["UserEmail"].ToString();
                obju.Gender = ds.Tables[0].Rows[i]["UserGender"].ToString();
                obju.Number = ds.Tables[0].Rows[i]["UserNumber"].ToString();
                obju.Country = ds.Tables[0].Rows[i]["CountryName"].ToString();
                obju.State = ds.Tables[0].Rows[i]["StateName"].ToString();
                obju.City = ds.Tables[0].Rows[i]["CityName"].ToString();
                //obju.Cityid = Convert.ToInt32(ds.Tables[0].Rows[i]["Cityid"].ToString());

                users1.Add(obju);
            }
            objuser.Users = users1;


            return View(objuser);
        }



        [HttpGet]
        public ActionResult Edit(int id)
        {
            Bind_Country();
            User obj = new User();
            obj.Id = id;
            BalUser obj1 = new BalUser();
            SqlDataReader dr;
            dr = obj1.GetDataUpdate(obj.Id);
            while (dr.Read())
            {
                obj.Id = Convert.ToInt32(dr["UserId"].ToString());
                obj.Name = dr["UserName"].ToString();
                obj.Address = dr["UserAddress"].ToString();
                obj.Email = dr["UserEmail"].ToString();
                obj.Gender = dr["UserGender"].ToString();
                obj.Number = dr["UserNumber"].ToString();
                obj.Country = dr["CountryName"].ToString();
                obj.State = dr["StateName"].ToString();
                obj.City = dr["CityName"].ToString();
                obj.CountryId = Convert.ToInt32(dr["CountryId"].ToString());
                obj.StateId = Convert.ToInt32(dr["StateId"].ToString());
                obj.CityId = Convert.ToInt32(dr["CityId"].ToString());

            }
            dr.Close();
            ViewBag.State = obj.State;
            ViewBag.Stateid = obj.StateId;
            ViewBag.Cityid = obj.CityId;
            ViewBag.City = obj.City;

            return View(obj);
        }


        [HttpPost]
        public ActionResult Update(User obj)
        {
            BalUser obj1 = new BalUser();
            obj1.Updatuser(obj.Name, obj.Address, obj.Email, obj.Gender, obj.Number, obj.CityId, obj.Id);
            Response.Write("<script>alert('Your Details has been Updated');</script>");
            return RedirectToAction("Create");

        }

        public ActionResult Delete(User obj)
        {
            BalUser objuser = new BalUser();
            objuser.Deleterecord(obj.Id);
            Response.Write("<script>alert('Delete Successfully...!')</script>");
            return RedirectToAction("Create");
        }




        public ActionResult Detalis(int id)
        {
            //Bind_Country();
            User obj = new User();
            obj.Id = id;
            BalUser obj1 = new BalUser();
            SqlDataReader dr;
            dr = obj1.PopDetails(obj.Id);
            while (dr.Read())
            {
                obj.Id = Convert.ToInt32(dr["UserId"].ToString());
                obj.Name = dr["UserName"].ToString();
                obj.Address = dr["UserAddress"].ToString();
                obj.Email = dr["UserEmail"].ToString();
                obj.Gender = dr["UserGender"].ToString();
                obj.Number = dr["UserNumber"].ToString();
                //obj.Number = dr["CountryName"].ToString();
                //obj.Number = dr["StateName"].ToString();
                obj.Number = dr["CityName"].ToString();
                //obj.CountryId = Convert.ToInt32(dr["CountryId"].ToString());
                //obj.StateId = Convert.ToInt32(dr["StateId"].ToString());
                //obj.CityId = Convert.ToInt32(dr["CityId"].ToString());
               

            }
            dr.Close();
            return PartialView( obj);
        }


    }
}








