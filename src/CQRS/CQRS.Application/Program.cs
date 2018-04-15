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

            //Add test data using commands
            writeModel.Handle(new AddGroupCommand(0,"De onde"));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1991, 1, 13), "Scar"));
            writeModel.Handle(new JoinGroupCommand(0, 1, 1));
            writeModel.Handle(new AddUserCommand(0, new DateTime(2000, 2, 12), "Shenzi"));
            writeModel.Handle(new JoinGroupCommand(0, 2, 1));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1448, 3, 11), "Banzai"));
            writeModel.Handle(new JoinGroupCommand(0, 3, 1));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1998, 4, 10), "Ed"));
            writeModel.Handle(new JoinGroupCommand(0, 4, 1));
            writeModel.Handle(new RenameUserCommand("Ib", 0, "Ed", 3));

            writeModel.Handle(new AddGroupCommand(0, "De gode"));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1991, 1, 1), "Mufasa"));
            writeModel.Handle(new JoinGroupCommand(0, 5, 2));
            writeModel.Handle(new AddUserCommand(0, new DateTime(2005, 4, 1), "Simba"));
            writeModel.Handle(new JoinGroupCommand(0, 6, 2));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1950, 4, 1), "Timon"));
            writeModel.Handle(new JoinGroupCommand(0, 7, 2));
            writeModel.Handle(new AddUserCommand(0, new DateTime(1950, 8, 1), "Pumba"));
            writeModel.Handle(new JoinGroupCommand(0, 8, 2));

            try
            {
                int groupNr = ShowGroups(readModel);
                int memberNr = ShowMembers(readModel.GetGroupById(groupNr));
                ShowMember(readModel.GetUserById(memberNr));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
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
        public static void ShowMember(UserDisplay user)
        {
            Console.WriteLine("Name: "+user.Name);
            Console.WriteLine("BirthDay: " + user.Age);
            Console.ReadKey();
        }
    }
}
