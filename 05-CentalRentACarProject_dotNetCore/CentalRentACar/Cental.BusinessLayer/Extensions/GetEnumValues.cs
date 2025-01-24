using Cental.EntityLayer.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.Extensions
{
    public static class GetEnumValues
    {
        public static List<SelectListItem> GetEnums<T>()
        {
            var values = Enum.GetValues(typeof(T));

            var selectList = new List<SelectListItem>();

            foreach (var value in values)
            {
                selectList.Add(new SelectListItem { Text = value.ToString(), Value = value.ToString() });
            }

            return selectList;
        }
    }
}
