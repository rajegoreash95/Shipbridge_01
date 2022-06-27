﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using WebApiService.Repository;
using Newtonsoft.Json;
using System.Web.Http;

namespace WebApiService.Controllers
{
    public class ShowroomController : ApiController
    {
        // GET: Showroom  
        [HttpGet]
        public IHttpActionResult GetAllProducts()
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Product, Models.Product>();
            List<DataAccessLayer.Product> prodList = DAL.GetAllProducts();
            List<Models.Product> products = new List<Models.Product>();
            foreach (var item in prodList)
            {
                products.Add(mapObj.Translate(item));
            }
            return Ok(products);
        }
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            EntityMapper<DataAccessLayer.Product, Models.Product> mapObj = new EntityMapper<DataAccessLayer.Product, Models.Product>();
            DataAccessLayer.Product dalProduct = DAL.GetProduct(id);
            Models.Product products = new Models.Product();
            products = mapObj.Translate(dalProduct);
            return Ok(products);
        }
        [HttpPost]
        public bool InsertProduct(Models.Product product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();
                DataAccessLayer.Product productObj = new DataAccessLayer.Product();
                productObj = mapObj.Translate(product);
                status = DAL.InsertProduct(productObj);
            }
            return status;

        }
        [HttpPut]
        public bool UpdateProduct(Models.Product product)
        {
            EntityMapper<Models.Product, DataAccessLayer.Product> mapObj = new EntityMapper<Models.Product, DataAccessLayer.Product>();
            DataAccessLayer.Product productObj = new DataAccessLayer.Product();
            productObj = mapObj.Translate(product);
            var status = DAL.UpdateProduct(productObj);
            return status;

        }
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var status = DAL.DeleteProduct(id);
            return Ok();
        }
    }
}