using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseLibraryUnityBlockDemo
{
    public interface ILogger
    {
        string WriteMessage(string message);
    }
    public class MyLogger : ILogger
    {
        public string WriteMessage(string message)
        {
            return "MyLogger - '" + message + "'.";
        }
    }
    public class MyFastLogger : ILogger
    {
        public string WriteMessage(string message)
        {
            return "MyFastLogger - '" + message + "'";
        }
    }   
    
    public interface IMyInterface
    {
        string GetObjectStringResult();
    }
   
    // Constructor Injection.
    public class MyObjectWithInjectedLogger : IMyInterface
    {
        private ILogger theLogger;

        public MyObjectWithInjectedLogger(ILogger log)
        {
            theLogger = log;
        }

        public string GetObjectStringResult()
        {
            string output = theLogger.WriteMessage("SOME REALLY IMPORTANT MESSAGE");
            return "Hi, I'm the 'MyObjectWithInjectedLogger' object, and I've got a reference to some type of Logger!<p />" + output;
        }
    }
}
