using Domain.DataCollectors.Registering;
using FluentValidation.Results;
using Machine.Specifications;

namespace Domain.Specs.DataCollector.when_registering_a_data_collector
{
    [Subject("Registration")]
    public class and_validating_a_command_with_an_invalid_year_of_birth
    {
        static RegisterDataCollector cmd;
        static RegisterDataCollectorValidator validator;
        static ValidationResult validation_results;

        Establish context = () => 
        {
            validator = new RegisterDataCollectorValidator();

            cmd = given.a_command_builder.get_invalid_command((cmd) => cmd.YearOfBirth = 1 );
        };

        Because of = () => { validation_results = validator.Validate(cmd); };
        It should_be_invalid = () => validation_results.ShouldBeInvalid();
        It should_identify_the_first_name_as_the_problem = () => validation_results.ShouldHaveInvalidProperty(nameof(cmd.YearOfBirth));
    }
}