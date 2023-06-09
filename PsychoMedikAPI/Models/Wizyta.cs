using PsychoMedikAPI.Models.Abstract;
using System.ComponentModel.DataAnnotations.Schema;

namespace PsychoMedikAPI.Models
{
    public class Wizyta : DescriptionTable
    {
        // dzien, opacjent, lekarz,(godzina rozpoczecia?)
        public DateTime? DataWizyty { get; set; }
        public int? IdPacjenta { get; set; }
        [ForeignKey("IdPacjenta")]
        public virtual Pacjent? Pacjent { get; set; }
        public int? IdLekarza { get; set; }
        [ForeignKey("IdLekarza")]
        public virtual Pracownik? Pracownik { get; set; }
    }
}
