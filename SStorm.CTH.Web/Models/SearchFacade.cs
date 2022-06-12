using Microsoft.AspNetCore.Mvc.Rendering;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SStorm.CTH.DAL.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace SStorm.CTH.Web.Models
{
    public class SearchFacade<T> where T : IEntity2, new()
    { 
        public int SortOperator { get; set; }
        public string SortByFieldName { get; set; }
        public string SortOrder { get; set; }
        //public string CurrentFilter { get; set; }
        public virtual string SearchString { get; set; }
        int _page;
        public int Page
        {
            get
            {
                return Math.Max(_page, 1);
            }
            set
            {
                _page = value;
            }
        }

        int _pageSize;
        public int PageSize
        {
            get
            {
                return _pageSize == 0 ? 10 : _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }

        public int CurrentPage { get; set; }


        public IPagedList<T> DataPagedList { get; set; }

    }

}
