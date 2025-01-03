using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AskMeProgram.Data.Models
{
    public class Threadd
    {
        public int Id { get; set; }
        public string ThreadBody { get; set; }

        public string? ThreadAnswer { get; set; } = "No Answer";
        public bool Anonumous { get; set; }

        public int ToId { get; set; }
        public int fromId {  get; set; }
        public Question Question { get; set; }
        public int QuistionId {  get; set; }

        public override string ToString()
        {
            if (Anonumous != true)
            {
                return $"Thread Id {this.Id} from Question id ({QuistionId})\n" +
                    $"Question : {ThreadBody}\n" +
                    $"Answer : {ThreadAnswer}";
            }
            else
            {
                return $"Thread Id {this.Id}  \n" +
                   $"Question : {ThreadBody}\n" +
                   $"Answer : {ThreadAnswer}";
            }
           
        }
    }
}
