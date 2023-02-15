using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtApi.Shared
{
    public static class ListExtension
    {
        public static PageList<T> ToPageList<T>(this IQueryable<T> list, int page, int pageSize, long count) where T : class
            {
            var items = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            var totalPage = (int)Math.Ceiling((decimal)count / pageSize);
            return new PageList<T>(items, page, totalPage, pageSize, count);
        }
    }
}
