﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemo.Model
{
    public class Corso
    {
        #region "DataBase Mapped"
        public int IdCorso { get; set; }
        public string Nome { get; set; }

        public Studente[] Studenti { get; set; }
        #endregion
    }
}