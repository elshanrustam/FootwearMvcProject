using BusinessLogicLayer.Abstract;
using BusinessLogicLayer.Dtos;
using BusinessLogicLayer.Extensions;
using EntityLayer.Concrete.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FootwearMvcProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DashboardController(IProductService productService, 
                                     ICategoryService categoryService, 
                                     IBrandService brandService,
                                     IWebHostEnvironment environment) : Controller
    {
        private readonly IProductService _productService = productService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly IBrandService _brandService = brandService;
        private readonly IWebHostEnvironment _environment = environment;

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }



        #region Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Brands = await _brandService.GetBrandViewDtos();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAddDto product, int brandId, int categoryId)
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Brands = await _brandService.GetBrandViewDtos();

            #region Save Image
            if (product.Photo == null)
            {
                ModelState.AddModelError("Photo", "please select photo");
                return View();
            }
            if (!product.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "please select image type");
                return View();
            }
            if (product.Photo.IsOrder1Mb())
            {
                ModelState.AddModelError("Photo", "Max 1Mb");
                return View();
            }
            string folder = Path.Combine(_environment.WebRootPath, "user", "images");
            product.Image = await product.Photo.SaveFileAsync(folder);
            #endregion

            product.BrandId = brandId;
            product.CategoryId = categoryId;
            await _productService.AddProductAsync(product);
            return RedirectToAction("Index");
        }
        #endregion

        #region Detail
        public async Task<IActionResult> ShowImage(int id)
        {
            var productImage = await _productService.GetProductImageAsync(id);
            return View(productImage);

        }
        #endregion

        #region Update
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Brands = await _brandService.GetBrandViewDtos();

            ProductAddDto dbProduct = await _productService.GetByIdProductAsync(id);

            if (dbProduct == null)
            {
                return BadRequest();
            }
            return View(dbProduct);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, ProductAddDto product)
        {
            ViewBag.Categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Brands = await _brandService.GetBrandViewDtos();

            ProductAddDto dbProduct = await _productService.GetByIdProductAsync(id);

            if (dbProduct == null)
            {
                return BadRequest();
            }

            #region Save Image
            if (product.Photo != null)
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Zəhmət olmasa, şəkil növü seçin");
                    return View(dbProduct);
                }
                if (product.Photo.IsOrder1Mb())
                {
                    ModelState.AddModelError("Photo", "Maksimum 1Mb");
                    return View(dbProduct);
                }

                string folder = Path.Combine(_environment.WebRootPath, "user", "images");
                string path = Path.Combine(folder, dbProduct.Image);

                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                dbProduct.Image = await product.Photo.SaveFileAsync(folder);
            }
            #endregion

            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.BrandId = product.BrandId;

            await _productService.UpdateProduct(dbProduct);

            return RedirectToAction("Index");
        }

        #endregion

        #region Activity
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ProductAddDto dbProduct = await _productService.GetByIdProductAsync(id.Value);
            if (dbProduct == null)
            {
                return BadRequest();
            }
            if (!dbProduct.IsDeactive)
            {
                dbProduct.IsDeactive = true;
            }
            else
            {
                dbProduct.IsDeactive = false;
            }

            await _productService.UpdateProduct(dbProduct);
            return RedirectToAction("Index");
        }
        #endregion



    }
}
