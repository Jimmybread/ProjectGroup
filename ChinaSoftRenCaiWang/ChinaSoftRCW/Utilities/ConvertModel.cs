using ChinaSoftRCW.Models;
using ChinaSoftRCW.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities
{
    public static class ConvertModel
    {
        public static Candidate CandidateVMToCandidate(CandidateVM candidateVM, IDataRepository dataRepository)
        {
            var candidate = new Candidate()
            {
                Age = candidateVM.Age,
                Email = candidateVM.Email,
                Experience = candidateVM.Experience,
                FullName = candidateVM.FullName,
                GenderId = candidateVM.GenderId,
                JobStateId = candidateVM.JobStateId,
                Phone = candidateVM.Phone,
                Position = candidateVM.Position,
                ProjectId = candidateVM.ProjectId,
                TechStackId = candidateVM.TechStackId,
                ResidentAddress = candidateVM.ResidentAddress,
                // candidate.ResumePath -- The value is set in controller
            };

            return candidate;
        }

        public static CandidateDetail CandidateToCandidateDetail(Candidate candidate, IDataRepository dataRepository)
        {
            var candidateDetail = new CandidateDetail()
            {
                Id = candidate.Id,
                Age = candidate.Age,
                Email = candidate.Email,
                Experience = candidate.Experience,
                FullName = candidate.FullName,
                Phone = candidate.Phone,
                Position = candidate.Position,
                // ProjectId = candidate.ProjectId,
                // TechStackId = candidate.TechStackId,
                JobState = dataRepository.GetNameById(nameof(JobState), candidate.JobStateId),
                Gender = dataRepository.GetNameById(nameof(Gender), candidate.GenderId),
                Project = dataRepository.GetNameById(nameof(Project),candidate.ProjectId),
                TechStack = dataRepository.GetNameById(nameof(TechStack), candidate.TechStackId),
                ResidentAddress = candidate.ResidentAddress,
                ResumePath = candidate.ResumePath,
            };

            return candidateDetail;
        }

        public static EditCandidate CandidateToEditCandidate(Candidate candidate, IDataRepository dataRepository)
        {
            var editCandidate = new EditCandidate()
            {
                Id = candidate.Id,
                Age = candidate.Age,
                Email = candidate.Email,
                Experience = candidate.Experience,
                FullName = candidate.FullName,
                Phone = candidate.Phone,
                Position = candidate.Position,
                GenderId = candidate.GenderId,
                JobStateId = candidate.JobStateId,
                ProjectId = candidate.ProjectId,
                TechStackId = candidate.TechStackId,
                JobStates = dataRepository.GetDimValuesByName(nameof(JobState)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                Genders = dataRepository.GetDimValuesByName(nameof(Gender)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                TechStacks = dataRepository.GetDimValuesByName(nameof(TechStack)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                Projects = dataRepository.GetDimValuesByName(nameof(Project)).Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList(),
                ResidentAddress = candidate.ResidentAddress,
                ResumePath = candidate.ResumePath,
            };

            return editCandidate;
        }

        public static Candidate EditCandidateToCandidate(EditCandidate editCandidate, IDataRepository dataRepository)
        {
            var candidate = new Candidate()
            {
                Id = editCandidate.Id,
                Age = editCandidate.Age,
                Email = editCandidate.Email,
                Experience = editCandidate.Experience,
                FullName = editCandidate.FullName,
                Phone = editCandidate.Phone,
                Position = editCandidate.Position,
                JobStateId = editCandidate.JobStateId,
                GenderId = editCandidate.GenderId,
                ProjectId = editCandidate.ProjectId,
                TechStackId = editCandidate.TechStackId,
                ResidentAddress = editCandidate.ResidentAddress,
                ResumePath = editCandidate.ResumePath
            };

            return candidate;
        }

        public static CandidateComment CandidateToCandidateComment(Candidate candidate, IDataRepository dataRepository)
        {
            var candidateComment = new CandidateComment()
            {
                Id = candidate.Id,
                Age = candidate.Age,
                Email = candidate.Email,
                Experience = candidate.Experience,
                FullName = candidate.FullName,
                GenderId = candidate.GenderId,
                JobStateId = candidate.JobStateId,
                Phone = candidate.Phone,
                Position = candidate.Position,
                //ProjectId = candidate.ProjectId,
                //TechStackId = candidate.TechStackId,
                JobState = dataRepository.GetNameById(nameof(JobState), candidate.GenderId),
                Gender = dataRepository.GetNameById(nameof(Gender), candidate.GenderId),
                Project = dataRepository.GetNameById(nameof(Project), candidate.ProjectId),
                TechStack = dataRepository.GetNameById(nameof(TechStack), candidate.TechStackId),
                ResidentAddress = candidate.ResidentAddress,
                ResumePath = candidate.ResumePath,
            };

            return candidateComment;
        }
    }
}
