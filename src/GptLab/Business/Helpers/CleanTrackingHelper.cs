using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Helpers
{
    using EntityModel.Models;
    using Microsoft.EntityFrameworkCore;
    public class CleanTrackingHelper
    {
        public static void Clean<T>(MyDBContext context) where T : class
        {
            foreach (var fooXItem in context.Set<T>().Local)
            {
                context.Entry(fooXItem).State = EntityState.Detached;
            }
        }
    }
}
