using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
public static class EmailUtility
{
    public static bool ValidateEmail(Student student, out List<ValidationResult> results)
    {
        var context = new ValidationContext(student);
        results = new List<ValidationResult>();

        return Validator.TryValidateObject(student, context, results, true);
    }
}

