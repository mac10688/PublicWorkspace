using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseLibraryUnityBlockDemo
{
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System.Configuration;

    class Program
    {
        private String outMessage = String.Empty;
        private void UnityWithConfiguration()
        {
            // Create and populate a new Unity container from configuration            
            UnityConfigurationSection UnityConfigurationSectionObject = (UnityConfigurationSection)ConfigurationManager.GetSection("UnityBlockConfiguration");
            IUnityContainer UnityContainerObject = new UnityContainer();

            UnityConfigurationSectionObject.Containers["ContainerOne"].Configure(UnityContainerObject);
            Console.WriteLine("\nRetrieved the populated Unity Container.");

            // Get the logger to write a message and display the result. No name in config file.
            ILogger ILoggerInstance = UnityContainerObject.Resolve < ILogger>();            
            Console.WriteLine("\n" + ILoggerInstance.WriteMessage("HELLO Default UNITY!"));

            // Resolve an instance of the appropriate class registered for ILogger 
            // Using the specified mapping name in the configuration file (may be empty for the default mapping)
            ILoggerInstance = UnityContainerObject.Resolve<ILogger>("StandardLoggerMappedInConfig");
            
            // Get the logger to write a message and display the result
            Console.WriteLine("\n" + ILoggerInstance.WriteMessage("HELLO StandardLogger!"));
            
            // Resolve an instance of the appropriate class registered for ILogger 
            // Using the specified mapping name (may be empty for the default mapping)
            ILoggerInstance = UnityContainerObject.Resolve<ILogger>("SuperFastLoggerMappedInConfig");
            
            // Get the logger to write a message and display the result
            Console.WriteLine("\n" + ILoggerInstance.WriteMessage("HELLO SuperFastLogger!"));

            // Constructor Injection.
            // Resolve an instance of the concrete MyObjectWithInjectedLogger class 
            // This class contains a reference to ILogger in the constructor parameters 
            MyObjectWithInjectedLogger MyObjectWithInjectedLoggerInstance = UnityContainerObject.Resolve<MyObjectWithInjectedLogger>();
            // Get the injected logger to write a message and display the result
            Console.WriteLine("\n" + MyObjectWithInjectedLoggerInstance.GetObjectStringResult());

            // Throws error as we are trying to create instance for interface.
            //IMyInterface IMyInterfaceObject = UnityContainerObject.Resolve<IMyInterface>();

            IMyInterface IMyInterfaceObject = UnityContainerObject.Resolve<IMyInterface>();
            Console.WriteLine("\n" + IMyInterfaceObject.GetObjectStringResult());

            //If we are not sure whether a named registration exists for an object, 
            // we can use the ResolveAll method to obtain a list of registrations and mappings, and then check for the object we need in the list returned by this method. 
            // However, this will cause the container to generate all the objects for all named registrations for the specified object type, which will affect performance.
            IEnumerable<object> IEnumerableObjects = UnityContainerObject.ResolveAll(typeof(ILogger));
            int i = 0;
            foreach (ILogger foundObject in IEnumerableObjects)
            {
                // Convert the object reference to the "real" type
                ILogger theObject = foundObject as ILogger;
                i++;
                if (null != theObject)
                {
                    Console.WriteLine(theObject.WriteMessage("Reading Object " + i.ToString()));
                }
            }
            
            UnityContainerObject.Teardown(IMyInterfaceObject);

            Console.ReadLine();
        }
        private void UnityAtRuntime()
        {
            // Create a new Unity container
            IUnityContainer UnityContainerObject = new UnityContainer();
            Console.WriteLine("\nRetrieved the populated Unity Container.");

            // Resolve an instance (Create an object) of the class registered for ILogger.
            // And inejcts the object which specified in config file container section.
            ILogger ILoggerObject = UnityContainerObject.Resolve<MyLogger>();

            // Invoke the method from Injected object and display the result
            Console.WriteLine("\n" + ILoggerObject.WriteMessage("My Logger"));

            UnityContainerObject.Teardown(ILoggerObject);

            
            // Register a new default (un-named) mapping with the container
            // This will replaces the existing mapping in the container for ILogger            
            UnityContainerObject.RegisterType<ILogger, MyFastLogger>();
            Console.WriteLine("\nRegistered a new mapping for IMyInterface to MyOtherObject.");

            ILoggerObject = UnityContainerObject.Resolve<ILogger>();
            Console.WriteLine("\n" + ILoggerObject.WriteMessage("Fast Logger"));

            // Resolve an instance of the appropriate class registered for ILogger 
            // Using the specified mapping name in the configuration file (may be empty for the default mapping)
            ILogger ILoggerInstance = UnityContainerObject.Resolve<ILogger>("StandardLogger");

            // Get the logger to write a message and display the result
            Console.WriteLine("\n" + ILoggerInstance.WriteMessage("HELLO UNITY!"));

            // Resolve an instance of the appropriate class registered for ILogger 
            // Using the specified mapping name (may be empty for the default mapping)
            ILoggerInstance = UnityContainerObject.Resolve<ILogger>("SuperFastLogger");            // This name specifies the type of logger required

            // Get the logger to write a message and display the result
            Console.WriteLine("\n" + ILoggerInstance.WriteMessage("HELLO UNITY!"));

            // Resolve an instance of the concrete MyObjectWithInjectedLogger class 
            // This class contains a reference to ILogger in the constructor parameters
            MyObjectWithInjectedLogger MyObjectWithInjectedLoggerInstance = UnityContainerObject.Resolve<MyObjectWithInjectedLogger>();
            
            // Get the injected logger to write a message and display the result
            Console.WriteLine("\n" + MyObjectWithInjectedLoggerInstance.GetObjectStringResult());

            Console.ReadLine();
        }
        static void Main(string[] args)
        {            
            Program ProgramObject = new Program();
            ProgramObject.UnityWithConfiguration();
            //ProgramObject.UnityAtRuntime();
        }
    }
}
/*
// Get the existing populated Unity container from Application object if available
Object retrievedContainer = myContainer;
if (retrievedContainer == null)
{
    outMessage = "ERROR: Unity Container not populated in Global.asax.";
}
else
{
    // Found an existing container, so cast it to the correct type
    myContainer = retrievedContainer as IUnityContainer;
    outMessage = "Retrieved the populated Unity Container from the Application object.";
}
*/
/*
<!-- Default (un-named) mapping for ILogger to MyLogger -->
<type type="ILogger" mapTo="MyFastLogger">
<lifetime type="SingletonType"/>
</type>

<!-- Named mapping for ILogger to StandardLogger-->
<type name="StandardLogger" type="ILogger" mapTo="MyLogger" >
<lifetime type="SingletonType"/>
</type>

<!-- Named mapping for ILogger to SuperFastLogger-->
<type name="SuperFastLogger" type="ILogger" mapTo="MyFastLogger" >
<lifetime type="ExternalType"/>
</type>


<!-- Version, Culture, PublicKeyToken attributes are optional
    <section name="UnityBlockConfiguration"
             type="Microsoft.Practices.Unity.Configuration.UnityConfigurationSection,   Microsoft.Practices.Unity.Configuration, Version=1.1.0.0,   Culture=neutral, PublicKeyToken=31bf3856ad364e35"/>         -->
*/