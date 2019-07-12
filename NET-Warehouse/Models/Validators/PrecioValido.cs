using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NET_Warehouse.Models.Validators
{
    public class PrecioValido : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            try
            {
                decimal precio = (decimal)value;
                if (precio <= 0)
                {
                    ErrorMessage = "El precio debe ser mayor que 0!";
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(InvalidCastException ice)
            {
                ErrorMessage = "El precio debe ser un numero decimal!";
                return false;
            }
            catch(Exception ex)
            {
                ErrorMessage = "Verifique el precio ingresado!";
                return false;
            }

        }
    }
}