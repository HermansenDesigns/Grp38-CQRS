using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CQRS.Command;
using CQRS.Query;

namespace CQRS.Application
{
    static class ExtensionHelpers
    {
        public static AddGroupCommand AddGroup(string name)
        {
            return new AddGroupCommand(1,name);
        }
        public static AddUserCommand AddUser(DateTime age, string name)
        {
            return new AddUserCommand(1, age, name);
        }
        public static RenameUserCommand RenameUser(this UserDisplay user, string name)
        {
            var version = 1;
            if (user.LatestRenameUserCommand != null)
                version = user.LatestRenameUserCommand.Version + 1;
            return new RenameUserCommand(name,version,user.Name,user.Id);
        }

        public static JoinGroupCommand JoinGroup(this GroupsDisplay group, long userId)
        {
            var version = 1;
            if (group.LatestJoinGroupCommand != null)
                version = group.LatestJoinGroupCommand.Version + 1;
            return new JoinGroupCommand(version,userId,group.Id);
        }
       
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            var writeModel = new Handlers();
            var readModel = new Queries();
            
            //Add test data using commands
            writeModel.Handle(ExtensionHelpers.AddGroup("De onde"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1991, 1, 13), "Scar"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(2000, 2, 12), "Shenzi"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1448, 3, 11), "Banzai"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1998, 4, 10), "Ed"));

            {
                var deOnde = readModel.GetAllGroups().FirstOrDefault(group => group.Name == "De onde");
                var scar = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Scar");
                var shenzi = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Shenzi");
                var banzai = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Banzai");
                var ed = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Ed");
                writeModel.Handle(deOnde.JoinGroup(scar.Id));
                writeModel.Handle(deOnde.JoinGroup(shenzi.Id));
                writeModel.Handle(deOnde.JoinGroup(banzai.Id));
                writeModel.Handle(deOnde.JoinGroup(ed.Id));

                writeModel.Handle(ed.RenameUser("Ib!"));

            }
            
            writeModel.Handle(ExtensionHelpers.AddGroup("De gode"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1991, 1, 1), "Mufasa"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(2005, 4, 1), "Simba"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1950, 4, 1), "Timon"));
            writeModel.Handle(ExtensionHelpers.AddUser(new DateTime(1950, 8, 1), "Pumba"));

            {
                var deGode = readModel.GetAllGroups().FirstOrDefault(group => group.Name == "De gode");
                var Mufasa = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Mufasa");
                var Simba = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Simba");
                var Timon = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Timon");
                var Pumba = readModel.GetAllUsers().FirstOrDefault(user => user.Name == "Pumba");
                writeModel.Handle(deGode.JoinGroup(Mufasa.Id));
                writeModel.Handle(deGode.JoinGroup(Simba.Id));
                writeModel.Handle(deGode.JoinGroup(Timon.Id));
                writeModel.Handle(deGode.JoinGroup(Pumba.Id));

                

            }

            try
            {
                int groupnr = ShowGroups(readModel);
                int memberNr = ShowMembers(readModel.GetAllGroups().FirstOrDefault(group => group.Id == groupnr));
                ShowMember(readModel.GetAllUsers().FirstOrDefault(user => user.Id == memberNr));
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
        public static int ShowMembers(GroupsDisplay group)

        {
            Console.WriteLine("Members:");
            foreach (var member in group.Members)
            {
                Console.WriteLine(member.Name + " with id: " + member.Id);
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
