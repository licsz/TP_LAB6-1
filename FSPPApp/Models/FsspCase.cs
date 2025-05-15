using System;
using System.ComponentModel.DataAnnotations;

namespace FSPPApp.Models
{
    public class FsspCase
    {
        [Display(Name = "Номер исполнительного производства")]
        public int? CaseNumber { get; set; }
        
        [Required]
        [Display(Name = "ФИО должника")]
        public string FullName { get; set; }
        
        [Display(Name = "Сумма задолженности (руб.)")]
        [DataType(DataType.Currency)]
        public decimal? DebtAmount { get; set; }
        
        [Display(Name = "Дата возбуждения производства")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CaseDate { get; set; }
        
        [Display(Name = "Статус исполнительного производства")]
        public string CaseStatus { get; set; }
        
        [Display(Name = "Наложен арест на имущество")]
        public bool HasPropertyArrest { get; set; }
    }
} 