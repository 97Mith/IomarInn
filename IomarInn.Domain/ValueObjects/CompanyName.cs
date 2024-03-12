using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class CompanyName
{
    public string FantasyName { get; }
    public string CorporateReason { get; }

    public CompanyName(string fantasyName, string corporateReason)
    {
        ValidateMethods
            .IsNullOrEmpty(
                value: fantasyName, 
                message:"Name cannot be blank."
        );
        
        ValidateMethods
            .StringLengthLimits(
                value: fantasyName, 
                minimum: 5, maximum: 35, 
                message: "Name must have between 6 and 35 characters"
        );
        
        ValidateMethods
            .IsNullOrEmpty(
                value: corporateReason, 
                message:"Corporate Reason cannot be blank."
        );
        
        ValidateMethods
            .StringLengthLimits(
                value: corporateReason,
                minimum: 6, maximum: 50,
                message: "Corporate Reason must have between 7 and 50 characters."
        );
        

        FantasyName = fantasyName;
        CorporateReason = corporateReason;

    }
}