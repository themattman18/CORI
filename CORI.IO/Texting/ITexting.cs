using System;
using System.Collections.Generic;
using System.Text;

namespace CORI.IO.Texting
{
    public interface ITexting
    {
        void SendText(Models.TextingViewModel textingMessage);
    }
}
