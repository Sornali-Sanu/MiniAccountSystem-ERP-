using Microsoft.AspNetCore.Mvc.Rendering;
using MiniAccountSystem.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace MiniAccountSystem.Web.ViewModels
{
    public class AccountVM
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Account Code")]
        public string AccountCode { get; set; }
        [Required]
        [Display(Name ="Account Name")]
        public string AccountName { get; set; }
        [Required]
        [Display(Name ="Account Type")]
        public int AccountTypeId { get; set; }
        [Required]
        [Display(Name ="Parent Account")]
        public int? ParentAccountId { get; set; }

        public bool IsActive { get; set; } = true;
        public List<SelectListItem> AccountTypes { get; set; } = new();
        public List<SelectListItem> ParentAccounts { get; set; } = new();
    }
}
