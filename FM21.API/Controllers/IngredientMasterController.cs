﻿using FM21.Core.Model;
using FM21.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FM21.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [SwaggerTag("All Ingredient master related API methods")]
    //[ApiExplorerSettings(GroupName = "v1.0")]
    [ApiController]
    public class IngredientMasterController : ControllerBase
    {
        private readonly IIngredientMasterService ingredientMasterService;

        public IngredientMasterController(IIngredientMasterService ingredientMasterService)
        {
            this.ingredientMasterService = ingredientMasterService;
        }

        [SwaggerOperation(Summary = "Get list of ingredient categories.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetAllIngredientCategory")]
        public async Task<IActionResult> GetAllIngredientCategory()
        {
            var response = await ingredientMasterService.GetAllIngredientCategory();
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get alert master data.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetAlertMasterData/{alertType}")]
        public async Task<IActionResult> GetAlertMasterData(string alertType)
        {
            var response = await ingredientMasterService.GetAlertMasterData(alertType);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Fetch and get next auto generated JDE code.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetAutoGeneratedJDECode/{ingredientCategoryCode}")]
        public async Task<IActionResult> GetAutoGeneratedJDECode(int ingredientCategoryCode)
        {
            var response = await ingredientMasterService.GetAutoGeneratedJDECode(ingredientCategoryCode);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Fetch and get next auto generated JDE code.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetAutoGeneratedS30Code")]
        public async Task<IActionResult> GetAutoGeneratedS30Code(int siteID, int ingredientCategoryCode)
        {
            var response = await ingredientMasterService.GetAutoGeneratedS30Code(siteID, ingredientCategoryCode);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Fetch and get next auto generated JDE code.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetAutoGeneratedRAndDCode")]
        public async Task<IActionResult> GetAutoGeneratedRAndDCode()
        {
            var response = await ingredientMasterService.GetAutoGeneratedRAndDCode();
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Check whether code is exist in JDE code, R&D code, or with any part number.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("CheckCodeIsExist")]
        public async Task<IActionResult> CheckCodeIsExist(string code)
        {
            var response = await ingredientMasterService.CheckCodeIsExist(code);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Add new Ingredient.", Tags = new string[] { "IngredientMaster" })]
        [HttpPost]
        public async Task<IActionResult> PostIngredient(IngredientModel ingredient)
        {
            var response = await ingredientMasterService.SaveNewIngredient(ingredient);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Update existing Ingredient.", Tags = new string[] { "IngredientMaster" })]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, IngredientModel ingredient)
        {
            ingredient.Ingredient.IngredientID = id;
            var response = await ingredientMasterService.UpdateIngredient(ingredient);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Delete the Ingredient.", Tags = new string[] { "IngredientMaster" })]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var response = await ingredientMasterService.DeleteIngredient(id);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get ingredient master details by ingredientId.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientByIngredientID/{ingredientID}")]
        public async Task<IActionResult> GetIngredientByIngredientID(int ingredientID)
        {
            var response = await ingredientMasterService.GetIngredientByIngredientID(ingredientID);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get ingredient supplier details by ingredientId.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetSupplierByIngredientID/{ingredientID}")]
        public async Task<IActionResult> GetSupplierByIngredientID(int ingredientID)
        {
            var response = await ingredientMasterService.GetSupplierByIngredientID(ingredientID);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get nutrients by ingredientId", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetNutrientByIngredientID")]
        public async Task<IActionResult> GetNutrientByIngredientID(int ingredientID)
        {
            var response = await ingredientMasterService.GetNutrientByIngredientID(ingredientID);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Search Ingredient based on supplied parameters", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("SearchIngredient")]
        public async Task<IActionResult> SearchIngredient([FromQuery] IngredientSearchFilter searchFilter)
        {
            var response = await ingredientMasterService.SearchIngredient(searchFilter);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Update ingredient search history for user.", Tags = new string[] { "IngredientMaster" })]
        [HttpPut("UpdateIngredientSearchHistory")]
        public async Task<IActionResult> UpdateIngredientSearchHistory(int userID, string searchData)
        {
            var response = await ingredientMasterService.UpdateIngredientSearchHistory(userID, searchData);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get last 5 ingredient search history by user", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientSearchHistory")]
        public async Task<IActionResult> GetIngredientSearchHistory(int userID)
        {
            var response = await ingredientMasterService.GetIngredientSearchHistory(userID);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get Ingredient Report Data by supplied parameters", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientReportData")]
        public async Task<IActionResult> GetIngredientReportData(string reportType, string siteIDs, string productTypeID)
        {
            var response = await ingredientMasterService.GetIngredientReportData(reportType, siteIDs, productTypeID);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get Ingredient Custom Report Data by supplied parameters", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientCustomReportData")]
        public async Task<IActionResult> GetIngredientCustomReportData([FromQuery] IngredientReportFilter searchFilter)
        {
            var response = await ingredientMasterService.GetIngredientCustomReportData(searchFilter);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get Ingredient information for bind in formula screen", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientForFormula")]
        public async Task<IActionResult> GetIngredientForFormula([FromQuery] IngredientReportFilter searchFilter)
        {
            var response = await ingredientMasterService.GetIngredientForFormula(searchFilter);
            return new JsonResult(response);
        }

        [SwaggerOperation(Summary = "Get ingredient part info by ingredientId.", Tags = new string[] { "IngredientMaster" })]
        [HttpGet("GetIngredientPartInfo/{ingredientID}")]
        public async Task<IActionResult> GetIngredientPartInfo(int ingredientID)
        {
            var response = await ingredientMasterService.GetIngredientPartInfo(ingredientID);
            return new JsonResult(response);
        }
    }
}