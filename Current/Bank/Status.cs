namespace Bank;



public enum BankStatus
{
    NoAccountWithBank,
    Successful,
    IllegalArgument,
    wrongPassword

}

public enum BankAccountStatus
{
    NotLoggedIn,
    NoMoney,
    wrongPin,
    IllegalArgument,
    Successful
}
