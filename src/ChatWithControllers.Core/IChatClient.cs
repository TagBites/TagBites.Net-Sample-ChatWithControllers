using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatWithControllers
{
    public interface IChatClient
    {
        void MessageReceive(string userName, string message);
    }
}