using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SocialNetwork.Domain;

namespace SocialNetwork.ConsoleApplication.Commands
{
    public interface ICommand
    {
        void Execute();
    }
}
