using System;



    
        public class PersonalLoan : LoanApplication
        {
            public PersonalLoan(double amount, int tenure)
                : base(amount, tenure, 12.5) { }

            public override bool ApproveLoan(Applicant applicant)
            {
                bool approved = applicant.GetCreditScore() >= 650 &&
                                applicant.Income >= loanAmount * 0.4;

                SetApprovalStatus(approved);
                return approved;
            }
        }
    

