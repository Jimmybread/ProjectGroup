using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ChinaSoftRCW.Models;
using ChinaSoftRCW.Utilities;
using ChinaSoftRCW.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace ChinaSoftRCW.Controllers
{
    [Authorize]
    public class CandidateController : BaseController
    {
        public CandidateController(IDataRepository dataRepository,
            IHostEnvironment hostEnvironment) : base(dataRepository, hostEnvironment)
        {
        }

        public IActionResult Index()
        {

            var candidates = _dataRepository.GetCandidates();
            var candidateDetails = new List<CandidateDetail>();
            foreach (var candidate in candidates)
            {
                var candidateDetail = ConvertModel.CandidateToCandidateDetail(candidate, _dataRepository);
                candidateDetails.Add(candidateDetail);
            }

            var searchCandidate = new SearchCandidate();
            searchCandidate.CandidateDetailList = candidateDetails;
            searchCandidate.Projects = _dataRepository.GetDimValuesByName(nameof(Project)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            return View(searchCandidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchCandidates(SearchCandidate filter)
        {
            if (filter.ProjectId < 1)
            {
                filter.ProjectId = null;
            }

            var candidates = _dataRepository.SearchCandidates(filter);

            var candidateDetails = new List<CandidateDetail>();
            foreach (var candidate in candidates)
            {
                var candidateDetail = ConvertModel.CandidateToCandidateDetail(candidate, _dataRepository);
                candidateDetails.Add(candidateDetail);
            }

            var searchCandidate = new SearchCandidate();
            searchCandidate.CandidateDetailList = candidateDetails;
            searchCandidate.Projects = _dataRepository.GetDimValuesByName(nameof(Project)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            return View("Index", searchCandidate);
        }

        [HttpGet]
        public IActionResult CandidateDetail(int id)
        {
            var candidate = _dataRepository.GetCandidate(id);
            var candidateDetail = new CandidateDetail();
            if (candidate != null)
            {
                candidateDetail = ConvertModel.CandidateToCandidateDetail(candidate, _dataRepository);
            }

            return View(candidateDetail);
        }

        [HttpGet]
        public IActionResult CreateCandidate()
        {
            var model = new CreateCandidateVM()
            {
                Genders = _dataRepository.GetDimValuesByName(nameof(Gender)).Select(a=> new SelectListItem { Value = a.Id.ToString(), Text = a.Name}).ToList(),
                JobStates = _dataRepository.GetDimValuesByName(nameof(JobState)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                TechStacks = _dataRepository.GetDimValuesByName(nameof(TechStack)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                Projects = _dataRepository.GetDimValuesByName(nameof(Project)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCandidate(CreateCandidateVM model)
        {
            if (ModelState.IsValid)
            {
                var candidate = ConvertModel.CandidateVMToCandidate(model, _dataRepository);

                if (model.Resume != null)
                {
                    candidate.ResumePath = UploadFile(model.Resume, model.FullName);
                }

                var result = _dataRepository.AddCandidate(candidate);
                return RedirectToAction("CandidateDetail", new { id = result.Id });
            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult EditCandidate(int id)
        {
            var candidate = _dataRepository.GetCandidate(id);
            var editCandidate = new EditCandidate();
            if (candidate != null)
            {
                editCandidate = ConvertModel.CandidateToEditCandidate(candidate, _dataRepository);
            }

            return View(editCandidate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCandidate(EditCandidate model)
        {
            if (ModelState.IsValid)
            {
                var candidate = ConvertModel.EditCandidateToCandidate(model, _dataRepository);

                if (model.Resume != null)
                {
                    candidate.ResumePath = UploadFile(model.Resume, model.FullName);
                }

                var result = _dataRepository.UpdateCandidate(candidate);
                return RedirectToAction("CandidateDetail", new { id = result.Id });
            }

            return View("Index");
        }

        public async Task<JsonResult> DeleteCandidateAsync(int id)
        {
            if (id == 0)
            {
                return new JsonResult(new { IsSuccess = false, msg = "删除失败" });
            }

            try
            {
                await _dataRepository.DeleteCandidateAsync(id);
                return new JsonResult(new { IsSuccess = false, msg = "删除成功" });
            }
            catch
            {
                return new JsonResult(new { IsSuccess = false, msg = "删除失败" });
            }

        }

        public async Task<IActionResult> DownloadFile(string fileName)
        {
            if (fileName == null)
                return Content("filename not present");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Resume", fileName);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}