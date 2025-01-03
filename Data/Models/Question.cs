using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AskMeProgram.Data.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionBody { get; set; }

        public string QuestionAnswer { get; set; } = "No Answer";
        public bool Anonumous { get; set; }
        public User User {  get; set; }
        public  int UserId {  get; set; }

        public int ToId { get; set; }
        public List<Threadd> threads {  get; set; }
        public override string ToString()
        {
            if (Anonumous == false)
            {
                int n = 0;
                if (this.threads != null)
                {
                    n= this.threads.Count;
                }
                return $"Question Id {this.Id} from user id ({UserId})  \n" +
                    $"Question : {QuestionBody}\n" +
                    $"Answer : {QuestionAnswer}";
            }
            else
            {
                return $"Question Id {this.Id} \n" +
                   $"Question : {QuestionBody}\n" +
                   $"Answer : {QuestionAnswer}";
            }
           
        }
    } 
}
