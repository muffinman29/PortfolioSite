﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace StevenWilliams.Hubs
{
    public class AppHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        public void UpdatePage()
        { 
            
        }
    }
}