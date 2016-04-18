using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ClocksController : Controller
    {
        private ClockDBContext db = new ClockDBContext();

        // GET: Clocks
        public ActionResult Index(string category, string searchString, string sortOrder, int? page)
        {
            if (db.Clocks.Count() == 0) // check that the database has information
                readData(); // read the data if database is empty
            List<SelectListItem> items = new List<SelectListItem>();
            List<string> itemList = createList();
            for (int i = 0; i < itemList.Count; ++i)
            {
                items.Add(new SelectListItem { Text = itemList[i].ToString() });
            }
            ViewBag.Category = items;
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString;
            var clocks = from z in db.Clocks
                         select z;
            int pageSize = 25; // items per page;
            int pageNumber = (page ?? 1);

            ViewBag.DialNumberSort = sortOrder == "DialNumber" ? "" : "DialNumber";
            ViewBag.DialMakerSort = sortOrder == "DialMaker" ? "" : "DialMaker";
            ViewBag.DialMakerTownSort = sortOrder == "DialMakerTown" ? "" : "DialMakerTown";
            ViewBag.clockMakerSort = sortOrder == "ClockMaker" ? "" : "ClockMaker";
            ViewBag.clockMakerTownSort = sortOrder == "ClockMakerTown" ? "" : "ClockMakerTown";
            ViewBag.clockDateSort = sortOrder == "ClockDate" ? "" : "ClockDate";
            ViewBag.DialDateSort = sortOrder == "DialDate" ? "" : "DialDate";
            ViewBag.DialTypeSort = sortOrder == "DialType" ? "" : "DialType";
            ViewBag.GraphicsSort = sortOrder == "Graphics" ? "" : "Graphics";
            ViewBag.HemispheresSort = sortOrder == "Hemispheres" ? "" : "Hemispheres";
            ViewBag.DateDialSort = sortOrder == "DateDial" ? "" : "DateDial";
            ViewBag.SecondsDialSort = sortOrder == "SecondsDial" ? "" : "SecondsDial";
            ViewBag.DescriptionSort = sortOrder == "Description" ? "" : "Description";

            switch (sortOrder)
            {
                case "DialNumber":
                    clocks = clocks.OrderBy(a => a.DialNumber == null).ThenBy(a => a.DialNumber);
                    break;
                case "DialMaker":
                    clocks = clocks.OrderBy(a => a.DialMaker == null).ThenBy(a => a.DialMaker);
                    break;
                case "DialMakerTown":
                    clocks = clocks.OrderBy(a => a.DialMakerTown == null).ThenBy(a => a.DialMakerTown);
                    break;
                case "ClockMaker":
                    clocks = clocks.OrderBy(a => a.ClockMaker == null).ThenBy(a => a.ClockMaker);
                    break;
                case "ClockMakerTown":
                    clocks = clocks.OrderBy(a => a.ClockMakerTown == null).ThenBy(a => a.ClockMakerTown);
                    break;
                case "ClockDate":
                    clocks = clocks.OrderBy(a => a.ClockDate == null).ThenBy(a => a.ClockDate);
                    break;
                case "DialDate":
                    clocks = clocks.OrderBy(a => a.DialDate == null).ThenBy(a => a.DialDate);
                    break;
                case "DialType":
                    clocks = clocks.OrderBy(a => a.DialType == null).ThenBy(a => a.DialType);
                    break;
                case "Graphics":
                    clocks = clocks.OrderBy(a => a.Graphics == null).ThenBy(a => a.Graphics);
                    break;
                case "Hemispheres":
                    clocks = clocks.OrderBy(a => a.Hemispheres == null).ThenBy(a => a.Hemispheres);
                    break;
                case "DateDial":
                    clocks = clocks.OrderBy(a => a.DateDial == null).ThenBy(a => a.DateDial);
                    break;
                case "SecondsDial":
                    clocks = clocks.OrderBy(a => a.SecondsDial == null).ThenBy(a => a.SecondsDial);
                    break;
                case "Description":
                    clocks = clocks.OrderBy(a => a.Description == null).ThenBy(a => a.Description);
                    break;
                default:
                    clocks = clocks.OrderBy(a => a.ID);
                    break;
            }

            if (searchString != null)
            {
                if (category == "DialNumber")
                {
                    clocks = clocks.Where(a => a.DialNumber.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "DialMaker")
                {
                    clocks = clocks.Where(a => a.DialMaker.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "DialMakerTown")
                {
                    clocks = clocks.Where(a => a.DialMakerTown.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "ClockMaker")
                {
                    clocks = clocks.Where(a => a.ClockMaker.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "ClockMakerTown")
                {
                    clocks = clocks.Where(a => a.ClockMakerTown.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "ClockDate")
                {
                    clocks = clocks.Where(a => a.ClockDate.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "DialDate")
                {
                    clocks = clocks.Where(a => a.DialDate.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "DialType")
                {
                    clocks = clocks.Where(a => a.DialType.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "Graphics")
                {
                    clocks = clocks.Where(a => a.Graphics.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "Hemispheres")
                {
                    clocks = clocks.Where(a => a.Hemispheres.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "DateDial")
                {
                    clocks = clocks.Where(a => a.DateDial.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "SecondsDial")
                {
                    clocks = clocks.Where(a => a.SecondsDial.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else if (category == "Description")
                {
                    clocks = clocks.Where(a => a.Description.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    clocks = clocks.Where(a => a.DialNumber.Contains(searchString)
                    || a.DialMaker.Contains(searchString)
                    || a.DialMakerTown.Contains(searchString)
                    || a.ClockMaker.Contains(searchString)
                    || a.ClockMakerTown.Contains(searchString)
                    || a.ClockDate.Contains(searchString)
                    || a.DialDate.Contains(searchString)
                    || a.DialType.Contains(searchString)
                    || a.Graphics.Contains(searchString)
                    || a.Hemispheres.Contains(searchString)
                    || a.DateDial.Contains(searchString)
                    || a.SecondsDial.Contains(searchString)
                    || a.Description.Contains(searchString));
                    return View(clocks.ToPagedList(pageNumber, pageSize));
                }
            }
            else
            {
                return View(clocks.ToPagedList(pageNumber, pageSize));
            }
        }

        public List<string> createList()
        {
            List<string> newList = new List<string>();
            newList.Add("DialNumber");
            newList.Add("DialMaker");
            newList.Add("DialMakerTown");
            newList.Add("ClockMaker");
            newList.Add("ClockMakerTown");
            newList.Add("ClockDate");
            newList.Add("DialDate");
            newList.Add("DialType");
            //newList.Add("AssociatedDials");
            newList.Add("Graphics");
            newList.Add("Hemispheres");
            newList.Add("DateDial");
            newList.Add("SecondsDial");
            newList.Add("Description");
            //newList.Add("FalsePlate");
            //newList.Add("MoonDialFace");
            //newList.Add("MoonDialScene1");
            //newList.Add("MoonDialScene2");
            return newList;
        }

        public void readData() // Read data and import into database.
        {
            string ClockDials = "D:/virtualservers/ctennant.org/clocks.ctennant.org/Content/spreadsheet clock dials v5.xls";

            string connectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", ClockDials);
            var adapter = new OleDbDataAdapter("SELECT * FROM [Dial index$]", connectionString);
            var ds = new DataSet();
            adapter.Fill(ds, "dbo.ClockDBs");
            DataTable data = ds.Tables["dbo.ClockDBs"];
            char space = ' ';
            for (int i = 0; i < data.Columns.Count; ++i)
            {
                string colName = data.Columns[i].ColumnName;
                if (colName == "Row No")
                {
                    data.Columns[i].ColumnName = "ID";
                }
                else if (colName.Contains(" "))
                {
                    for (int j = 0; j < colName.Length; ++j)
                    {
                        if (colName.ElementAt(j).Equals(space))
                        {
                            colName = colName.Remove(j, 1);
                            data.Columns[i].ColumnName = colName;
                            if (!data.Columns[i].ColumnName.Contains(" "))
                                break;
                        }
                    }
                }
            }
            for (int i = (data.Columns.Count - 1); i >= 19; --i)
            {
                data.Columns.RemoveAt(i);
            }
            for (int i = (data.Rows.Count - 1); i >= 2277; --i)
            {
                if (data.Rows[i][0].ToString().Equals("") || data.Rows[i][0].ToString().Equals(null))
                {
                    data.Rows.RemoveAt(i);
                }
            }

            string connection = db.Database.Connection.ConnectionString;

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity))
            {
                bulkCopy.DestinationTableName = "dbo.ClockDBs";
                try
                {
                    bulkCopy.WriteToServer(data);
                }
                catch (Exception ex)
                {
                    string error = ex.ToString();
                }
            }
        }

        // GET: Clocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClockDB clockDB = db.Clocks.Find(id);
            if (clockDB == null)
            {
                return HttpNotFound();
            }
            return View(clockDB);
        }

        // GET: Clocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Description")] ClockDB clockDB)
        {
            if (ModelState.IsValid)
            {
                db.Clocks.Add(clockDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clockDB);
        }

        // GET: Clocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClockDB clockDB = db.Clocks.Find(id);
            if (clockDB == null)
            {
                return HttpNotFound();
            }
            return View(clockDB);
        }

        // POST: Clocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Description")] ClockDB clockDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clockDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clockDB);
        }

        // GET: Clocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClockDB clockDB = db.Clocks.Find(id);
            if (clockDB == null)
            {
                return HttpNotFound();
            }
            return View(clockDB);
        }

        // POST: Clocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClockDB clockDB = db.Clocks.Find(id);
            db.Clocks.Remove(clockDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
