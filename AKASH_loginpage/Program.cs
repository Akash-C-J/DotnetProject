using System;  
using System.Data.SqlClient;  
#nullable disable
    class Program  
    {  
        static void Main(string[] args)  
        {  
           Console.WriteLine("Welcome");
           Console.WriteLine("Connection to the SQL server Established Successfully..."); 
           Console.WriteLine("Make a choice");
           Console.WriteLine(" 1.Create a new table \n 2.Add \n 3.Read \n 4.Update \n 5.Delete ");
           Program caller = new Program();
           caller.selectoption();
        }
        public void selectoption(){
           Program casenumber = new Program();
           Console.WriteLine("enter choice :");
           int option=Convert.ToInt32(Console.ReadLine());
            while(option<=5){
        switch(option)
        {
            case 1:
            casenumber.create();
            break;
            case 2:
            casenumber.addData();            
            break;
            case 3:
            casenumber.getData();
            break;
            case 4:
            casenumber.updateData();
            break;
            case 5:
            casenumber.deleteData();
            break;
            default:
            Console.WriteLine("Make a Valid Choice");
            break;
        }
        }
        } 
        public void create(){
        using (  
                     // Creating Connection  
                     SqlConnection con = new SqlConnection("data source=aspire1542; database=project2; integrated security=SSPI")
                 )  
            {  
                con.Open();  
                SqlCommand command1 = new SqlCommand("create table userdata(username varchar(20), Idno varchar(20))", con); 
                command1.ExecuteNonQuery();
                Console.WriteLine("Table has been created...");
            }
           selectoption();
        }
        public void addData()  
        {  
            Console.WriteLine("Enter Username");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Access Id");
            string number=Console.ReadLine();
             using (  
                     // Creating Connection  
                     SqlConnection con1 = new SqlConnection("data source=aspire1542; database=project2; integrated security=SSPI")
                 )
            
            {
                con1.Open();
                SqlCommand command2= new SqlCommand("insert into userdata(username,Idno) values('"+name+"','"+number+"')", con1);
                command2.ExecuteNonQuery();
            }  
            selectoption();
        }  
         public void getData()  
        {  
            
             using (  
                     // Creating Connection  
                     SqlConnection con2= new SqlConnection("data source=aspire1542; database=project2; integrated security=SSPI")
                 )
            
            {
                con2.Open();
                SqlCommand command3= new SqlCommand("select*from userdata", con2);
                SqlDataReader value = command3.ExecuteReader();
                while (value.Read())  
                {  
                    Console.WriteLine(value["username"] + " " + value["Idno"]);   
                }  
            }  
            selectoption();
        }  
        public void updateData()  
        {  
            Console.WriteLine("Enter Access Id : ");
            string Idno=Console.ReadLine();
            Console.WriteLine("Rename user as");
            string newname =Console.ReadLine();
             using (  
                     // Creating Connection  
                     SqlConnection con3= new SqlConnection("data source=aspire1542; database=project2; integrated security=SSPI")
                 )
            
            {
                con3.Open();
                SqlCommand command4= new SqlCommand($"update userdata set username='{newname}' where Idno='{Idno}'", con3);
                command4.ExecuteNonQuery();
                Console.WriteLine("Data has been Updated"); 
            }  
            selectoption();
        }  
        public void deleteData()  
        {  
            Console.WriteLine("Enter data to delete");
            string getname =Console.ReadLine();
             using (  
                     // Creating Connection  
                     SqlConnection con4= new SqlConnection("data source=aspire1542; database=project2; integrated security=SSPI")
                 )
            
            {
                con4.Open();
                SqlCommand command4= new SqlCommand($"delete userdata where username='{getname}'", con4);
                command4.ExecuteNonQuery();
                Console.WriteLine("Data has been deleted from this entire row"); 
            }  
            selectoption();
        }  
    }