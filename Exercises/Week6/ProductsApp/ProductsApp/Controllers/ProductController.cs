using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProductsApp.Context;
using ProductsApp.Models;

namespace ProductsApp.Controllers
{
    /// <summary>
    /// Controller for managing product-related operations.
    /// </summary>
    public class ProductController : Controller
    {
        private ProductContext db = new ProductContext();

        /// <summary>
        /// Retrieves all products and displays them in the index view.
        /// </summary>
        /// <returns>The index view with a list of products.</returns>
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        /// <summary>
        /// Retrieves the details of a specific product.
        /// </summary>
        /// <param name="id">The ID of the product to display.</param>
        /// <returns>The details view for the specified product.</returns>
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Displays the create product form.
        /// </summary>
        /// <returns>The create view.</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="product">The product to create.</param>
        /// <returns>Redirects to the index view if successful, otherwise returns the create view.</returns>
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Displays the edit form for a specific product.
        /// </summary>
        /// <param name="id">The ID of the product to edit.</param>
        /// <returns>The edit view for the specified product.</returns>
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <param name="product">The updated product.</param>
        /// <returns>Redirects to the index view if successful, otherwise returns the edit view.</returns>
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Displays the delete confirmation page for a specific product.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>The delete view for the specified product.</returns>
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Deletes the specified product.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <param name="prod">The product to delete.</param>
        /// <returns>Redirects to the index view if successful, otherwise returns the delete view.</returns>
        [HttpPost]
        public ActionResult Delete(int? id, Product prod)
        {
            try
            {
                Product product = db.Products.Find(id);
                if (ModelState.IsValid)
                {
                    if (id == null)
                    {
                        return HttpNotFound();
                    }

                    db.Products.Remove(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
