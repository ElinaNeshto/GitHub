using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace to.Models
{
    public class lr1Data
    {
         public Guid Id { get; set; } = Guid.Empty;
        
        public string name { get; set; }
        public double price { get; set; }
        public int capacity { get; set; }

    

       public BaseModelValidationResult Validate()
       {
           var validationResult = new BaseModelValidationResult();

           if (string.IsNullOrWhiteSpace(name)) validationResult.Append($"name cannot be empty");
            if (!(0 < price)) validationResult.Append($"price {price} cannot be <0");
           if (!(0 < capacity)) validationResult.Append($"capacity {capacity} cannot be <0");

           return validationResult;
       }

       public override string ToString()
       {
           return $"{name} {price} from {Id}";
       }
   }

    }

    

       

