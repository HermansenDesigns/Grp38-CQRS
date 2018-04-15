using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQRS.Commands;
using CQRS.Domain;
using CQRS.Query;

namespace CQRS.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new UserGroupContext();
            var writeModel = new Handlers(context);
            var readModel = new Queries(context);

            int groupNr = ShowGroups(readModel);


        }

        public static int ShowGroups(Queries readModel)
        {
            foreach (var group in readModel.GetAllGroups())
            {
                Console.WriteLine(group.Name + " with id: "+group.Id);
            }
            Console.WriteLine("Write an id to show members:");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int ShowMembers(GroupDisplay group)
        {
            Console.WriteLine("Members:");
            foreach (var member in group.Members)
            {
                Console.WriteLine(member.Item1 + " with id: " + member.Item2);
            }
            Console.WriteLine("Write an id to show details:");
            return Convert.ToInt32(Console.ReadLine());
        }
        public static int ShowMember(UserDisplay user)
        {
            Console.WriteLine("Name: "+user.Name);
            Console.WriteLine("BirthDay: " + user.Age);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
