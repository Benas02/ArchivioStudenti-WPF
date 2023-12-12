using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFDemo.Model;
using WPFDemo.ModelEF;

namespace WPFDemo.ControllerEF
{
    internal class CorsiController
    {
        #region "Get All Corsi"
        public static async Task<List<Corsi>> GetAllCorsi()
        {
            using (StudentiContext context = new StudentiContext())
            {
                return await context.Corsi.ToListAsync();
            }
        }
        #endregion
    }
}
