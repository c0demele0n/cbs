using Machine.Specifications;
using FluentValidation.Results;
using Domain.StaffUser;

namespace Domain.Specs.StaffUser.ExtendedInfo
{
    [Subject(typeof(ExtendedInfoValidator))]
    public class when_validating_with_valid_values
    {
        static ExtendedInfoValidator validator;
        static ValidationResult validation_results;
        static Domain.StaffUser.ExtendedInfo sut;

        Establish context = () =>
        {
            validator = new ExtendedInfoValidator();
            sut = given.extended_info.build_valid_instance();
        };

        Because of = () => { validation_results = validator.Validate(sut); };

        It should_be_valid = () => validation_results.ShouldBeValid();          
    }
}