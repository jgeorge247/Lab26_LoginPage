﻿using Lab26_LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab26_LoginPage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Products()
        {
            ViewBag.Message = "Products";
            ViewBag.products = ListProducts();
            return View();
        }

        public List<Product> ListProducts()
        {
            ViewBag.Message = "List of Products";
            ProductEntities db = new ProductEntities();
            List<Product> products = db.Products.ToList();
            return products;
        }

        public ActionResult Cart(int ID)
        {
            ViewBag.Cart = AddToCart(ID);

            return View();
        }

        public ActionResult AddToCart(int ID)
        {
            ProductEntities db = new ProductEntities();

            List<Product> cart;
            //check if the Cart object already exists
            if (Session["Cart"] == null)
            {
                //if it doesn't, make a new list of books
                cart = new List<Product>();
                //add this item to it
                cart.Add((from b in db.Products
                          where b.ID == ID
                          select b).Single());
                //add the list to the session
                Session.Add("Cart", cart);
                
            }
            else
            {
                //if it does exist, get the list
                cart = (List<Product>)(Session["Cart"]);
                //add this item to it
                cart.Add((from b in db.Products
                          where b.ID == ID
                          select b).Single());
            }
            return View("Cart");
        }
    }
}