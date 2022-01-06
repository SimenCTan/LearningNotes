using System.Linq;
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, in FieldIdentifier fieldIdentifier)
    {
        var isValidate = !editContext.GetValidationMessages(fieldIdentifier).Any();
        return isValidate?"validField" : "invalidField";
    }
}
