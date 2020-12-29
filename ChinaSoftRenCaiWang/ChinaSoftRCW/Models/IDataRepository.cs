using ChinaSoftRCW.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Models
{
    public interface IDataRepository
    {
        #region Candidate
        Candidate AddCandidate(Candidate candidate);
        Task<Candidate> DeleteCandidateAsync(int Id);
        Candidate GetCandidate(int candidateId);
        IEnumerable<Candidate> GetCandidates();
        IEnumerable<Candidate> SearchCandidates(SearchCandidate filter);
        Candidate UpdateCandidate(Candidate candidate);
        #endregion

        #region DimValues
        IEnumerable<DimValue> GetDimValues();
        IEnumerable<DimValue> GetDimValuesByName(string tableName);
        string GetNameById(string tableName, int? id);
        int GetIdByName(string tableName, string name);
        #endregion

        #region Comment
        CandidateComment SaveComment(CandidateComment candidateComment);
        IEnumerable<Comment> GetComments(int candidateId);
        string GetComment(IEnumerable<Comment> comments, int candidateId, int roleId);
        #endregion
    }
}
