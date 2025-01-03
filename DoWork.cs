using AskMeProgram.Data;
using AskMeProgram.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Transactions;

namespace AskMeProgram
{
    public  static class DoWork
    {
        static int curid=1;
        public static void ListSystemUsers()
        {
            using (var context = new AppDbContext())
            {
                foreach (var user in context.Users)
                {
                    Console.WriteLine(user);
                }
            }
            Menu2();
        }
        public static void Feed()
        {
            using (var context = new AppDbContext())
            {
                foreach (var ques in context.Questions)
                {
                    Console.WriteLine(ques);
                    foreach (var thread in context.Threadds)
                    {
                        if(thread.QuistionId==ques.Id)
                            Console.WriteLine(thread);
                    }

                }
            }
            Menu2();
        }
        
        public static void AskQuestion()
        {
            Console.WriteLine("Enter 1 for Question and 2 for Thread ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter the question body ");
                string body = Console.ReadLine();
                Console.WriteLine("Enter the Id of the user you want to send");
                int id=int.Parse(Console.ReadLine());
                using (var context = new AppDbContext()) {
                    var res = context.Users.FirstOrDefault(x => x.Id == id);
                    if(res==null)
                    {
                        Console.WriteLine("User doesn't exist");
                        Menu2();
                    }
                    Console.WriteLine("If you want it Anonmous Enter true if not  Enter false");
                    bool anon=bool.Parse(Console.ReadLine()) ;
                    Question ques = new Question { QuestionBody = body ,UserId=curid,ToId=id,Anonumous =anon};
                    context.Questions.Add(ques);
                    context.SaveChanges();  
                }
            }
            else
            {
                Console.WriteLine("Enter the Thread body ");
                string body = Console.ReadLine();
                Console.WriteLine("Enter the Id of the user you want to send");
                int id = int.Parse(Console.ReadLine());
                using (var context = new AppDbContext())
                {
                    var res = context.Users.FirstOrDefault(x => x.Id == id);
                    if (res == null)
                    {
                        Console.WriteLine("User doesn't exist");
                        Menu2();
                    }
                    Console.WriteLine("If you want it Anonmous Enter true if not  Enter false");
                    bool anon = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Enter The question id it belongs to ");
                    int quesId=int.Parse (Console.ReadLine());
                    var res2 = context.Questions.FirstOrDefault(x => x.Id == quesId);
                    if(res2==null)
                    {
                        Console.WriteLine("Question Doesn't exist ");
                        Menu2();
                    }
                    Threadd ques = new Threadd { ThreadBody = body, fromId = curid, ToId = id, Anonumous = anon,QuistionId=quesId };
                    context.Threadds.Add(ques);
                    context.SaveChanges();
                }
            }
            Menu2();
        }
        public static void DeleteQuestion()
        {
            Console.WriteLine("Enter 1 for Question and 2 for Thread ");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter Question id or -1 to cancel");
                int res = int.Parse(Console.ReadLine());
                if (res == -1)
                    return;
                using (var context = new AppDbContext())
                {
                    var ques = context.Questions.SingleOrDefault(x => x.Id == res);
                    if (ques == null)
                    {
                        Console.WriteLine("Question doesn't exist ");
                        return;
                    }
                    foreach(var thread in context.Threadds)
                    {
                        if(thread.QuistionId==ques.Id)
                            context.Threadds.Remove(thread);
                    }
                    context.Questions.Remove(ques);
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Enter Thread id or -1 to cancel");
                int res = int.Parse(Console.ReadLine());
                if (res == -1)
                    return;
                using (var context = new AppDbContext())
                {
                    var ques = context.Threadds.SingleOrDefault(x => x.Id == res);
                    if (ques == null)
                    {
                        Console.WriteLine("Thread doesn't exist ");
                        return;
                    }
                    context.Threadds.Remove(ques);
                    context.SaveChanges();
                }
            }
            Menu2();
        }
        public static void PrintQuestionsFromMe()
        {
            using (var context = new AppDbContext())
            {
                var res = context.Questions.Where(x => x.UserId == curid).ToList();
                foreach (var x in res)
                {
                    Console.WriteLine(x);
                  
                        foreach(var thread in context.Threadds)
                        {
                            if(thread.QuistionId==x.Id)
                            Console.WriteLine(thread);
                        }
                    

                }
                var res2= context.Questions.Where(x => x.UserId != curid).ToList();
                foreach (var x in res)
                {
                    
                        foreach (var th in context.Threadds)
                        {
                            if (th.fromId == curid)
                                Console.WriteLine(th);
                        }
                   

                }
            }
            Menu2();

        }
        public static void PrintQuestionsToMe()
        {
            using (var context = new AppDbContext())
            {
               var res=context.Questions.Where(x=>x.ToId==curid).ToList();
                foreach (var x in res)
                {
                    Console.WriteLine(x);
                    
                        foreach(var thread in context.Threadds)
                        {
                            if(thread.QuistionId==x.Id)
                                Console.WriteLine(thread);
                        }
                    
                }
                var res2 = context.Questions.ToList();
                if (res2 != null)
                {
                    foreach (var x in res2)
                    {
                        foreach (var thread in context.Threadds)
                        {
                            if (thread.ToId == curid)
                                Console.WriteLine(thread);
                        }

                    }
                }
            }
            Menu2();
        }
        public static void AnswerQuestion()
        {
            Console.WriteLine("Enter 1 for Question and 2 for Thread ");
            int choice=int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Enter Question id or -1 to cancel");
                int res = int.Parse(Console.ReadLine());
                if (res == -1)
                    return;
                using (var context = new AppDbContext())
                {
                    var ques = context.Questions.SingleOrDefault(x => x.Id == res);
                    if (ques == null)
                    {
                        Console.WriteLine("Question doesn't exist ");
                        return;
                    }
                    Console.WriteLine("Enter your answer ");
                    if (ques.QuestionAnswer != "No Answer")
                        Console.WriteLine("Answer already exist , it would be updated");
                    string ans = Console.ReadLine();
                    ques.QuestionAnswer = ans;
                    context.SaveChanges();
                }
            }
            else
            {
                Console.WriteLine("Enter Thread id or -1 to cancel");
                int res = int.Parse(Console.ReadLine());
                if (res == -1)
                    return;
                using (var context = new AppDbContext())
                {
                    var ques = context.Threadds.SingleOrDefault(x => x.Id == res);
                    if (ques == null)
                    {
                        Console.WriteLine("Question doesn't exist ");
                        return;
                    }
                    Console.WriteLine("Enter your answer ");
                    if (ques.ThreadAnswer == "No Answer")
                        Console.WriteLine("Answer already exist , it would be updated");
                    string ans = Console.ReadLine();
                    ques.ThreadAnswer = ans;
                    context.SaveChanges();
                }
            }
            Menu2();
        }

        public static void Menu2()
        {
            Console.WriteLine("1 : Print questions to me ");
            Console.WriteLine("2 : Print questions from me");
            Console.WriteLine("3 : Answer question ");
            Console.WriteLine("4 : Delete question ");
            Console.WriteLine("5 : Ask question");
            Console.WriteLine("6 : List System Users");
            Console.WriteLine("7 : Feed");
            Console.WriteLine("8 : LogOut");
            Console.WriteLine("Enter  number  in range 1 - 8 ");
            int res=int.Parse(Console.ReadLine());
            while (res < 1 || res > 8)
            {
                Console.WriteLine("Invalid Number .... Try Again ");
                res = int.Parse(Console.ReadLine());
            }
            if (res == 1)
                PrintQuestionsToMe();
            else if (res == 2)
                PrintQuestionsFromMe();
            else if (res == 3)
                AnswerQuestion();
            else if (res == 4)
                DeleteQuestion();
            else if (res == 5)
                AskQuestion();
            else if (res == 6)
                ListSystemUsers();
            else if (res == 7)
                Feed();
            else
                return;
        }
        public static void Menu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1: Login");
            Console.WriteLine("2 : Sign Up");
            Console.WriteLine("Enter a number 1 - 2");
            int x= int.Parse(Console.ReadLine());
            if (x != 1 && x != 2)
                return;
            else if(x==1)
            {
                Console.WriteLine("Enter username and password");
                string username=Console.ReadLine(); 
                string password= Console.ReadLine();
                using (var context = new AppDbContext())
                {
                    var res=context.Users.SingleOrDefault(x=>x.Name==username);
                    if(res==null||res.Password!=password)
                    {
                        Console.WriteLine("Email Not Found");
                        return;
                    }
                    curid = res.Id;
                    Menu2();
                }
            }
            else
            {
                Console.WriteLine("Enter username , email and password");
                string username = Console.ReadLine();
                string email= Console.ReadLine();
                string password = Console.ReadLine();
                using (var context = new AppDbContext())
                {
                    User user = new User {Name=username,Email=email,Password=password };
                    context.Users.Add(user);
                    context.SaveChanges();
                    curid=user.Id;
                    
                }
            }
        }
    }
}
