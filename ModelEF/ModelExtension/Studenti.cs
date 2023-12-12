using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.ModelEF
{
    public partial class Studenti : IDataErrorInfo
    {
        #region "Costruttori"
        public Studenti()
        {

        }
        public Studenti(DateTime dataNascita)
        {
            DataNascita = dataNascita;
        }
        #endregion

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Cognome")
                {
                    if(string.IsNullOrEmpty(Cognome)) 
                        return "Campo Obbligatorio";
                    else 
                        return null;
                }

                if (columnName == "Nome")
                {
                    return string.IsNullOrEmpty(Nome) ? "Campo Obbligatorio" : null;
                }

                return null;
            }
        }

        public string Error => null;

        public bool InRegolaConPagamenti { get; set; } = false;
    }
}
