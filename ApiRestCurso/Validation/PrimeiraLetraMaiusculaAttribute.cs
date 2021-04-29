using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestCurso.Validation
{
    public class PrimeiraLetraMaiusculaAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || string.IsNullOrEmpty(value.ToString())){
                return ValidationResult.Success;
            }

            var valorPrimeiro = value.ToString()[0].ToString();

            if(valorPrimeiro != valorPrimeiro.ToUpper())
            {
                return new ValidationResult("Nome invalido");
            }

            return ValidationResult.Success;
        }
    }
}
