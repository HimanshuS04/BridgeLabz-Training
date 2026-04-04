using System;

namespace HealthCare.Exceptions
{
    public class ClinicException : Exception
    {
        public ClinicException(string message) : base(message) { }

        public static void NotFound(string entity)
        {
            throw new ClinicException($"{entity} not found.");
        }

        public static void Duplicate(string entity)
        {
            throw new ClinicException($"{entity} already exists.");
        }

        public static void Invalid(string message)
        {
            throw new ClinicException(message);
        }
    }
}
