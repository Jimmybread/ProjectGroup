using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ChinaSoftRCW.Models;
using ChinaSoftRCW.Utilities;
using ChinaSoftRCW.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ChinaSoftRCW.Controllers
{
    [Authorize(Roles = "SupperAdmin, Admin, Interviewer, HR")]
    public class CommentController : BaseController
    {
        public CommentController(IDataRepository dataRepository, IHostEnvironment hostEnvironment) : base(dataRepository, hostEnvironment)
        {
        }

        [HttpGet]
        public IActionResult CandidateComment(int Id)
        {
            var candidate = _dataRepository.GetCandidate(Id);
            var candidateComment = new CandidateComment();
            if (candidate != null)
            {
                candidateComment = ConvertModel.CandidateToCandidateComment(candidate, _dataRepository);
            }

            var comments = _dataRepository.GetComments(Id);
            if (comments.Any())
            {
                var hrRoleId = _dataRepository.GetIdByName(nameof(Role), ConstStrings.HR);
                var interviewerId = _dataRepository.GetIdByName(nameof(Role), ConstStrings.Interviewer);
                var pmId = _dataRepository.GetIdByName(nameof(Role), ConstStrings.PM);
                var clientId = _dataRepository.GetIdByName(nameof(Role), ConstStrings.Client);

                candidateComment.InterviewComments = new InterviewComments()
                {
                    HRComment = _dataRepository.GetComment(comments, Id, hrRoleId),
                    PMComment = _dataRepository.GetComment(comments, Id, pmId),
                    ClientComment = _dataRepository.GetComment(comments, Id, clientId),
                };

                // Interviewer Comment
                var interviewerJson = _dataRepository.GetComment(comments, Id, interviewerId);
                if (!string.IsNullOrWhiteSpace(interviewerJson))
                {
                    var interviewerComments = JsonSerializer.Deserialize<InterviewerComments>(interviewerJson);
                    candidateComment.InterviewComments.InterviewerComments = interviewerComments;
                }
            }

            return View(candidateComment);
        }


        [HttpPost]
        public IActionResult SaveComment(CandidateComment candidateComment)
        {
            _dataRepository.SaveComment(candidateComment);
            return RedirectToAction("CandidateComment", new { id = candidateComment.Id});
        }
    }
}