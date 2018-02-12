﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using MrRondon.Domain.Entities;
using MrRondon.Infra.CrossCutting.Helper;
using MrRondon.Infra.CrossCutting.Helper.Buttons;
using MrRondon.Infra.Data.Context;
using MrRondon.Infra.Data.Repositories;

namespace MrRondon.Presentation.Mvc.Areas.Admin.Controllers
{
    public class EventController : Controller
    {
        private readonly MainContext _db = new MainContext();

        public ActionResult Index()
        {
            return View();
        }
        /*

        public ActionResult Details(Guid id)
        {
            var repo = new RepositoryBase<Event>(_db);
            var company = repo.GetItemByExpression(x => x.EventId == id);
            if (company == null) return HttpNotFound();
            var model = GetCrudVm(company);

            return View(model);
        }

        public ActionResult Create()
        {
            SetBiewBags(null);
            return View();
        }
        [HttpPost]
        public ActionResult Create(CrudEventVm model)
        {
            try
            {
                if (model.SubCategoryId.HasValue && model.SubCategoryId != 0)
                    model.Event.SubCategoryId = model.SubCategoryId.Value;
                else model.Event.SubCategoryId = model.CategoryId;

                if (!ModelState.IsValid)
                {
                    SetBiewBags(model);
                    return View(model);
                }

                _db.Companies.Add(model.Event);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SetBiewBags(model);
                return View(model).Error(ex.Message);
            }
        }

        public ActionResult Edit(Guid id)
        {
            var repo = new RepositoryBase<Event>(_db);
            var company = repo.GetItemByExpression(x => x.EventId == id, "Address", "Segment");
            if (company == null) return HttpNotFound();

            var model = GetCrudVm(company);
            SetBiewBags(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Event company)
        {
            var model = new CrudEventVm { Event = company };
            try
            {
                ModelState.Remove(nameof(company.SubCategoryId));
                if (!ModelState.IsValid)
                {
                    SetBiewBags(model);
                    return View(model);
                }

                _db.Entry(company).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                SetBiewBags(model);

                return View(model).Error(ex.Message);
            }
        }

        [AllowAnonymous]
        public ActionResult Contacts(CrudEventVm companyContact)
        {
            UrlsContact();
            companyContact = companyContact ?? new CrudEventVm();
            companyContact.Contacts = companyContact.Contacts ?? new List<Contact>();
            return PartialView("_Contacts", companyContact.Contacts);
        }

        [AllowAnonymous, HttpPost]
        public ActionResult AddContact(CrudEventVm companyContact)
        {
            companyContact.Contacts = companyContact.Contacts ?? new List<Contact>();
            companyContact.Contacts.Add(new Contact { Description = companyContact.Description, ContactType = companyContact.ContactType });
            companyContact.Description = string.Empty;
            companyContact.ContactType = 0;
            UrlsContact();
            return PartialView("_Contacts", companyContact.Contacts);
        }

        public void UrlsContact()
        {
            ViewBag.UrlAdd = Url.Action("AddContact", "Event", new { area = "Admin" });
            ViewBag.UrlRemove = Url.Action("RemoveContact", "Event", new { area = "Admin" });
        }

        private static CrudEventVm GetCrudVm(Event model)
        {
            var eventVm = new CrudEventVm { Event = model };

            return eventVm;
        }

        private void SetBiewBags(CrudEventVm model)
        {

        }
        */
        [HttpPost]
        public JsonResult GetPagination(DataTableParameters parameters)
        {
            var search = parameters.Search.Value?.ToLower() ?? string.Empty;
            var repo = new RepositoryBase<Event>(_db);
            var items = repo.GetItemsByExpression(w => w.Name.Contains(search), x => x.Name, parameters.Start, parameters.Length, out var recordsTotal).ToList();
            var dtResult = new DataTableResultSet(parameters.Draw, recordsTotal);

            var buttons = new ButtonsEvent();
            foreach (var item in items)
            {
                dtResult.data.Add(new[]
                {
                    item.EventId.ToString(),
                    $"{item.Name}",
                    buttons.ToPagination(item.EventId)
                });
            }
            return Json(dtResult, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GC.SuppressFinalize(this);
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}