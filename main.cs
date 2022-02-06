using System;

class Program {
  public static void Main (string[] args) {
    Checking c = new Checking();
    Savings s = new Savings();
    int choice;
    int amount;
    while(true){
    amount = 0;
    Console.WriteLine("Menu: ");
    Console.WriteLine("1. Withdraw from Checking");
    Console.WriteLine("2. Withdraw from Savings");
    Console.WriteLine("3. Deposit to Checking");
    Console.WriteLine("4. Deposit to Savings");
    Console.WriteLine("5. Balance of Checking");
    Console.WriteLine("6. Balance of Savings");
    Console.WriteLine("7. Award Interest to Savings now");
    Console.WriteLine("8. Quit");
    Console.WriteLine();
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice){
      case 1: 
        Console.WriteLine("How much would you like to withdraw from checking?");
        amount = Convert.ToInt32(Console.ReadLine());
        c.withdraw(amount);
      break;
      case 2: 
        Console.WriteLine("How much would you like to withdraw from savings?");
        amount = Convert.ToInt32(Console.ReadLine());
        s.withdraw(amount);
      break;
      case 3: 
        Console.WriteLine("How much would you like to deposit into checking?");
        amount = Convert.ToInt32(Console.ReadLine());
        c.deposit(amount);
      break;
      case 4: 
      Console.WriteLine("How much would you like to deposit into savings?");
        amount = Convert.ToInt32(Console.ReadLine());
        s.deposit(amount);
      break;
      case 5:
      Console.WriteLine("Your Balance from checking " + c.getAccount_Num() + " is " + c.getBalance());
      break;
      case 6: 
      Console.WriteLine("Your Balance from savings " + s.getAccount_Num() + " is " + s.getBalance());
      break;
      case 7:
      s.Add_Interest(); 
      break;
      case 8:
        System.Environment.Exit(0);
      break;
      }
    }
  }
abstract class Account{
  static private int next_Account_Num = 10001;
  private int Account_Num;
  private double Balance;
  public Account(){
    Account_Num = next_Account_Num;
    Balance = 0;
    next_Account_Num++;
    }
  public Account(double b){
    Account_Num = next_Account_Num;
    Balance = b;
    next_Account_Num++;
    }
  public int getAccount_Num(){
    return Account_Num;
    } 
  public void setBalance(double b){
    Balance = b;
    }
  public double getBalance(){
    return Balance;
    }
  public virtual void withdraw(double w){
    Balance -= w;
    }
  public virtual void deposit(double d){
    Balance += d;
    }
  }
  class Checking : Account {
    public Checking(double b) : base(b){
      }
    public Checking() : base(){
    }
    public override void withdraw(double w){
      base.setBalance(base.getBalance() - w); 
      if (base.getBalance() < 0) {
        Console.WriteLine("Charging an overdraft fee of $20 because account is below $0");
        base.withdraw(20);
      }
    }
  }
  class Savings : Account {
    public int counter;
    public Savings(double b) : base(b){
      counter = 0;
      }
    public Savings() : base() {
      counter = 0;
    }
    public override void withdraw(double w){
      if (base.getBalance() < 500) {
        Console.WriteLine("Charging a fee of $10 because you are below $500");
        base.withdraw(10);
      }
      base.withdraw(w);
    }
    public override void deposit(double d){
      counter++;
      if(counter < 5){
      Console.WriteLine("This is deposit "+counter+" to this account");
      }
      else {
        Console.WriteLine("Charging a fee of $10");
        base.withdraw(10);
      }
      base.setBalance(base.getBalance() + d);
    }
    public void Add_Interest(){
      double inrst = base.getBalance() * .015;
      Console.WriteLine("Customer earned "+ inrst +" in interest");
      base.setBalance(base.getBalance() + inrst);

    }
  }
}
