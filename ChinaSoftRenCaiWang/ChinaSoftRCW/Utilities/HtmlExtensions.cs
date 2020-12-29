using ChinaSoftRCW.ViewModels;
using System;
using System.Collections.Generic;
using ChinaSoftRCW.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ChinaSoftRCW.Utilities
{
    public static class HtmlExtensions
    {
        public static string GetNameById(List<DimValue> dimValues, string dimTable, int? id)
        {
            if(id is null)
            {
                return string.Empty;
            }

            return dimValues.Where(a => a.DimTable == dimTable && a.Id == id).Select(a => a.Name).FirstOrDefault();
        }

        public static int GetIdByName(List<DimValue> dimValues, string dimTable, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return 0;
            }

            return dimValues.Where(a => a.DimTable == dimTable && a.Name == name).Select(a => a.Id).FirstOrDefault();
        }
    }
}
