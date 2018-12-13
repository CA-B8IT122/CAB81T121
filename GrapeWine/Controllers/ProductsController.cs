using GrapeWine.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrapeWine.Controllers
{
    public class ProductsController : Controller
    {
        ProductDataHelper helper = new ProductDataHelper();

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ProductCountry = helper.GetProductCountry();
            ViewBag.Grape = helper.GetGrape();

            return View();
        }

        [HttpGet]
        public ActionResult Info(int id)
        {
            Product product = helper.GetProduct(id);

            return View(product);
        }

        [HttpPost]
        public JsonResult GetProducts(FilterCriteria model)
        {
            return Json(helper.GetProducts(model), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddToCart(int productId, int qty, int type)
        {
            try
            {
                List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;
                if (cartItems == null)
                    cartItems = new List<CartItem>();

                CartItem cartItem = cartItems.Find(x => x.Product.ProductID == productId && x.Type == type);
                if (cartItem != null)
                {
                    cartItem.Qty += qty;
                    Session["CartItems"] = cartItems;

                    return Json(new
                    {
                        suceess = true,
                        message = "Item Added Successfully"
                    });
                }

                Product product = helper.GetProduct(productId);
                if (product != null)
                {
                    cartItems.Add(new CartItem()
                    {
                        Qty = qty,
                        Type = type,
                        Product = product
                    });
                    Session["CartItems"] = cartItems;

                    return Json(new
                    {
                        suceess = true,
                        message = "Item Added Successfully"
                    });
                }
                else
                {
                    throw new Exception("Unable to Add Item to cart");
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }

        [HttpPost]
        public JsonResult GetCart()
        {
            List<CartItem> cartItems = Session["CartItems"] as List<CartItem>;
            if (cartItems == null)
                cartItems = new List<CartItem>();

            return Json(cartItems);
        }
    }

    public class FilterCriteria
    {
        public string ProductCountry { get; set; }
        public string Grape { get; set; }
    }

    public class CartItem
    {
        public Product Product { get; set; }

        public int Qty { get; set; } = 1;
        public int Type { get; set; }

        public decimal TotalPrice { get { return Product.Price * Qty; } }
    }

    internal class ProductDataHelper
    {
        string _connectionString = string.Empty;

        public ProductDataHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["GrapeWineConnection"].ConnectionString;
        }

        public List<Product> GetProducts(FilterCriteria model)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        connection.Open();

                        //add filter here.
                        string where = string.Empty;
                        if (model != null && (!string.IsNullOrEmpty(model.Grape) || !string.IsNullOrEmpty(model.ProductCountry)))
                        {
                            if (!string.IsNullOrEmpty(model.Grape) && model.Grape.ToLower() != "all")
                                where += "Grape = '" + model.Grape + "'";
                            if (!string.IsNullOrEmpty(model.ProductCountry) && model.ProductCountry.ToLower() != "all")
                                where += "ProductCountry = '" + model.ProductCountry + "'";
                        }

                        command.CommandText = "SELECT * FROM Products" + (string.IsNullOrEmpty(where) ? string.Empty : " WHERE " + where);
                        command.Connection = connection;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<Product> products = new List<Product>();
                            int productId = reader.GetOrdinal("ProductID");
                            int ProductName = reader.GetOrdinal("ProductName");
                            int ProductCountry = reader.GetOrdinal("ProductCountry");
                            int ProductType = reader.GetOrdinal("ProductType");
                            int ProductDescription = reader.GetOrdinal("ProductDescription");
                            int Grape = reader.GetOrdinal("Grape");
                            int ImageSrc = reader.GetOrdinal("ImageSrc");
                            int Price = reader.GetOrdinal("Price");

                            while (reader.Read())
                            {
                                products.Add(new Product()
                                {
                                    ProductID = reader.IsDBNull(productId) ? 0 : reader.GetInt32(productId),
                                    ProductName = reader.IsDBNull(ProductName) ? "" : reader.GetString(ProductName),
                                    ProductCountry = reader.IsDBNull(ProductCountry) ? "" : reader.GetString(ProductCountry),
                                    ProductType = reader.IsDBNull(ProductType) ? "" : reader.GetString(ProductType),
                                    ProductDescription = reader.IsDBNull(ProductDescription) ? "" : reader.GetString(ProductDescription),
                                    Grape = reader.IsDBNull(Grape) ? "" : reader.GetString(Grape),
                                    ImageSrc = reader.IsDBNull(ImageSrc) ? "" : reader.GetString(ImageSrc),
                                    Price = reader.IsDBNull(Price) ? 0 : reader.GetDecimal(Price),
                                });
                            }

                            return products;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle error here.
                        return new List<Product>();
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Product GetProduct(int productID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        connection.Open();

                        command.CommandText = "SELECT * FROM Products WHERE ProductID= @ProductID";

                        SqlParameter sqlParameter = new SqlParameter("@ProductID", System.Data.SqlDbType.Int);
                        sqlParameter.Value = productID;
                        command.Parameters.Add(sqlParameter);

                        command.Connection = connection;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int productId = reader.GetOrdinal("ProductID");
                            int ProductName = reader.GetOrdinal("ProductName");
                            int ProductCountry = reader.GetOrdinal("ProductCountry");
                            int ProductType = reader.GetOrdinal("ProductType");
                            int ProductDescription = reader.GetOrdinal("ProductDescription");
                            int Grape = reader.GetOrdinal("Grape");
                            int ImageSrc = reader.GetOrdinal("ImageSrc");
                            int Price = reader.GetOrdinal("Price");

                            if (reader.HasRows && reader.Read())
                            {
                                return new Product()
                                {
                                    ProductID = reader.IsDBNull(productId) ? 0 : reader.GetInt32(productId),
                                    ProductName = reader.IsDBNull(ProductName) ? "" : reader.GetString(ProductName),
                                    ProductCountry = reader.IsDBNull(ProductCountry) ? "" : reader.GetString(ProductCountry),
                                    ProductType = reader.IsDBNull(ProductType) ? "" : reader.GetString(ProductType),
                                    ProductDescription = reader.IsDBNull(ProductDescription) ? "" : reader.GetString(ProductDescription),
                                    Grape = reader.IsDBNull(Grape) ? "" : reader.GetString(Grape),
                                    ImageSrc = reader.IsDBNull(ImageSrc) ? "" : reader.GetString(ImageSrc),
                                    Price = reader.IsDBNull(Price) ? 0 : reader.GetDecimal(Price),
                                };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle error here.
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

            return null;
        }

        public SelectList GetProductCountry()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        connection.Open();

                        command.CommandText = "SELECT DISTINCT ProductCountry FROM Products";
                        command.Connection = connection;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<SelectListItem> selectListItems = new List<SelectListItem>();
                            selectListItems.Add(new SelectListItem()
                            {
                                Text = "All",
                                Value = "All",
                            });

                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    string item = reader.GetString(0);
                                    selectListItems.Add(new SelectListItem()
                                    {
                                        Text = item,
                                        Value = item,
                                    });
                                }
                            }

                            return new SelectList(selectListItems, "Value", "Text");
                        }
                    }
                    catch (Exception)
                    {
                        // Handle error here.
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }

        public SelectList GetGrape()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    try
                    {
                        connection.Open();

                        command.CommandText = "SELECT DISTINCT Grape FROM Products";
                        command.Connection = connection;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<SelectListItem> selectListItems = new List<SelectListItem>();
                            selectListItems.Add(new SelectListItem()
                            {
                                Text = "All",
                                Value = "All",
                            });

                            while (reader.Read())
                            {
                                if (!reader.IsDBNull(0))
                                {
                                    string item = reader.GetString(0);
                                    selectListItems.Add(new SelectListItem()
                                    {
                                        Text = item,
                                        Value = item,
                                    });
                                }
                            }

                            return new SelectList(selectListItems, "Value", "Text");
                        }
                    }
                    catch (Exception)
                    {
                        // Handle error here.
                        return null;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }
        }
    }
}