using System.ComponentModel.DataAnnotations;

namespace ApiSrbWeb.Dto
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
       
        public string SupplierName { get; set; }
        
        public string SupplierContactName { get; set; }
        
        public string SupplierEmail { get; set; }

        
        public string SupplierCnpj { get; set; }

        
        public string SupplierAddress { get; set; }

       
        public string? SupplierPostalCode { get; set; }

        
        public string SupplierCity { get; set; }

        
        public string SupplierState { get; set; }

        
        public string SupplierPhone { get; set; }

        public string SupplierHomePage { get; set; }
    }
}
