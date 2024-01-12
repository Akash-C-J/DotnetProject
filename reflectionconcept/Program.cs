using System;
using System.Text.RegularExpressions;
using System.Reflection;
class SignUp
{
    Dictionary <string,string> registeruser=new Dictionary<string,string>();
    public void validate(){

        string username;
        string pass="";
        ConsoleKeyInfo pwd;

        Console.WriteLine("Enter userID: ");
        username=Console.ReadLine();
        Console.Write("Enter password: ");
        while(true)
        {
            pwd=Console.ReadKey(true);
            if(pwd.Key == ConsoleKey.Enter)
            {
                 break;           
            }
            if(pwd.Key != ConsoleKey.Backspace)
            {
                pass+=pwd.KeyChar;
                Console.Write("*");
            }
            
        }

        Regex re =new Regex("^[A-Z][a-z]{5}");
        if (username.Length>=6)
        {
            if (re.IsMatch(pass))
            {
                registeruser.Add(username,pass);
                Console.WriteLine("\n Signup successfully");
            }
            else{
                Console.WriteLine("\n Password doesn't match requirement");
                validate();
            }
        }
        else
        {
            Console.WriteLine("\n username is too short");
            validate();

        }         
    }
    public void SignIn(string username)
    { 
        string password="";
        ConsoleKeyInfo pwd1;
        Console.Write("Enter password: ");
        while(true)
        {
            pwd1=Console.ReadKey(true);
            if(pwd1.Key == ConsoleKey.Enter)
            {
                 break;           
            }
            if(pwd1.Key != ConsoleKey.Backspace)
            {
                password+=pwd1.KeyChar;
                Console.Write("*");
            }
            
        }     
            foreach(KeyValuePair<string,string> entry1 in registeruser)
            {
                if (String.Equals(entry1.Key,username) && String.Equals(entry1.Value,password))
                {
                    Console.WriteLine("\n successfully Logged in");
                    return;
                }
                 else
                 {
                     Console.WriteLine("\n user not found");
                 }
            }
    }
    public void DisplayDetails()
    {
        foreach(KeyValuePair<string,string>entry in registeruser)
        {
            Console.WriteLine("userId: "+entry.Key+" password: "+entry.Value);
        }

        
    }
}
class Program
{
    public static void Main(string[] args)
{
    Type T = typeof(SignUp);
    Console.WriteLine("Methods in program class");
    MethodInfo[] akash = T.GetMethods();
    foreach (MethodInfo method in akash)
    {
        Console.WriteLine(method.ReturnType.Name + " " + method.Name);
    }
    Type d = typeof(SignUp);
    Console.WriteLine("Field in program class");
    FieldInfo[] ak = d.GetFields();
    foreach (FieldInfo field in ak)
    {
        Console.WriteLine(field.Name);
    }
    {       
        SignUp obj=new SignUp();
        bool i=true;
        while(i)
        {
            Console.WriteLine(" 1.Signup \n 2.SignIn \n 3.usersDetails \n 4.Exit");
            switch(Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    obj.validate();
                    break;
                case 2:
                    Console.Write("Enter userID: ");
                    string Name = Console.ReadLine();
                    obj.SignIn(Name);
                    break;
                case 3:
                    obj.DisplayDetails();
                    break;
                case 4:
                    i=false;
                    break;

            }
        }

    }
}

}