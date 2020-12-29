using ChinaSoftRCW.Utilities;
using ChinaSoftRCW.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public class DataRepository : IDataRepository
    {
        private readonly AppDbContext context;
        private readonly IEnumerable<DimValue> dimValues;
        public DataRepository(AppDbContext context)
        {
            this.context = context;
            if (dimValues is null)
            {
                dimValues = GetDimValues();
            }
        }

        #region DimValues
        public IEnumerable<DimValue> GetDimValues()
        {
            var dimValues = new List<DimValue>();

            var projects = context.Projects;
            if (projects.Any())
            {
                foreach (var project in projects)
                {
                    var dimValue = new DimValue()
                    {
                        Id = project.Id,
                        Name = project.ProjectName,
                        DimTable = nameof(Project)
                    };

                    dimValues.Add(dimValue);
                }
            }

            var techStacks = context.TechStacks;
            if (techStacks.Any())
            {
                foreach (var techStack in techStacks)
                {
                    var dimValue = new DimValue()
                    {
                        Id = techStack.Id,
                        Name = techStack.TechName,
                        DimTable = nameof(TechStack)
                    };

                    dimValues.Add(dimValue);
                }
            }

            var roles = context.Roles;
            if (roles.Any())
            {
                foreach (var role in roles)
                {
                    var dimValue = new DimValue()
                    {
                        Id = role.Id,
                        Name = role.RoleName,
                        DimTable = nameof(Role)
                    };

                    dimValues.Add(dimValue);
                }
            }

            var genders = context.Genders;
            if (genders.Any())
            {
                foreach (var gender in genders)
                {
                    var dimValue = new DimValue()
                    {
                        Id = gender.Id,
                        Name = gender.GenderName,
                        DimTable = nameof(Gender)
                    };

                    dimValues.Add(dimValue);
                }
            }

            var jobStates = context.JobStates;
            if (jobStates.Any())
            {
                foreach (var jobState in jobStates)
                {
                    var dimValue = new DimValue()
                    {
                        Id = jobState.Id,
                        Name = jobState.JobStateName,
                        DimTable = nameof(JobState)
                    };

                    dimValues.Add(dimValue);
                }
            }

            return dimValues;
        }

        public IEnumerable<DimValue> GetDimValuesByName(string tableName)
        {
            return dimValues.Where(a => a.DimTable == tableName);
        }

        public string GetNameById(string tableName, int? id)
        {
            if (id is null)
            {
                return null;
            }

            return dimValues.Where(a => a.DimTable == tableName && a.Id == id).Select(a => a.Name).FirstOrDefault();
        }

        public int GetIdByName(string tableName, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }

            return dimValues.Where(a => a.DimTable == tableName && a.Name == name).Select(a => a.Id).FirstOrDefault();
        }
        #endregion

        #region Candidate
        public Candidate AddCandidate(Candidate candidate)
        {
            context.Candidates.Add(candidate);
            context.SaveChanges();
            return candidate;
        }

        public async Task<Candidate> DeleteCandidateAsync(int id)
        {
            var candidate = context.Candidates.Find(id);
            var comments = context.Comments.Where(a=>a.CandidateId == id).ToList();
            if(comments != null)
            {
                context.Comments.RemoveRange(comments);
            }

            if (candidate != null)
            {
                context.Candidates.Remove(candidate);
                await context.SaveChangesAsync();
            }

            return candidate;
        }

        public IEnumerable<Candidate> GetCandidates()
        {
            return context.Candidates;
        }

        public IEnumerable<Candidate> SearchCandidates(SearchCandidate filter)
        {
            //var p1 = new SqlParameter("@Id", id);
            //var author = db.Authors.FromSqlRaw($"SELECT * From Authors Where AuthorId = @Id", p1).FirstOrDefault()
            var whereCondition = BuildQuery.ConcatStringFilters(filter);
            var candidates = context.Candidates.FromSqlRaw($"select * from Candidates {whereCondition}");
            return candidates.ToList();
        }

        public Candidate GetCandidate(int candidateId)
        {
            var candidate = context.Candidates.Find(candidateId);
            return candidate;
        }

        public Candidate UpdateCandidate(Candidate candidateChanges)
        {
            var candidate = context.Candidates.Attach(candidateChanges);
            candidate.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return candidateChanges;
        }
        #endregion

        #region Comment
        public CandidateComment SaveComment(CandidateComment candidateComment)
        {
            var exitComments = context.Comments.Where(a => a.CandidateId == candidateComment.Id);
            context.Comments.RemoveRange(exitComments);
            context.SaveChanges();

            var interViewComment = candidateComment.InterviewComments;
            var comments = new List<Comment>();

            // HR comment
            var hrComment = interViewComment.HRComment;
            if (!string.IsNullOrWhiteSpace(hrComment))
            {
                comments.Add(new Comment()
                {
                    CandidateId = candidateComment.Id,
                    RoleId = GetIdByName(nameof(Role), ConstStrings.HR),
                    Text = hrComment
                }) ;
            }

            // Interviewer comment
            var interviewerComments = interViewComment.InterviewerComments;
            if (GenericMethod.IsStringOrIntPropertiesHasValue(interviewerComments))
            {
                comments.Add(new Comment()
                {
                    CandidateId = candidateComment.Id,
                    RoleId = GetIdByName(nameof(Role), ConstStrings.Interviewer),
                    Text = JsonSerializer.Serialize(interviewerComments)
                });
            }
            // PM comment
            var pmComment = interViewComment.PMComment;
            if (!string.IsNullOrWhiteSpace(pmComment))
            {
                comments.Add(new Comment()
                {
                    CandidateId = candidateComment.Id,
                    RoleId = GetIdByName(nameof(Role), ConstStrings.PM),
                    Text = pmComment
                });
            }

            // Client comment
            var clientComment = interViewComment.ClientComment;
            if (!string.IsNullOrWhiteSpace(clientComment))
            {
                comments.Add(new Comment()
                {
                    CandidateId = candidateComment.Id,
                    RoleId = GetIdByName(nameof(Role), ConstStrings.Client),
                    Text = clientComment
                });
            }

            context.Comments.AddRange(comments);
            context.SaveChanges();
            return candidateComment;
        }

        public IEnumerable<Comment> GetComments(int candidateId)
        {
            return context.Comments.Where(a => a.CandidateId == candidateId);
        }

        public string GetComment(IEnumerable<Comment> comments, int candidateId, int roleId)
        {
            return comments.Where(a => a.CandidateId == candidateId && a.RoleId == roleId).Select(a => a.Text).FirstOrDefault();
        }
        #endregion
    }
}
