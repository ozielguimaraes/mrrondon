﻿using System;
using System.Linq;
using System.Web.Http;
using MrRondon.Services.Api.Context;

namespace MrRondon.Services.Api.Controllers
{
    [RoutePrefix("v1/category")]
    public class CategoryController : ApiController
    {
        private readonly MainContext _db;

        public CategoryController()
        {
            _db = new MainContext();
        }

        [AllowAnonymous]
        [Route("{name=}")]
        public IHttpActionResult Get(string name)
        {
            try
            {
                name = name ?? string.Empty;
                return Ok(_db.Categories.Where(x => x.SubCategoryId == null && x.Name.Contains(name)));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) _db.Dispose();
            base.Dispose(disposing);
        }
    }
}