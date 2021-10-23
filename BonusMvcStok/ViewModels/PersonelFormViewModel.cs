using BonusMvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BonusMvcStok.ViewModels
{
    public class PersonelFormViewModel
    {
        public IEnumerable<tbldepartman> Departmanlar { get; set; }
        public tblpersonel Personel { get; set; }
    }
}