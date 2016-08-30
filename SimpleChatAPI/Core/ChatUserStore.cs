using Microsoft.AspNet.Identity.EntityFramework;
using SimpleChatAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleChatAPI.Core
{
    public class ChatUserStore: UserStore<IdentityUser>
    {
        public ChatUserStore() : base(new AppContext())
        {
        }
    }
}