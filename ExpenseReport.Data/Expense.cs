using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseReport.Data
{
    public enum Category {Airfare = 1, VehicleRental, Fuel, OtherTransportatoin, Parking, Lodging, Meal, Postage, Entertainment, OfficeSupplies, ParkingOrToll, Other}
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public DateTime DateofExpense { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
