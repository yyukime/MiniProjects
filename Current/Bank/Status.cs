namespace Bank;



public enum BankStatus
{
    NoAccountWithBank,
    Successful,
    IllegalArgument,
    wrongPassword,
    BankIsNotReal,
}

public enum BankAccountStatus
{
    NotLoggedIn,
    NoMoney,
    wrongPin,
    IllegalArgument,
    Successful
}
