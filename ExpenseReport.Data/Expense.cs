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
        public Category Category { get; set; }
        public DateTime DateofExpense { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Location { get; set; }
    }
}
