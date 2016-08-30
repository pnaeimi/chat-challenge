using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatAPI.Core
{
    public class ChatUserManager: UserManager<IdentityUser>
    {
        public ChatUserManager() : base(new ChatUserStore())
        {
        }
    }
}