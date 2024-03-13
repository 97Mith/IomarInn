using IomarInn.Domain.Validation;

namespace IomarInn.Domain.ValueObjects;

public class CompanyName
{
    public string FantasyName { get; private set; }
    public string CorporateReason { get; private set; }

    
    public CompanyName(string fantasyName, string corporateReason)
    {
        ValidationMethods
            .IsNullOrEmpty(
                value: fantasyName, 
                message:"Name cannot be blank."
        );
        
        ValidationMethods
            .StringLengthLimits(
                value: fantasyName, 
                minimum: 5, maximum: 35, 
                message: "Name must have between 6 and 35 characters"
        );
        
        ValidationMethods
            .IsNullOrEmpty(
                value: corporateReason, 
                message:"Corporate Reason cannot be blank."
        );
        
        ValidationMethods
            .StringLengthLimits(
                value: corporateReason,
                minimum: 6, maximum: 50,
                message: "Corporate Reason must have between 7 and 50 characters."
        );
        

        FantasyName = fantasyName;
        CorporateReason = corporateReason;

    }
}