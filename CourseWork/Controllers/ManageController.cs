using CourseWork.Data;
using CourseWork.Models;
using CourseWork.Models.Composite;
using CourseWork.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private IManagerProduct _managerProduct { get; set; }
        private IIngredientsDictionary _ingredients { get; set; }
        private StorageService _storageService { get; set; }
        private KitchenService _kitchenService { get; set; }
        public ManageController(IManagerProduct managerProduct
            , EFContext context, IIngredientsDictionary ingredients)
        {
            _managerProduct = managerProduct;
            _ingredients = ingredients;


            var _context = context;
            var _storageService = new StorageService(_context, ingredients);
            var _kitchenService = new KitchenService(_storageService, _context, ingredients);

            this._kitchenService = _kitchenService;
            this._storageService = _storageService;

            _managerProduct.AddProperties(_storageService);
            _managerProduct.AddProperties(_kitchenService);
        }

        [HttpGet]
        [Route("removemoldy/{productCode}")]
        public IActionResult RemoveMoldyProduct(Guid productCode) 
        {
            _managerProduct.RemoveMoldyProduct(productCode);

            return Created("/", new { });
        }

        [HttpGet]
        [Route("movetokitchen/{productCode}")]
        public IActionResult MoveProductToKitchen(Guid productCode)
        {
            _managerProduct.MoveToKitchen(productCode);

            return Created("/", new { });
        }

        [HttpGet]
        [Route("movetostorage/{productCode}")]
        public IActionResult MoveProductToStorage(Guid productCode)
        {
            _managerProduct.MoveToStorage(productCode);

            return Created("/", new { });
        }

        [HttpGet]
        [Route("getreport")]
        public IActionResult GetReport() 
        {
            PRCodeReport pRCodeReport = new PRCodeReport(this._ingredients);

            BodyReport bodyReport = new BodyReport(this._kitchenService, 
                this._storageService, _ingredients);

            bodyReport.AddReport(pRCodeReport);

            Report report = new Report();

            report.AddReport(bodyReport);

            string result = report.GetReport();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Output", "report.txt");

            System.IO.FileInfo fileInfo = new System.IO.FileInfo(filePath);

            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }

            using (StreamWriter sw = new StreamWriter(fileInfo.Create())) 
            {
                sw.WriteLine(result);
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/octet-stream", "report.txt");
        }
    }
}
