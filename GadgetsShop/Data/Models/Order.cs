using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GadgetsShop.Data.Models
{
    /// <summary>
    /// This class represents the model of user's order and specifies the limitations of the following fields.
    /// </summary>
    public class Order
    {
        //Fields
        [BindNever]
        private int id { get; set; }

        [Display(Name = "Введите имя:")]
        [StringLength(25)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        private string name;

        [Display(Name = "Введите фамилию:")]
        [StringLength(25)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        private string surname;

        [Display(Name = "Введите адрес:")]
        [StringLength(40)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        private string adress;

        [Display(Name = "Введите телефон:")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        private string phone;

        [Display(Name = "Введите e-mail:")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25)]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        private string email;

        [BindNever]
        [ScaffoldColumn(false)]
        private DateTime orderTime { set; get; }

        private List<OrderDetail> orderDetails;


        //Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime OrderTime { get => orderTime; set => orderTime = value; }
        public List<OrderDetail> OrderDetails { get => orderDetails; set => orderDetails = value; }
    }
}
