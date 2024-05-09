﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BusinessLogic.Interfaces;
using eUseControl.BusinessLogic;

namespace eUseControl.BusinessLogic
{
    public class BussinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBL();
        }
        public ISessionAdmin GetSessionAdmin()
        {
            return new SessionAdmin();
        }

    }
}