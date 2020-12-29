using ChinaSoftRCW.ViewModels;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChinaSoftRCW.Utilities
{
    public static class BuildQuery
    {
        public static string ConcatStringFilters(SearchCandidate filters)
        {
            var query = string.Empty;
            if (GenericMethod.IsStringOrIntPropertiesHasValue(filters))
            {
                query = $"where ";
                var conditions = new List<string>();
                var projectId = filters.ProjectId;
                if (!string.IsNullOrWhiteSpace(projectId?.ToString()))
                {
                    conditions.Add($"projectId = {projectId}");
                }

                var fullName = filters.FullName;
                if (!string.IsNullOrWhiteSpace(fullName))
                {
                    conditions.Add($"fullName like '%{fullName}%'");
                }

                var phone = filters.Phone;
                if (!string.IsNullOrWhiteSpace(phone))
                {
                    conditions.Add($"phone like '%{phone}%'");
                }

                query = query + string.Join(" and ", conditions);
            }

            return query;
        }
    }
}
