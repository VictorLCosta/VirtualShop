using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using VirtualShop.Models;
using VirtualShop.Repositories.Contracts;

namespace VirtualShop.Libraries.Validation
{
    public class UniqueCollaboratorEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string Email = (value as string).Trim();

            var collaboratorRep = (ICollaboratorRepository)validationContext.GetService(typeof(ICollaboratorRepository));

            var collaborator = collaboratorRep.FindAsync(Email).Result;

            if(collaborator != null)
            {
                return new ValidationResult("E-mail já está sendo usado");
            }

            return ValidationResult.Success;
        }
    }
}