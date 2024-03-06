﻿using FluentValidation.Results;

namespace CleanArchitectureDDD.App.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = [];
        }
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
                Errors.Add(failure.ErrorMessage);
        }

    }
}
