// See https://aka.ms/new-console-template for more information
Console.WriteLine(
@"1. Money can be deposited at any time.
Money can be withdrawn only after the account owner's identity has been verified.

2. Unverified account can only deposit.

3. Closed accout can't deposit or withdraw.

4. A verified and not closed acount can be frozen. A deposit or withdraw will unfreeze the account.
Unfreezing the account triggers a custom action.
");
