using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Anty
{
        public class Log 
        {
                public void Print(string msg)
                {
#if DEBUG_NORMAL
                        Debug.Log(msg);
#elif DEBUG_FILE
                //TODO log to file
#endif
                }
        }
}