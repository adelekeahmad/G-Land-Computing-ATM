// See https://aka.ms/new-console-template for more information
using System;
public class cardHolder
{
    String cardNum;
    String firstName;
    String lastName;
    int pin;
    double balance;
    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }
    public String getNum() 
    {
        return cardNum;
    }
    public int getPin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    static void Main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the three options below ...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdrawal");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
           Console.WriteLine("How much money do you want to deposite: ");
           double deposit = Double.Parse(Console.ReadLine());
           currentUser.setBalance(currentUser.getBalance() + deposit);
          Console.WriteLine("Thank you for your money. Your new balance is: " + currentUser.getBalance());
        }
        void withdrawal(cardHolder currentUser)
        {
            Console.WriteLine("How much money do you want to Withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check user does not withdraw more than current balance
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You are good to go, thank you. :)");
            }
        }
        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current Balance is " + currentUser.getBalance());
        }
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("5425233430109903", 4534, "Jane", "Mark", 1500.50));
        cardHolders.Add(new cardHolder("5425233430109903", 9128, "Kali", "Linux", 160000.76));
        cardHolders.Add(new cardHolder("2222420000001113", 9647, "Timmy", "Ebube", 200000.98));
        cardHolders.Add(new cardHolder("2223000048410010", 3231, "Egbe", "Atiba", 100000.23));


        //Now its time to prompt users
        Console.WriteLine("Welcome to Ahmad's ATM");
        Console.WriteLine("Please insert your debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against our hypothetical db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) 
                { break; }
                else
                {
                    Console.WriteLine("Card not recognized, please try again later: ");
                }
                
            }
            catch
            {
                Console.WriteLine("Card not recognized, please try again later: "); 
            }
        }
        
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if(currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin, please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin, please try again"); }
        }
        Console.WriteLine("Welcome " + currentUser.getFirstName() + ":)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(currentUser); }
            else if (option == 2) { withdrawal(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        {
            Console.WriteLine("Thank you, have a nice day :)");
        }
    }
}
