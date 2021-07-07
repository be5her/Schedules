using Microsoft.AspNetCore.Mvc.Rendering;
using Schedules_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Model
{
    public class StageModal
    {
        public static List<SelectListItem> GetSelectList(int? selected = null)
        {
            using (var _context = new DB())
            {
                List<SelectListItem> list;
                if (selected == null)
                {
                    list = new SelectList(_context.Stages, "Stage_id", "Name").ToList();
                }
                else
                {
                    list = new SelectList(_context.Stages, "Stage_id", "Name", selected).ToList();
                }
                return list;
            }
        }
    }
}
